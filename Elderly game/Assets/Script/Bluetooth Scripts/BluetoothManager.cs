using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;

public class BluetoothManager : MonoBehaviour {

    private BluetoothHelper bluetoothHelper;

    private string deviceName;
    void Start() {
        this.deviceName = "ESP32_Controller_1";
        try {
            bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
            bluetoothHelper.OnConnected += OnConnected;
            bluetoothHelper.OnConnectionFailed += OnConnectionFailed;
            bluetoothHelper.setTerminatorBasedStream("\n");
            if (bluetoothHelper.isDevicePaired()) {
                bluetoothHelper.Connect();
            }
            
        } catch (System.Exception e) {
            Debug.Log("Error: " + e.Message);
        }
    }

    private void OnConnected(BluetoothHelper bluetoothHelper) {
        bluetoothHelper.StartListening();
    }

    private void OnConnectionFailed(BluetoothHelper bluetoothHelper) {
        Debug.Log("Bluetooth Connection Failed");
    }

    void Update() {
        if (bluetoothHelper.Available) {
            string msg = bluetoothHelper.Read();
            Debug.Log(msg);
        }
    }

    void CloseConnection() {
        bluetoothHelper.Disconnect();
    }
}