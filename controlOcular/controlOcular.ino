#include <LiquidCrystal.h>
#include <Servo.h> 

LiquidCrystal lcd(8,13,9,4,5,6,7);
char incoming;
int horizontal;
int vertical;
Servo myservo;
int pos = 90;
int inc = 0;
Servo myservoV;
int posV = 90;
int incV = 0;
Servo myservoMu;
int posMu = 90;
int incMu = 0;
Servo myservoMa;
int posMa = 90;
int incMa = 0;

void setup() {
  Serial.begin(9600);
//  lcd.begin(16, 2);
//  lcd.print("leyendo:");
  myservo.attach(5);
  myservoV.attach(6);
  myservoMu.attach(9);
  myservoMa.attach(10);
  
  myservo.write(pos); 
  delay(15);
  myservoV.write(posV);
  delay(15);
  myservoMu.write(posMu);
  delay(15);
  myservoMa.write(posMa);
  delay(15);
}
void loop() {
  if (Serial.available() > 0) {
      // read the incoming byte:
      incoming = (char)Serial.read();
      
      switch(incoming){
        case 'A':incV=-1;
        break;
        case 'B':incV=0;
        break;
        case 'C':incV=1;
        break;
        case 'D':inc=-1;
        break;
        case 'E':inc=0;
        break;
        case 'F':inc=1;
        break;
        
        case 'P':incMu=-1;
        break;
        case 'Q':incMu=0;
        break;
        case 'R':incMu=1;
        break;
        
        case 'T':incMa=-1;
        break;
        case 'U':incMa=0;
        break;
        case 'V':incMa=1;
        break;
      }


  }
      //horizontal
      pos = pos - inc;
      if(pos < 0) {
        pos = 0;
      }
      if(pos > 180) {
        pos = 180;
      }
      myservo.write(pos);
      delay(15);
      
      //vertical
      posV = posV + incV;
      if(posV < 0) {
        posV = 0;
      }
      if(posV > 180) {
        posV = 180;
      }
      myservoV.write(posV);
      delay(15);
      
      //muneca
      posMu = posMu - incMu;
      if(posMu < 0) {
        posMu = 0;
      }
      if(posMu > 180) {
        posMu = 180;
      }
      myservoMu.write(posMu);
      delay(15);

      //mano
      posMa = posMa - incMa;
      if(posMa < 0) {
        posMa = 0;
      }
      if(posMa > 180) {
        posMa = 180;
      }
      myservoMa.write(posMa);
      delay(15);      
      
}

