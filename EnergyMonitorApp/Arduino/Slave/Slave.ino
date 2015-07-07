#include <digitalIOPerformance.h>
#include <AESLib.h>
#include <Mesh24.h>
#include <RF24.h>
#include <Mesh24Uptime.h>
#include <SPI.h>
#include <OneWire.h>
#include <DallasTemperature.h>
#include <EmonLib.h>
#include <avr/eeprom.h>
#define a_inline inline __attribute__((a_inline))
#include "MiscFunc.h";

const boolean DEBUG = true;
const long DEBUG_BAUD = 115200;

const byte DS18B20_PIN = 2;
const byte DS18B20_PRECISION = 12;
const int DS18B20_CONV_TIME = (750 / (1 << (12 - DS18B20_PRECISION)));
OneWire oneWire_ds18b20(DS18B20_PIN);
DallasTemperature ds18b20(&oneWire_ds18b20);
Mesh24Timer sendTempTimer(10000);
Mesh24Timer convertTempTimer(DS18B20_CONV_TIME, false);
Mesh24Timer sendHeartbeatTimer(100000);

const byte V_PIN = 0;
const byte CT0_LED_PIN = 3;
const byte CT0_BUTTON_PIN = 6;
const byte NUM_CT_PIN = 3;
byte ctSensorCount = 0;
boolean ctSensorState[NUM_CT_PIN];
unsigned long *CT_SESSION_EEPROM = (unsigned long*)400;
unsigned long ctSession[NUM_CT_PIN];

byte curEmonSensor = 0;
byte curEmonSensor_detail = 0;
EnergyMonitor emons[NUM_CT_PIN];

Mesh24Timer sendPowerTimer(1000);
Mesh24Timer sendPowerDetailTimer(15000);

unsigned char *ADDR_EEPROM = (unsigned char*)500;
const byte RF_CHANNEL = 60;
const byte MASTER_ADDR = 1;
const byte PA_LEVEL = RF24_PA_MAX;
enum MessageType {
  MessageDefault, MessageHeartbeat, MessageTemperature, MessageRealPower, MessageDetailPower,
};
Mesh24 mesh24(9, 10);
byte addr;

void loop()
{
  mesh24.loop();
  if(sendTempTimer.isDue()) {
    ds18b20.requestTemperatures();
    convertTempTimer.begin();
  }
  if(convertTempTimer.isDue()) {
    convertTempTimer.stop();
    float temp = ds18b20.getTempCByIndex(0);
    sendTemperature(temp);
    if(DEBUG) {
      Serial.print(F("Temperature: "));
      Serial.println(temp);
    }
  }
  if(ctSensorCount > 0 && sendPowerTimer.isDue()) {
    EnergyMonitor curEmon = emons[curEmonSensor];
    if(curEmon.calcVI()) {
      sendRealPower(curEmonSensor, ctSession[curEmonSensor], curEmon.realPower);
      if(DEBUG) {
        Serial.print(F("CT: "));
        Serial.print(curEmonSensor);
        Serial.print(F(" - Session: "));
        Serial.print(ctSession[curEmonSensor]);
        Serial.print(F(" - Real.P: "));
        Serial.println(curEmon.realPower);
      }
    }
    else if(DEBUG) {
      Serial.print(F("Caculate CT "));
      Serial.print(curEmonSensor);
      Serial.println(F(" failed"));
    }
    while(!ctSensorState[curEmonSensor]) {
      curEmonSensor++;
      if(curEmonSensor >= NUM_CT_PIN) curEmonSensor = 0;
    }
    sendPowerTimer.begin();
  }
  if(ctSensorCount > 0 && sendPowerDetailTimer.isDue()) {
    EnergyMonitor curEmon = emons[curEmonSensor_detail];
    if(curEmon.calcVI()) {
      sendDetailPower(curEmonSensor_detail, ctSession[curEmonSensor_detail], curEmon.Vrms, curEmon.Irms);
      if(DEBUG) {
        Serial.print(F("CT: "));
        Serial.print(curEmonSensor_detail);
        Serial.print(F(" - Session: "));
        Serial.print(ctSession[curEmonSensor_detail]);
        Serial.print(F(" - Vrms: "));
        Serial.print(curEmon.Vrms);
        Serial.print(F(" - Irms: "));
        Serial.println(curEmon.Irms);
      }
    }
    else if(DEBUG) {
      Serial.print(F("Caculate detail CT "));
      Serial.print(curEmonSensor_detail);
      Serial.println(F(" failed"));
    }
    while(!ctSensorState[curEmonSensor_detail]) {
      curEmonSensor_detail++;
      if(curEmonSensor_detail >= NUM_CT_PIN) curEmonSensor_detail = 0;
    }
    sendPowerDetailTimer.begin();
  }
  if(sendHeartbeatTimer.isDue()) {
    unsigned int vcc = readVcc();
    unsigned long uptime = Mesh24Uptime.getSeconds();
    unsigned int freeRam = freeMemory();
    sendHeartbeat(vcc, uptime, freeRam);
    if(DEBUG) {
      Serial.print(F("VCC Voltage: "));
      Serial.print(vcc);
      Serial.print(F(" - Uptime: "));
      Serial.print(uptime);
      Serial.print(F(" - Free RAM: "));
      Serial.println(freeRam);
    }
  }
  for(byte i = 0; i < NUM_CT_PIN; i++) {
    if(ctSensorState[i] && digitalRead(CT0_BUTTON_PIN + i) == LOW) {
      byte pin = CT0_LED_PIN + i;
      digitalWrite(pin, HIGH);
      delay(500);
      ctSession[i]++;
      eeprom_update_dword(CT_SESSION_EEPROM + (i * sizeof(unsigned long)), ctSession[i]);
      if(DEBUG) {
        Serial.print(F("Updated CT "));
        Serial.print(i);
        Serial.print(F(" to "));
        Serial.println(ctSession[i]);
      }
      digitalWrite(pin, LOW);
    }
  }
}

