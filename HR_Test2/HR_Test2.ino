//second heartrate sketch test


volatile int diff1 = 0;
volatile int diff2 = 0;
volatile int diff3 = 0;
volatile int diff4 = 0;
volatile int diff5 = 0;
volatile int diff6 = 0;
volatile int diff7 = 0;
volatile int diff8 = 0;
volatile int diff9 = 0;
volatile int diff10 = 0;
int BPM, BPMforDisplay;
unsigned long iterationCounter;

byte oldSample, sample;
long pulsetime, lastpulsetime;



void setup() {
  Serial.begin(9600);
 
  pinMode(2, INPUT);
  Serial.println("Waiting for heart beat...");

  //Wait until a heart beat is detected  
  while (!digitalRead(2)) {};
  Serial.println ("Heart beat detected!");

}

void loop() {
/*
  sample = digitalRead(10);  //Store signal output 
  if (sample && (oldSample != sample)) {
    Serial.print("Beat: ");
    Serial.println(BPM);
    HRpulse();
  }
  oldSample = sample;           //Store last signal received
  */
//  if (animationPosition < -20){
//    animationPosition = 6;
//    BPMforDisplay = BPM;
//  }
      sample = digitalRead(2);  //Store signal output 
  if (sample && (oldSample != sample)) {
    Serial.print("Beat: ");
    Serial.println(BPM);
    HRpulse();
  }
  oldSample = sample;           //Store last signal received
  
//    if (iterationCounter % 900 == 0){
//    
//    matrix.clear();
//    matrix.setCursor(animationPosition,0);
//    matrix.print(BPMforDisplay);
//    matrix.writeDisplay();
//    //delay(100);
//    animationPosition--;
//  }
//  
// iterationCounter++; //code I could use for input?
 //Serial.println(iterationCounter % 1200);
}

void HRpulse() //looks best
{
  pulsetime = millis();
  rollBuffer();
  diff1 = pulsetime - lastpulsetime;
  if (diff10 != 0) {
    BPM = 60000 / ((diff1 + diff2 + diff3 + diff4 + diff5 + diff6 + diff7 + diff8 + diff9 + diff10)/10);
  }
  lastpulsetime = pulsetime;
}

void rollBuffer()
{
  diff10 = diff9;
  diff9 = diff8;
  diff8 = diff7;
  diff7 = diff6;
  diff6 = diff5;
  diff5 = diff4;
  diff4 = diff3;
  diff3 = diff2;
  diff2 = diff1;
  diff1 = 0;
}
