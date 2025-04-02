using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;

public class BluetoothManager : MonoBehaviour {

    public static BluetoothManager instance;

    private List<BluetoothHelper> bluetoothHelpers;

    private List<string> deviceNames;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start() {
        this.deviceNames = new List<string>() {"ESP32_Controller_1", "ESP32_Controller_2"};
        this.bluetoothHelpers = new List<BluetoothHelper>();
        for (int i = 0; i < deviceNames.Count; i++) {
            try {
                BluetoothHelper helper = BluetoothHelper.GetNewInstance(deviceNames[i]);
                helper.OnConnected += OnConnected;
                helper.OnConnectionFailed += OnConnectionFailed;
                helper.setTerminatorBasedStream("\n");
                this.bluetoothHelpers.Add(helper);

                if (helper.isDevicePaired()) {
                    helper.Connect();
                    Debug.Log("Bluetooth " + i + " connected");
                }

                

            } catch (System.Exception e) {
                Debug.Log("Error: " + e.Message);
            }
        }
    }

    private void OnConnected(BluetoothHelper bluetoothHelper) {
        bluetoothHelper.StartListening();
    }

    private void OnConnectionFailed(BluetoothHelper bluetoothHelper) {
        Debug.Log("Bluetooth Connection Failed");
    }

    // TODO modify to return controller identity and input
    public List<string> checkForMessage() {
        List<string> messages = new List<string>();
        for (int i = 0; i < bluetoothHelpers.Count; i++) {
            if (bluetoothHelpers[i] != null && bluetoothHelpers[i].Available) {
                string msg = bluetoothHelpers[i].Read();
                Debug.Log(msg);
                messages.Add(msg);
            }
        }
        return messages;
    }

    void CloseConnection() {
        for (int i = 0; i < bluetoothHelpers.Count; i++) {
            if (bluetoothHelpers[i] != null) {
                bluetoothHelpers[i].Disconnect();
            }
        }
    }
}