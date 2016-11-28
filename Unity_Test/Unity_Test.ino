//int count = 1000;
const int analogInPin = A0;

int sensorValue = 0;        // value read from the pot


 void setup() {
   // put your setup code here, to run once:
   Serial.begin(9600);
 }
 
 void loop() {

 // read the analog in value:
  sensorValue = analogRead(analogInPin);

  // change the analog out value:
//  analogWrite(analogOutPin, outputValue);

  // print the results to the serial monitor:
//  Serial.print("sensor = ");
  Serial.println(sensorValue);

  // wait 2 milliseconds before the next loop
  // for the analog-to-digital converter to settle
  // after the last reading:
  delay(500);

 }
