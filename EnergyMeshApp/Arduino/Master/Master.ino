#include <digitalIOPerformance.h>
#include <AESLib.h>
#include <U8glib.h>
#include <Mesh24.h>
#include <RF24.h>
#include <Mesh24Uptime.h>
#include <SPI.h>
#include <DS3232RTC.h>
#include <Time.h>
#include <Wire.h>
#include <Ethernet.h>
#include <SD.h>
#include <Bounce2.h>
//#define a_inline inline __attribute__((always_inline))
#define a_inline inline

const boolean DEBUG = true;
const byte DEBUG_LOGFILE_TIME = 0;
const long DEBUG_BAUD = 115200;

#include "Misc.h"
#include "FTP.h"
#include "SD.h"
#include "LCD.h"
#include "RF.h"
#include "Ethernet.h"

void loop()
{
  RF_loop();
  Ethernet_loop();
  SD_checkUpload();
  SD_check();
  LCD_loop();
}

void setup()
{
  if(DEBUG) {
    delay(500);
    Serial.begin(DEBUG_BAUD);
    Serial.println("Energy Mesh @ Kim Hao - 6/2015");
  }
  LCD_setup();
  delay(2000);
  LCD_switchState(LCD_CHECK);
  if(DEBUG) {
    Serial.println(F("__DEBUG ON__"));
    Serial.print(F("Address: "));
    Serial.println(MASTER_ADDR);
  }
  if(RTC_setup()) LCD_newCheckState(LCDCHECK_RTC);
  IO_setup();
  if(RF_setup()) LCD_newCheckState(LCDCHECK_RF);
  if(SD_setup()) LCD_newCheckState(LCDCHECK_SD);
  SD_openLogFile();
  if(Ethernet_setup()) LCD_newCheckState(LCDCHECK_ETHERNET);
  if(DEBUG) Serial.println(F("__ Setup completed __"));
  SD_upload();
  LCD_switchState(LCD_NORMAL);
  if(DEBUG) Serial.println(F("__ System is ready __"));
}
