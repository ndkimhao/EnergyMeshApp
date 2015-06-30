EthernetClient ftpClient;
EthernetClient ftpDataClient;

const int FTP_RCV_TIMEOUT = 5000;
const int FTP_UPLOAD_BUFF = 512;
const int FTP_CONNECT_TIMEOUT = 3000;
IPAddress ftpServerIp(192, 168, 1, 104);

void FTP_fail()
{
  byte thisByte = 0;
  ftpClient.println(F("QUIT"));

  unsigned long startTime = millis();
  while(ftpClient.connected() && !ftpClient.available()) {
    if((millis() - startTime) > FTP_RCV_TIMEOUT) {
      ftpClient.stop();
      ftpDataClient.stop();
      if(DEBUG) Serial.println(F("FTP Fail. Command timeout"));
      return;
    }
  }

  while(ftpClient.available())
  {
    thisByte = ftpClient.read();
    if(DEBUG) Serial.write(thisByte);
  }

  ftpClient.stop();
  ftpDataClient.stop();
  if(DEBUG) Serial.println(F("FTP Fail. Disconnected"));
}

boolean FTP_rcvResp(int* port = NULL, char apceptabeCode = -1)
{
  byte respCode;
  byte thisByte;

  unsigned long startTime = millis();
  while(ftpClient.connected() && !ftpClient.available()) {
    if((millis() - startTime) > FTP_RCV_TIMEOUT) {
      if(DEBUG) Serial.println(F("FTP Fail. Command timeout"));
      return false;
    }
  }

  respCode = ftpClient.peek();
  if(port == NULL) {
    unsigned long startTime = millis();
    while(ftpClient.available() && ftpClient.connected() && (millis() - startTime) < FTP_RCV_TIMEOUT)
    {
      thisByte = ftpClient.read();
      if(DEBUG) Serial.write(thisByte);
    }
  }
  else {
    byte charCount = 0, prevCharCount = 0;
    unsigned int num = 0;
    unsigned int highByte = 0xFFFF, lowByte = 0xFFFF;
    unsigned long startTime = millis();
    while(ftpClient.available() && ftpClient.connected() && (millis() - startTime) < FTP_RCV_TIMEOUT)
    {
      thisByte = ftpClient.read();
      if(DEBUG) Serial.write(thisByte);
      if(thisByte == ',' || thisByte == '(' || thisByte == ')') {
        charCount++;
        if(prevCharCount == 5 || charCount == 6) {
          highByte = num;
          num = 0;
        }
        else if(prevCharCount == 6 || charCount == 7) {
          lowByte = num;
        }
        prevCharCount = charCount;
      }
      else if(charCount == 5 || charCount == 6) {
        num *= 10;
        num += thisByte - '0';
      }
    }
    if(highByte <= 0xFF && lowByte <= 0xFF) {
      *port = highByte << 8 | lowByte;
    }
    else {
      if(DEBUG) Serial.println(F("FTP fail. Bad PASV Answer"));
      FTP_fail();
      return false;
    }
  }

  if(!ftpClient.connected() || (respCode != apceptabeCode && respCode >= '4'))
  {
    FTP_fail();
    return false;
  }

  return true;
}

boolean FTP_transfer(char* fileName) {
  if (ftpClient.connect(ftpServerIp, 21, FTP_CONNECT_TIMEOUT)) {
    Serial.println(F("_/*\\_ FTP server connected"));
  }
  else {
    Serial.println(F("FTP server connect failed"));
    return false;
  }

  if(!FTP_rcvResp()) return false;
  ftpClient.println(F("USER house_1"));
  if(!FTP_rcvResp()) return false;
  ftpClient.println(F("PASS 123456"));
  if(!FTP_rcvResp()) return false;
  ftpClient.println(F("SYST"));
  if(!FTP_rcvResp()) return false;
  ftpClient.println(F("Type I"));
  if(!FTP_rcvResp()) return false;
  ftpClient.println(F("CWD /"));
  if(!FTP_rcvResp()) return false;
  ftpClient.println(F("PASV"));
  int port;
  if(!FTP_rcvResp(&port)) return false;

  if(DEBUG) {
    Serial.print(F("Data port: "));
    Serial.println(port);
  }

  if (ftpDataClient.connect(ftpServerIp, port, FTP_CONNECT_TIMEOUT)) {
    if(DEBUG) Serial.println(F("Data connected"));
  }
  else {
    if(DEBUG) Serial.println(F("Data connect failed"));
    ftpClient.stop();
    ftpDataClient.stop();
    return false;
  }

  File file = SD.open(fileName, FILE_READ);
  if(!file) {
    ftpClient.stop();
    ftpDataClient.stop();
    if(DEBUG) Serial.println("File open error");
    return false;
  }

  for(int i = strlen(fileName) - 1; i > 1; i--) {
    if(fileName[i] == '/') {
      fileName[i] = '\0';
      break;
    }
  }

  ftpClient.print(F("MKD "));
  ftpClient.println(fileName);
  if(!FTP_rcvResp(NULL, '5')) {
    file.close();
    return false;
  }

  ftpClient.print(F("CWD "));
  ftpClient.println(fileName);
  if(!FTP_rcvResp()) {
    file.close();
    return false;
  }

  ftpClient.print(F("STOR "));
  ftpClient.println(file.name());
  if(!FTP_rcvResp()) {
    file.close();
    return false;
  }

  if(DEBUG) Serial.println(F("Uploading data"));
  byte buff[FTP_UPLOAD_BUFF];
  int buffCount;
  while(file.available())
  {
    if((buffCount = file.read(buff, FTP_UPLOAD_BUFF)) == 0) break;
    if(ftpDataClient.write(buff, buffCount) == 0) break;
  }
  if(DEBUG) Serial.println(F("Uploaded data"));
  file.close();

  ftpDataClient.stop();
  if(DEBUG) Serial.println(F("Data disconnected"));

  ftpClient.println(F("QUIT"));
  ftpClient.stop();
  Serial.println(F("FTP server disconnected"));

  if(DEBUG) {
    int freeRam = freeMemory();
    Serial.print(F("Free RAM: "));
    Serial.print(freeRam);
    Serial.print(F(" - Used RAM: "));
    Serial.println(RAM_SIZE - freeRam);
  }

  return true;
}

















