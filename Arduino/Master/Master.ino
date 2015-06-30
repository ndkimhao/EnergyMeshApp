#include <digitalIOPerformance.h>
#include <AESLib.h>
#include <Mesh24.h>
#include <RF24.h>
#include <Mesh24Uptime.h>
#include <SPI.h>
#include <DS3232RTC.h>
#include <Time.h>
#include <Wire.h>
#include <Ethernet.h>
#include <SD.h>
//#define always_inline inline __attribute__((always_inline))
#define always_inline

const boolean DEBUG = true;
const byte DEBUG_LOGFILE_TIME = 0;
const long DEBUG_BAUD = 115200;

#include "Misc.h"
#include "FTP.h"
#include "SD.h"
#include "RF.h"
#include "Ethernet.h"

void loop()
{
  RF_loop();
  Ethernet_loop();
  SD_checkUpload();
  SD_check();
}

void setup()
{
  if(DEBUG) {
    delay(500);
    Serial.begin(DEBUG_BAUD);
    Serial.println(F("DEBUG ON"));
    Serial.print(F("Address: "));
    Serial.println(MASTER_ADDR);
  }
  RTC_setup();
  IO_setup();
  RF_setup();
  SD_setup();
  SD_openLogFile();
  Ethernet_setup();
  if(DEBUG) Serial.println(F("__ Setup completed __"));
  SD_upload();
  /*for(int i=0; i<10; i++) {
    SD_upload();
    if(DEBUG) {
      int freeRam = freeMemory();
      Serial.print(F("Free RAM: "));
      Serial.print(freeRam);
      Serial.print(F(" - Used RAM: "));
      Serial.println(RAM_SIZE - freeRam);
    }
    Serial.println("\r\n");
    delay(1000);
  }*/
}