void setup()
{
  addr = eeprom_read_byte(ADDR_EEPROM);
  if(DEBUG) {
    Serial.begin(DEBUG_BAUD);
    Serial.println(F("DEBUG ON"));
    Serial.print(F("Enter slave address: "));
    do {
      long tmpAddr;
      /*for(byte i = 0; i < 5; i++) {
       Serial.print(".");
       delay(200);
       }*/
      tmpAddr = Serial.parseInt();
      if(tmpAddr > MASTER_ADDR && tmpAddr < 255) {
        addr = (byte)tmpAddr;
        eeprom_update_byte(ADDR_EEPROM, addr);
      }
    }
    while(addr == 0);
    Serial.print(F("\nAddress: "));
    Serial.println(addr);
  }

  if(DEBUG) {
    Serial.print(F("Reset session? "));
    /*for(byte i = 0; i < 5; i++) {
     Serial.print(".");
     delay(200);
     }*/
    Serial.println();
    if(Serial.available()) {
      if(Serial.read() == 'Y') {
        for(byte i = 0; i < NUM_CT_PIN; i++) {
          eeprom_update_dword(CT_SESSION_EEPROM + (i * sizeof(unsigned long)), 0);
        }
        Serial.println("Reseted session");
      }
      Serial.flush();
    }
  }

  if(DEBUG) Serial.print(F("Sensor session: "));
  for(byte i = 0; i < NUM_CT_PIN; i++) {
    byte pin = CT0_LED_PIN + i;
    pinMode(pin, OUTPUT);
    digitalWrite(pin, LOW);

    pin = CT0_BUTTON_PIN + i;
    pinMode(pin, INPUT_PULLUP);

    ctSession[i] = eeprom_read_dword(CT_SESSION_EEPROM + (i * sizeof(unsigned long)));
    if(DEBUG) {
      Serial.print(ctSession[i]);
      Serial.print(' ');
    }
  }
  if(DEBUG) {
    Serial.println();
    Serial.print(F("Sensor state: "));
  }
  for(byte i = 0; i < NUM_CT_PIN; i++) {
    int pin = i + 1 + V_PIN;
    int val = analogRead(pin);
    boolean state = (val > 5);
    ctSensorState[i] = state;
    if(state) {
      ctSensorCount++;
      emons[i].voltage(0, 155, 1.7);
      emons[i].current(pin, 6.0606);
      digitalWrite(CT0_LED_PIN + i, HIGH);
    }
    if(DEBUG) {
      Serial.print(val);
      Serial.print(' ');
    }
  }
  if(DEBUG) Serial.println();
  delay(1000);
  for(byte i = 0; i < NUM_CT_PIN; i++) {
    byte pin = CT0_LED_PIN + i;
    digitalWrite(pin, LOW);
  }

  /*emon[0].calcVI();
   while(emon[0].Vrms < 200 || emon[0].Vrms > 260) {
   emon[0].calcVI();
   if(DEBUG) Serial.println(F("Strange voltage"));
   }*/

  ds18b20.begin();
  ds18b20.setResolution(DS18B20_PRECISION);
  ds18b20.setWaitForConversion(false);

  mesh24.setAddr(addr);
  mesh24.setChannel(RF_CHANNEL);
  mesh24.begin();
  mesh24.getRadio().setPALevel(PA_LEVEL);
  if(DEBUG) {
    if(mesh24.getRadio().isPVariant()) {
      Serial.println(F("Setup RF24 ok"));
    }
    else {
      Serial.println(F("Setup RF24 fail"));
    }
  }
}

void a_inline sendHeartbeat(unsigned int vcc, unsigned long uptime, unsigned int freeRam) {
  Mesh24Message message(MASTER_ADDR, MessageHeartbeat);
  message.writePayload(vcc);
  message.writePayload(uptime);
  message.writePayload(freeRam);
  mesh24.write(message);
}

void a_inline sendTemperature(float temp) {
  Mesh24Message message(MASTER_ADDR, MessageTemperature);
  message.writePayload(temp);
  mesh24.write(message);
}

void a_inline sendRealPower(byte sensorID, unsigned long session, float realPower) {
  Mesh24Message message(MASTER_ADDR, MessageRealPower);
  message.writePayload(sensorID);
  message.writePayload(session);
  message.writePayload(realPower);
  mesh24.write(message, false, true);
}

void a_inline sendDetailPower(byte sensorID, unsigned long session, float V, float I) {
  Mesh24Message message(MASTER_ADDR, MessageDetailPower);
  message.writePayload(sensorID);
  message.writePayload(session);
  message.writePayload((unsigned int)(V * 100));
  message.writePayload((unsigned int)(I * 100));
  mesh24.write(message, false, true);
}




