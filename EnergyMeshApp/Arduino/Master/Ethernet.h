byte mac[] = {
  0x90, 0xA2, 0xFA, 0x00, 0x5E, 0x7E
};
IPAddress ip(192, 168, 1, 128);
IPAddress gateway(192, 168, 1, 100);
IPAddress subnet(255, 255, 255, 0);
EthernetServer server(80);

// "EnergyMesh:kh2015"
const char authorizeData[] PROGMEM = "RW5lcmd5TWVzaDpraDIwMTU=";

const int HTTP_REQUEST_BUFF = 100;
const int HTTP_AUTHORIZE_BUFF = 50;
const int HTTP_RESPONE_BUFF = 512;
const int REQUEST_TIME_OUT = 5000;
void a_inline Ethernet_loop() {
  EthernetClient client = server.available();
  if (client) {
    if(DEBUG) {
      Serial.print(F("_/*\\_ New client connected: "));
      IPAddress ip = client.remoteIP();
      Serial.print(ip[0]);
      Serial.print('.');
      Serial.print(ip[1]);
      Serial.print('.');
      Serial.print(ip[2]);
      Serial.print('.');
      Serial.println(ip[3]);
    }

    char clientRequest[HTTP_REQUEST_BUFF];
    int index = 0;
    byte completeState = 0;
    unsigned long startTime = millis();

    while (client.connected() && (millis() - startTime) < REQUEST_TIME_OUT) {
      if (client.available()) {
        char c = client.read();
        if (c != '\n' && c != '\r') {
          clientRequest[index] = c;
          if(index < HTTP_REQUEST_BUFF-1) index++;
        }
        else {
          clientRequest[index] = '\0';
          completeState++;
          break;
        }
      }
    }

    boolean isEndHeader = false;
    if(completeState == 1) {
      char* authStr = PSTR("Authorization: Basic ");
      const byte authStrLen = 21;
      index = 0;
      byte charCount = 0;
      byte authStrIndex = 0;
      while (client.connected() && (millis() - startTime) < REQUEST_TIME_OUT) {
        if (client.available()) {
          char c = client.read();
          if(c == '\n' || c == '\r') {
            charCount++;
            if(charCount >= 4) {
              isEndHeader = true;
              break;
            }
          }
          else {
            charCount = 0;
          }
          if(c == (char)pgm_read_byte(&authStr[authStrIndex])) {
            authStrIndex++;
            if(authStrIndex == authStrLen) {
              completeState++;
              break;
            }
          }
          else {
            authStrIndex = 0;
          }
        }
      }
    }

    {
      char clientAuthorize[HTTP_AUTHORIZE_BUFF];
      if(completeState == 2) {
        index = 0;
        while (client.connected() && (millis() - startTime) < REQUEST_TIME_OUT) {
          char c = client.read();
          if (c != '\n' && c != '\r') {
            clientAuthorize[index] = c;
            if(index < HTTP_AUTHORIZE_BUFF-1) index++;
          }
          else {
            clientAuthorize[index] = '\0';
            completeState++;
            break;
          }
        }
      }
      if(completeState == 3) {
        if(strcmp_P(clientAuthorize, authorizeData) == 0) {
          completeState++;
          if(DEBUG) Serial.println(F("Authorize successfully"));
        }
      }
    }

    if(completeState <= 3) {
      if(DEBUG) Serial.println(F("Authorize failed"));
      client.println(F("HTTP/1.1 401 Unauthorized"));
      client.println(F("WWW-Authenticate: Basic realm=\"EnergyMesh-KimHao\""));
      client.println(F("Content-Type: text/html\r\n"));
      client.println(F("<h2>401 Not Authorized</h2>"));
    }

    if(completeState == 4 && isEndHeader) completeState++;
    if(completeState == 4) {
      byte charCount = 0;
      while(client.connected() && (millis() - startTime) < REQUEST_TIME_OUT) {
        char c = client.read();
        if(c == '\n' || c == '\r') {
          charCount++;
          if(charCount >= 4) {
            completeState++;
            break;
          }
        }
        else {
          charCount = 0;
        }
      }
    }

    char* fileName = NULL;
    if(completeState == 5) {
      if(strstr_P(clientRequest, PSTR("GET "))) {
        completeState++;
        fileName = clientRequest + 4;
        (strstr_P(clientRequest, PSTR(" HTTP")))[0] = 0;
      }
      else if(DEBUG) {
        clientRequest[4] = '\0';
        Serial.print(F("Wrong method: "));
        Serial.println(clientRequest);
      }
    }

    if(completeState == 6) {
      if(DEBUG) {
        Serial.print(F("Request received. Filename: "));
        Serial.print(fileName);
      }

      File file;
      boolean isReqPowerInfo = false;
      boolean isReqInfo = false;
      if(strcmp_P(fileName, PSTR("/realtime/data-power.json")) == 0) {
        isReqPowerInfo = true;
      }
      else if(strcmp_P(fileName, PSTR("/realtime/data.json")) == 0) {
        isReqInfo = true;
      }
      else {
        file = SD.open(fileName, FILE_READ);
      }
      if(isReqPowerInfo) {
        client.println(F("HTTP/1.1 200 OK"));
        client.println(F("Content-Type: application/json\r\n"));
        client.print(F("["));
        const byte commaTo = NUM_SENSOR - 1;
        for(byte i = 0; i < NUM_SENSOR; i++) {
          client.print(LCD_powerVal[i]);
          if(i < commaTo) {
            client.print(F(","));
          }
        }
        client.print(F("]"));
        if(DEBUG) Serial.println(F(". Served realtime power data"));
      }
      else if (isReqInfo) {
        client.println(F("HTTP/1.1 200 OK"));
        client.println(F("Content-Type: application/json\r\n"));
        client.print(F("["));
        const byte commaTo = NUM_SENSOR - 1;
        for(byte i = 0; i < NUM_SENSOR; i++) {
          client.print(F("{\"power\":"));
          client.print(LCD_powerVal[i]);
          client.print(F(",\"current\":"));
          client.print(LCD_currentVal[i]);
          client.print(F(",\"voltage\":"));
          client.print(LCD_voltageVal[i]);
          client.print(F(",\"temp\":"));
          client.print(LCD_tempVal[i]);
          if(i < commaTo) {
            client.print(F("},"));
          }
          else {
            client.print(F("}"));
          }
        }
        client.print(F("]"));
        if(DEBUG) Serial.println(F(". Served realtime data"));
      }
      else if(file) {
        if(file.isDirectory()) {
          client.println(F("HTTP/1.1 200 OK"));
          client.println(F("Content-Type: text/html\r\n"));
          client.println(F("<h2>Directory files:</h2><pre>"));
          printDirectory(client, file);
          client.println(F("</pre>"));
          if(DEBUG) Serial.println(F(". Served directory list"));
        }
        else {
          client.println(F("HTTP/1.1 200 OK"));
          client.println(F("Accept-Ranges: none"));
          client.print(F("Content-Length: "));
          client.println(file.size());
          client.print(F("Content-Disposition: filename="));
          client.println(file.name());
          //client.println(F("Content-Type: application/octet-stream\r\n"));
          client.println(F("Content-Type: text/css\r\n"));
          byte respBuff[HTTP_RESPONE_BUFF];
          int buffCount;
          while(file.available()) {
            if((buffCount = file.read(respBuff, HTTP_RESPONE_BUFF)) == 0) break;
            if(client.write(respBuff, buffCount) == 0) break;
          }
          if(DEBUG) Serial.println(F(". Served file download"));
        }
        file.close();
      }
      else {
        client.println(F("HTTP/1.1 404 Not Found"));
        client.println(F("Content-Type: text/html\r\n"));
        client.println(F("<h2>404 File Not Found !</h2>"));
        if(DEBUG) Serial.println(F(". File Not Found"));
      }

      delay(1);
    }
    else {
      if(DEBUG) Serial.println(F("Command receive failed. Stop"));
    }

    if(client.connected()) {
      client.stop();
      if(DEBUG) Serial.println(F("Disconnected client"));
    }
    else if(DEBUG) Serial.println(F("Client disconnected"));

    if(DEBUG) {
      int freeRam = freeMemory();
      Serial.print(F("Free RAM: "));
      Serial.print(freeRam);
      Serial.print(F(" - Used RAM: "));
      Serial.println(RAM_SIZE - freeRam);
    }
  }
}

boolean a_inline Ethernet_setup() {
  if(DEBUG) {
    Serial.println(F("__ Ethernet Setup __"));
    int freeRam = freeMemory();
    Serial.print(F("Free RAM: "));
    Serial.print(freeRam);
    Serial.print(F(" - Used RAM: "));
    Serial.println(RAM_SIZE - freeRam);
  }

  Ethernet.begin(mac, ip, gateway, gateway, subnet);
  server.begin();
  if(DEBUG) {
    Serial.print(F("Server is at "));
    Serial.println(Ethernet.localIP());
  }

  return Ethernet.localIP()[0] == 192;
}




























