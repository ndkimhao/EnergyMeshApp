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
//#define a_inline inline __attribute__((always_inline))
#define a_inline inline

const boolean DEBUG = true;
const byte DEBUG_LOGFILE_TIME = 0;
const long DEBUG_BAUD = 115200;

#include "Misc.h"
#include "FTP.h"
#include "SD.h"
#include "RF.h"
#include "Ethernet.h"
#include "LCD.h"

void loop()
{
  RF_loop();
  Ethernet_loop();
  SD_checkUpload();
  SD_check();
}

void setup()
{
  if(DEBUG) Serial.println("Energy Monitor @ Kim Hao - 6/2015");
  LCD_setup();
  delay(2000);
  LCD_switchState(LCD_CHECK);
  if(DEBUG) {
    delay(500);
    Serial.begin(DEBUG_BAUD);
    Serial.println(F("DEBUG ON"));
    Serial.print(F("Address: "));
    Serial.println(MASTER_ADDR);
  }
  if(RTC_setup()) LCD_check(LCDCHECK_RTC);
  IO_setup();
  if(RF_setup()) LCD_check(LCDCHECK_RF);
  if(SD_setup()) LCD_check(LCDCHECK_SD);
  SD_openLogFile();
  if(Ethernet_setup()) LCD_check(LCDCHECK_ETHERNET);
  if(DEBUG) Serial.println(F("__ Setup completed __"));
  Mesh24Timer t(1000);
  SD_upload();
  while(!t.isDue());
  LCD_switchState(LCD_NORMAL);
}
s\






