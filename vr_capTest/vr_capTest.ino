#include <Adafruit_NeoPixel.h>
#include <CapacitiveSensor.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif


/*
 * CapitiveSense Library Demo Sketch
 * Paul Badger 2008
 * Uses a high value resistor e.g. 10M between send pin and receive pin
 * Resistor effects sensitivity, experiment with values, 50K - 50M. Larger resistor values yield larger sensor values.
 * Receive pin is the sensor pin - try different amounts of foil/metal on this pin
 * Modified by Becky Stern 2013 to change the color of one RGB Neo Pixel based on touch input
 */


CapacitiveSensor   cs_9_10 = CapacitiveSensor(9,10);        // 10M resistor between pins 4 & 2, pin 2 is sensor pin, add a wire and or foil if desired
CapacitiveSensor   cs_9_2 = CapacitiveSensor(9,2);        // 10M resistor between pins 4 & 6, pin 6 is sensor pin, add a wire and or foil
//CapacitiveSensor   cs_4_8 = CapacitiveSensor(4,8);        // 10M resistor between pins 4 & 8, pin 8 is sensor pin, add a wire and or foil
Adafruit_NeoPixel strip = Adafruit_NeoPixel(1, 6, NEO_GRB + NEO_KHZ800);


int i = 0;

void setup()                    
{
   //cs_9_10.set_CS_AutocaL_Millis(0xFFFFFFFF);     // turn off autocalibrate on channel 1 - just as an example
   Serial.begin(9600);
    strip.begin();
    strip.show();

}

void loop()                    
{
    long start = millis();
    long total1 =  cs_9_10.capacitiveSensor(30);
    long total2 =  cs_9_2.capacitiveSensor(30);
    //long total3 =  cs_4_8.capacitiveSensor(30);

if (total1 > 30){
  //digitalWrite(7, HIGH);
  strip.setPixelColor(i, strip.Color(0,255,0));  
  strip.show();
  delay(100); 
} if (total2 >30) {
  strip.setPixelColor(i, strip.Color(0,0,255)); 
  strip.show();
  delay(100); 
}
  
    Serial.print(millis() - start);        // check on performance in milliseconds
    Serial.print("\t");                    // tab character for debug windown spacing

    Serial.print(total1);                  // print sensor output 1
    Serial.print("\t");
    Serial.println(total2);                  // print sensor output 2
    //Serial.print("\t");
    //Serial.println(total3);                // print sensor output 3

    delay(100);                             // arbitrary delay to limit data to serial port 
}

//// Create a 24 bit color value from R,G,B
//RGBPixel Color(byte r, byte g, byte b)
//{
//  RGBPixel p;
//  
//  p.red = r;
//  p.green = g;
//  p.blue = b;
//  
//  return p;
//}
