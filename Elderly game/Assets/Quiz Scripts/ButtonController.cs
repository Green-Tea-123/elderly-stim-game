using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    public GameObject[] options;

    // Update is called once per frame
    void Update() {
        string input = InputManager.instance.getKeyDown();

        if (input != null) {

            int inputIndex = Int32.Parse(input) - 1;
            if (options[inputIndex].GetComponent<Option>().isCorrect) {
                
                QuizManager.instance.correct();
          
            } else {
      
                QuizManager.instance.wrong();
       
            }

        } else {
            int inputIndex;
            // redundancy code for keyboard keys
            if (Input.GetKeyDown(KeyCode.W)) {
                inputIndex = 0;
                
            } else if (Input.GetKeyDown(KeyCode.E)) {
                inputIndex = 1;
            } else if (Input.GetKeyDown(KeyCode.S)) {
                inputIndex = 2;
            } else if (Input.GetKeyDown(KeyCode.D)) {
                inputIndex = 3;
            } else {
                return;
            }

            if (options[inputIndex].GetComponent<Option>().isCorrect) {
             
                QuizManager.instance.correct();
            } else {
                QuizManager.instance.wrong();
            }
        }
    }
}
