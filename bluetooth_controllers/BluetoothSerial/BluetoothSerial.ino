#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

#if !defined(CONFIG_BT_SPP_ENABLED)
#error Serial Bluetooth not available or not enabled. It is only available for the ESP32 chip.
#endif

BluetoothSerial SerialBT;

#define BUTTON_1 14
#define BUTTON_2 27
#define BUTTON_3 26
#define BUTTON_4 25

void setup() {
    Serial.begin(115200);
    SerialBT.begin("ESP32_Controller_1"); 
    Serial.println("The device started, now you can pair it with bluetooth!");

    pinMode(BUTTON_1, INPUT_PULLUP);
    pinMode(BUTTON_2, INPUT_PULLUP);
    pinMode(BUTTON_3, INPUT_PULLUP);
    pinMode(BUTTON_4, INPUT_PULLUP);
}

void loop() {
    String message = "";

    if (digitalRead(BUTTON_1) == LOW) message += "B1,";
    if (digitalRead(BUTTON_2) == LOW) message += "B2,";
    if (digitalRead(BUTTON_3) == LOW) message += "B3,";
    if (digitalRead(BUTTON_4) == LOW) message += "B4,";

    if (message.length() > 0) {
        SerialBT.println(message);
    }

    delay(100); 
}
