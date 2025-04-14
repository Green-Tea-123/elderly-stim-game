using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputManager : MonoBehaviour
{
    public static InputManager instance;


    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            SceneManager.LoadScene("Homepage");
        }
    }

    // TODO modify to return controller identity and input
    public List<BluetoothInput> getKeyDown() {
        List<string> messages = BluetoothManager.instance.checkForMessage();

        List<BluetoothInput> inputs = new List<BluetoothInput>();

        if (messages.Count == 0) {
            return null;
        }

        foreach (string message in messages) {
            string[] splitMessage = message.Split(',');
            int controllerId = int.Parse(splitMessage[0]);
            int input = int.Parse(splitMessage[1]);
            inputs.Add(new BluetoothInput(controllerId, input));
        }

        return inputs;
    }
}
