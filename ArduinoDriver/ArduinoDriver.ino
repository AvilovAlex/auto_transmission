String stringspace = String(" ");
String msg = String();
void setup() {
  pinMode(A0, INPUT);
  pinMode(10, INPUT);


   // start serial port at 9600 bps:
   Serial.begin(9600);
   while (!Serial) {
     ; // wait for serial port to connect. Needed for native USB port only
   }
 }
void loop() {
   msg = analogRead(A0) + stringspace + digitalRead(10);
   Serial.println(msg);
   delay(50);
 }

