File logFile;
Mesh24Timer logFileFlushTimer(5000);
Mesh24Timer logFileUploadTimer(1200000);

enum LogType {
  Log_MasterHeartbeat = 1, Log_ClientHeartbeat, Log_ClientTemperature, Log_ClientRealPower, Log_ClientDetailPower
};

//                    00000000001111111111222
//                    01234567890123456789012
char logFileName[] = "/logs/0000/00/00/00.log";
char logFileDir[]  = "/logs/0000/00/00/";
byte logFileTime;

void a_inline SD_openLogFile() {
  time_t t = now();
  itoa_rtl(logFileName, year(t), 9);
  itoa_rtl(logFileName, month(t), 12);
  itoa_rtl(logFileName, day(t), 15);
  if(DEBUG_LOGFILE_TIME) {
    itoa_rtl(logFileName, logFileTime = (minute(t) / DEBUG_LOGFILE_TIME) * DEBUG_LOGFILE_TIME, 18);
  }
  else
  {
    itoa_rtl(logFileName, logFileTime = hour(t), 18);
  }
  itoa_rtl(logFileDir, year(t), 9);
  itoa_rtl(logFileDir, month(t), 12);
  itoa_rtl(logFileDir, day(t), 15);
  if(!SD.exists(logFileDir)) {
    SD.mkdir(logFileDir);
    if(DEBUG) {
      Serial.print(F("Created new directory: "));
      Serial.println(logFileDir);
    }
  }
  logFileName[21] = 'u';
  logFileName[22] = 'p';
  logFile = SD.open(logFileName, FILE_WRITE);
  logFileName[21] = 'o';
  logFileName[22] = 'g';
  if(logFile) {
    if(logFile.position() == 0) logFile.println(logFileName);
    logFile.flush();
    logFile.close();
  }

  if(DEBUG) {
    if(SD.exists(logFileName)) {
      Serial.print(F("Append to exists file: "));
    }
    else {
      Serial.print(F("Created new file: "));
    }
  }
  logFile = SD.open(logFileName, FILE_WRITE);
  if(logFile && logFile.position() == 0) {
    logFile.println(logFileName);
    logFile.flush();
  }
  if(DEBUG) {
    if(logFile) {
      if(logFile.position() > 0) {
        Serial.println(logFileName);
      }
      else {
        Serial.println(logFileName);
      }
    }
    else {
      Serial.println(F("File open error"));
    }
  }
}

void a_inline SD_check() {
  byte newTime = DEBUG_LOGFILE_TIME ? minute() : hour();
  if(logFileTime != newTime && (!DEBUG_LOGFILE_TIME || (newTime % DEBUG_LOGFILE_TIME) == 0)) {
    if(logFile) logFile.close();
    SD_openLogFile();
  }
  if(logFileUploadTimer.isDue()) {

  }
}

boolean SD_findFileToUpload(File dir) {
  dir.rewindDirectory();
  for(;;) {
    File entry = dir.openNextFile();
    if (!entry) {
      return false;
    }
    if (entry.isDirectory()) {
      if(SD_findFileToUpload(entry)) {
        entry.close();
        return true;
      }
    }
    else {
      char* fileName = entry.name();
      if(fileName[3] == 'L' && fileName[4] == 'U' && fileName[5] == 'P') {
        const byte pathSize = sizeof(logFileName);
        char fileToUpload[pathSize];
        if(entry.read(fileToUpload, pathSize) == pathSize) {
          fileToUpload[pathSize - 1] = '\0';
          if(strcmp(fileToUpload, logFileName) != 0) {
            if(DEBUG) {
              Serial.print(F("Found file to upload: "));
              Serial.println(fileToUpload);
            }
            if(FTP_transfer(fileToUpload)) {
              fileToUpload[16] = '/';
              fileToUpload[21] = 'u';
              fileToUpload[22] = 'p';
              File lup = SD.open(fileToUpload, FILE_WRITE);
              lup.remove();
              lup.close();
              if(DEBUG) Serial.println(F("Upload successfully. Deleted LUP file"));
            }
            entry.close();
            return true;
          }
        }
        else {
          entry.close();
          if(DEBUG) Serial.println(F("LUP file strange error"));
        }
      }
    }
    entry.close();
  }
  return false;
}

void a_inline SD_upload() {
  File dir = SD.open("/logs");
  if(dir) {
    SD_findFileToUpload(dir);
    dir.close();
  }
}

void a_inline SD_checkUpload() {
  if(logFileUploadTimer.isDue()) {
    SD_upload();
  }
}

void a_inline SD_logBegin(byte logType) {
  SD_check();
  time_t t = now();
  //                012345
  char timeStr[] = "00:00,";
  itoa_rtl(timeStr, minute(t), 1);
  itoa_rtl(timeStr, second(t), 4);
  logFile.write((byte*)timeStr, sizeof(timeStr) - 1);
  logFile.print(logType);
  logFile.write(',');
}

template <class T>
void a_inline SD_logData(T& data) {
  logFile.print(data);
  logFile.write(',');
}

template <class T>
void a_inline SD_logData(T& data, int div) {
  logFile.print((float)data / div);
  logFile.write(',');
}

void a_inline SD_logEndRecord() {
  logFile.write('\n');
  if(logFileFlushTimer.isDue()) {
    logFile.flush();
  }
  SD_check();
}

boolean a_inline SD_setup() {
  if(DEBUG) Serial.println(F("__ SD Setup __"));
  boolean result = SD.begin(CS_SD_CARD);
  if(DEBUG) {
    if (result) {
      Serial.println(F("Initialization done"));
      Serial.print(F("Delete logs? "));
      for(byte i = 0; i < 5; i++) {
        Serial.print(".");
        delay(200);
      }
      Serial.println();
      if(Serial.available() && Serial.read() == 'Y') {
        File dir = SD.open("/logs");
        if(dir && dir.rmRfStar()) {
          Serial.println(F("Deleted log"));
        }
        else {
          Serial.println(F("Delete log failed"));
        }
      }
      Serial.flush();
    }
    else {
      Serial.println(F("Initialization failed"));
    }
  }
  return result;
}

void printDirectory(EthernetClient client, File dir, int numTabs) {
  dir.rewindDirectory();
  for(;;) {
    File entry = dir.openNextFile();
    if (!entry) {
      break;
    }
    for (byte i = 0; i < numTabs; i++) {
      client.write('\t');
    }
    client.print(entry.name());
    if (entry.isDirectory()) {
      client.println('/');
      printDirectory(client, entry, numTabs + 1);
    }
    else {
      client.print(F(" >>SIZE<<"));
      client.print(entry.size());
      client.println(F(">>"));
    }
    entry.close();
  }
}

void a_inline printDirectory(EthernetClient client, File dir) {
  client.println(F(">>BEGIN<<"));
  printDirectory(client, dir, 0);
  client.println(F(">>END<<"));
}























