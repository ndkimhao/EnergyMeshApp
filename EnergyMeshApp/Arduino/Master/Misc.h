const byte CS_SD_CARD = 4;
const byte CS_ETHERNET = 10;
const byte CE_RF24 = 49;
const byte CS_RF24 = 53;
const byte LED_RF_RX = 13;

const int RAM_SIZE = 8192;

void a_inline printTime() {
  time_t t = now();
  Serial.print(hour(t));
  Serial.print(':');
  Serial.print(minute(t));
  Serial.print(':');
  Serial.print(second(t));
  Serial.print(' ');
  Serial.print(day(t));
  Serial.print('/');
  Serial.print(month(t));
  Serial.print('/');
  Serial.print(year(t));
}

boolean a_inline RTC_setup() {
  if(DEBUG) Serial.println(F("__ RTC Setup __"));
  setSyncProvider(RTC.get);
  if(DEBUG) {
    if(timeStatus() != timeSet) {
      Serial.println(F("Unable to sync with the RTC"));
    }
    else {
      Serial.print(F("RTC has set the system time: "));
      printTime();
      Serial.println();
      Serial.print(F("Change system time (h,m,s,d,m,yy,): "));
      for(byte i = 0; i < 5; i++) {
        Serial.print(".");
        delay(200);
      }
      if(Serial.available() >= 12) {
        tmElements_t tm;
        time_t t;

        tm.Hour = Serial.parseInt();
        tm.Minute = Serial.parseInt();
        tm.Second = Serial.parseInt();

        tm.Day = Serial.parseInt();
        tm.Month = Serial.parseInt();
        int iYear = Serial.parseInt();
        if (iYear >= 1000)
          tm.Year = CalendarYrToTm(iYear);
        else if (iYear < 100)
          tm.Year = y2kYearToTm(iYear);
        else
          tm.Year = year();

        if(tm.Year > 2020) {
          Serial.println();
          Serial.print(F("Invalid year. Time not set"));
        } else {
          t = makeTime(tm);
          RTC.set(t);
          setTime(t);
  
          Serial.println();
          Serial.print(F("RTC set to: "));
          printTime();
        }
      }
      Serial.println();
      if(Serial.available()) Serial.flush();
    }
  }
  return timeStatus() == timeSet;
}

void a_inline IO_setup() {
  pinMode(CS_SD_CARD, OUTPUT);
  pinMode(CS_ETHERNET, OUTPUT);
  pinMode(CS_RF24, OUTPUT);
  pinMode(LED_RF_RX, OUTPUT);
  digitalWrite(CS_SD_CARD, HIGH);
  digitalWrite(CS_ETHERNET, HIGH);
  digitalWrite(CS_RF24, HIGH);
  digitalWrite(LED_RF_RX, LOW);
}

void a_inline itoa_rtl(char* str, int num, byte pos)
{
  if (num <= 0) return;
  if(num < 10) {
    str[pos] = num + '0';
  }
  else if(num < 100 && pos >= 1) {
    str[pos] = (num % 10) + '0';
    str[pos - 1] = (num / 10) + '0';
  }
  else if(num < 1000 && pos >= 2) {
    str[pos] = (num % 10) + '0';
    num /= 10;
    str[pos - 1] = (num % 10) + '0';
    str[pos - 2] = (num / 10) + '0';
  }
  else if(num < 10000 && pos >= 3) {
    str[pos] = (num % 10) + '0';
    num /= 10;
    str[pos - 1] = (num % 10) + '0';
    num /= 10;
    str[pos - 2] = (num % 10) + '0';
    str[pos - 3] = (num / 10) + '0';
  }
}

unsigned int a_inline readVcc() {
  unsigned int result;
  // Read 1.1V reference against AVcc
  ADMUX = _BV(REFS0) | _BV(MUX4) | _BV(MUX3) | _BV(MUX2) | _BV(MUX1);
  delay(2); // Wait for Vref to settle
  ADCSRA |= _BV(ADSC); // Convert
  while (bit_is_set(ADCSRA,ADSC));
  result = ADCL;
  result |= ADCH<<8;
  result = 1126400L / result; // Back-calculate AVcc in mV
  return result;
}

extern unsigned int __heap_start;
extern void *__brkval;
struct __freelist
{
  size_t sz;
  struct __freelist *nx;
};
extern struct __freelist *__flp;
int freeListSize()
{
  struct __freelist* current;
  int total = 0;
  for (current = __flp; current; current = current->nx)
  {
    total += 2; /* Add two bytes for the memory block's header  */
    total += (int) current->sz;
  }

  return total;
}
int freeMemory()
{
  int free_memory;
  if ((int)__brkval == 0)
  {
    free_memory = ((int)&free_memory) - ((int)&__heap_start);
  }
  else
  {
    free_memory = ((int)&free_memory) - ((int)__brkval);
    free_memory += freeListSize();
  }
  return free_memory;
}










