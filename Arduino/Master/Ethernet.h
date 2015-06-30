byte mac[] = {
  0x90, 0xA2, 0xFA, 0x00, 0x5E, 0x7E
};
IPAddress ip(192, 168, 1, 128);
IPAddress gateway(192, 168, 1, 100);
IPAddress subnet(255, 255, 255, 0);
EthernetServer server(80);

const int HTTP_REQUEST_BUFF = 100;
const int HTTP_RESPONE_BUFF = 512;
const int REQUEST_TIME_OUT = 5000;
void always_inline Ethernet_loop() {
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

    if(completeState == 1) {
      byte charCount = 0;
      boolean isStop = false;
      while(client.connected() && (millis() - startTime) < REQUEST_TIME_OUT) {
        while(client.available()) {
          char c = client.read();
          if(c == '\n' || c == '\r') {
            charCount++;
            if(charCount >= 4) {
              completeState++;
              isStop = true;
              break;
            }
          }
          else {
            charCount = 0;
          }
        }
        if(isStop) break;
      }
    }

    char* fileName = NULL;
    if(completeState == 2) {
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

    if(completeState == 3) {
      if(DEBUG) {
        Serial.print(F("Request received. Filename: "));
        Serial.print(fileName);
      }

      File file = SD.open(fileName, FILE_READ);
      if(file) {
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
        client.println(F("<h2>File Not Found !</h2>"));
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

void always_inline Ethernet_setup() {
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
}

















