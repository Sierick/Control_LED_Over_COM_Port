void setup() {
  pinMode(13, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  int num;
  while (!Serial.available()){}
  while (Serial.available()){
    delay(30);
    if (Serial.available() > 0){
      num = Serial.parseInt();
      Serial.read();
      if (num == 1){
        Serial.print("1");
        digitalWrite(13, HIGH);
        num = 0;
      } if (num == 2){
        Serial.print("2");
        digitalWrite(13, LOW);
        num = 0;
      } if (num != 0 && num != 1 && num != 2) {
        Serial.print(num);
      }
    }
  }
}
