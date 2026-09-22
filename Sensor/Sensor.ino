// Pin-Definitionen 
const int analogPin = A0; // AO an A0
const int digitalPin = 8; // DO an Pin 8

void setup() {
  // Serielle Kommunikation mit 9600 Baud starten
  Serial.begin(9600); 
  
  pinMode(analogPin, INPUT);
  pinMode(digitalPin, INPUT);
}

void loop() {
  // Werte vom Sensor auslesen
  int analogValue = analogRead(analogPin);
  int digitalValue = digitalRead(digitalPin);

  // Daten über den seriellen Port senden (Format: Analog,Digital)
  Serial.print(analogValue);
  Serial.print(",");
  Serial.println(digitalValue);

  // Kurze Pause, um den seriellen Port nicht zu überlasten 
  delay(100); 
}