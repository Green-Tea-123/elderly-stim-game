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

volatile bool button1Flag = false;
volatile bool button2Flag = false;
volatile bool button3Flag = false;
volatile bool button4Flag = false;

unsigned long lastDebounceTime1 = 0;
unsigned long lastDebounceTime2 = 0;
unsigned long lastDebounceTime3 = 0;
unsigned long lastDebounceTime4 = 0;
const unsigned long debounceDelay = 200;


void IRAM_ATTR button1_ISR() { button1Flag = true; }
void IRAM_ATTR button2_ISR() { button2Flag = true; }
void IRAM_ATTR button3_ISR() { button3Flag = true; }
void IRAM_ATTR button4_ISR() { button4Flag = true; }

void setup() {
    Serial.begin(115200);
    SerialBT.begin("ESP32_Controller_1"); 
    Serial.println("The device started, now you can pair it with bluetooth!");

    pinMode(BUTTON_1, INPUT_PULLUP);
    pinMode(BUTTON_2, INPUT_PULLUP);
    pinMode(BUTTON_3, INPUT_PULLUP);
    pinMode(BUTTON_4, INPUT_PULLUP);

    attachInterrupt(digitalPinToInterrupt(BUTTON_1), button1_ISR, FALLING);
    attachInterrupt(digitalPinToInterrupt(BUTTON_2), button2_ISR, FALLING);
    attachInterrupt(digitalPinToInterrupt(BUTTON_3), button3_ISR, FALLING);
    attachInterrupt(digitalPinToInterrupt(BUTTON_4), button4_ISR, FALLING);
}

void loop() {
    String message = "";

    if (button1Flag) {
        if (millis() - lastDebounceTime1 > debounceDelay) {
            lastDebounceTime1 = millis();
            SerialBT.println('1');
        }
        button1Flag = false;
    }

    if (button2Flag) {
        if (millis() - lastDebounceTime2 > debounceDelay) {
            lastDebounceTime2 = millis();
            SerialBT.println('2');
        }
        button2Flag = false;
    }

    if (button3Flag) {
        if (millis() - lastDebounceTime3 > debounceDelay) {
            lastDebounceTime3 = millis();
            SerialBT.println('3');
        }
        button3Flag = false;
    }

    if (button4Flag) {
        if (millis() - lastDebounceTime4 > debounceDelay) {
            lastDebounceTime4 = millis();
            SerialBT.println('4');
        }
        button4Flag = false;
    }
}
