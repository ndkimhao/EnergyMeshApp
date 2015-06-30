Mesh24Timer logHeartbeatTimer(100000);

const byte RF_CHANNEL = 60;
const byte MASTER_ADDR = 1;
const byte PA_LEVEL = RF24_PA_MAX;
enum MessageType {
  MessageDefault, MessageHeartbeat, MessageTemperature, MessageRealPower, MessageDetailPower,
};
Mesh24 mesh24(CE_RF24, CS_RF24);

void always_inline RF_loop() {
  Mesh24Message recvMessage;
  if (mesh24.read(recvMessage)) {
    byte from = recvMessage.getFrom();
    switch(recvMessage.getType()) {
    case MessageHeartbeat:
      {
        unsigned int vcc;
        unsigned long uptime;
        unsigned int freeRam;
        recvMessage.readPayload(vcc);
        recvMessage.readPayload(uptime);
        recvMessage.readPayload(freeRam);

        SD_logBegin(Log_ClientHeartbeat);
        SD_logData(from);
        SD_logData(vcc, 100);
        SD_logData(uptime);
        SD_logData(freeRam);
        SD_logEndRecord();

        if(DEBUG) {
          printTime();
          Serial.print(F(": *From "));
          Serial.print(from);
          Serial.print(F("* Type: "));
          Serial.print(recvMessage.getType());
          Serial.print(F(" - VCC Voltage: "));
          Serial.print(vcc);
          Serial.print(F(" - Uptime: "));
          Serial.print(uptime);
          Serial.print(F(" - Free RAM: "));
          Serial.println(freeRam);
        }
      }
      break;
    case MessageTemperature:
      {
        float temp;
        recvMessage.readPayload(temp);

        SD_logBegin(Log_ClientTemperature);
        SD_logData(from);
        SD_logData(temp);
        SD_logEndRecord();

        if(DEBUG) {
          printTime();
          Serial.print(F(": *From "));
          Serial.print(from);
          Serial.print(F("* Type: "));
          Serial.print(recvMessage.getType());
          Serial.print(F(" - Temperature: "));
          Serial.println(temp);
        }
      }
      break;
    case MessageRealPower:
      {
        byte sensorID;
        unsigned long session;
        float realPower;
        recvMessage.readPayload(sensorID);
        recvMessage.readPayload(session);
        recvMessage.readPayload(realPower);

        SD_logBegin(Log_ClientRealPower);
        SD_logData(from);
        SD_logData(sensorID);
        SD_logData(session);
        SD_logData(realPower);
        SD_logEndRecord();

        if(DEBUG) {
          printTime();
          Serial.print(F(": *From "));
          Serial.print(from);
          Serial.print(F("* Type: "));
          Serial.print(recvMessage.getType());
          Serial.print(F(" - CT: "));
          Serial.print(sensorID);
          Serial.print(F(" - Session: "));
          Serial.print(session);
          Serial.print(F(" - Real.P: "));
          Serial.println(realPower);
        }
      }
      break;
    case MessageDetailPower:
      {
        byte sensorID;
        unsigned long session;
        unsigned int V;
        unsigned int I;
        recvMessage.readPayload(sensorID);
        recvMessage.readPayload(session);
        recvMessage.readPayload(V);
        recvMessage.readPayload(I);

        SD_logBegin(Log_ClientDetailPower);
        SD_logData(from);
        SD_logData(sensorID);
        SD_logData(session);
        SD_logData(V, 100);
        SD_logData(I, 100);
        SD_logEndRecord();

        if(DEBUG) {
          printTime();
          Serial.print(F(": *From "));
          Serial.print(from);
          Serial.print(F("* Type: "));
          Serial.print(recvMessage.getType());
          Serial.print(F(" - CT: "));
          Serial.print(sensorID);
          Serial.print(F(" - Session: "));
          Serial.print(session);
          Serial.print(F(" - Vrms: "));
          Serial.print(V);
          Serial.print(F(" - Irms: "));
          Serial.println(I);
        }
      }
      break;
    }
  }
  if(logHeartbeatTimer.isDue()) {
    unsigned int vcc = readVcc();
    unsigned long uptime = Mesh24Uptime.getSeconds();
    unsigned int freeRam = freeMemory();
    float temp = RTC.temperature() / 4.0;

    SD_logBegin(Log_MasterHeartbeat);
    SD_logData(vcc, 100);
    SD_logData(uptime);
    SD_logData(freeRam);
    SD_logData(temp);
    SD_logEndRecord();

    if(DEBUG) {
      printTime();
      Serial.print(F(": *Master* VCC Voltage: "));
      Serial.print(vcc);
      Serial.print(F(" - Uptime: "));
      Serial.print(uptime);
      Serial.print(F(" - Free RAM: "));
      Serial.print(freeRam);
      Serial.print(F(" - Temperature: "));
      Serial.println(temp);
    }
  }
}

void always_inline RF_setup() {
  if(DEBUG) Serial.println(F("__ RF Setup __"));
  mesh24.setAddr(MASTER_ADDR);
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







