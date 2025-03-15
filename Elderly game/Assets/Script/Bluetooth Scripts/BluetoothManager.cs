using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;

public class BluetoothManager : MonoBehaviour {

    private BluetoothHelper bluetoothHelper;

    private string deviceName;
    void Start() {
        this.deviceName = "HC-06";
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

    }

    void Update() {
        if (bluetoothHelper.Available) {
            string msg = bluetoothHelper.Read();
        }
    }

    void CloseConnection() {
        bluetoothHelper.Disconnect();
    }
}