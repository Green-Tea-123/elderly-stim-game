using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.PointerEventData;

public class ButtonController_Memory : MonoBehaviour
{
    public GameObject[] options;
    public GameObject[] option2;


    // Update is called once per frame
    void Update()
    {
        List<BluetoothInput> inputs = InputManager.instance.getKeyDown();

        if (inputs != null)
        {
            foreach (BluetoothInput input in inputs)
            {
                int controllerId = input.controllerId;
                int inputButton = input.input;

                switch (controllerId)
                {
                    case 1:
                    if (options[0].activeSelf) {
                        if (options[inputButton - 1].GetComponent<Option>().isCorrect)
                        {

                          
                            MemoryGame.instance.playerselect(1, inputButton - 1);
                        }
                        else
                        {
                           
                            MemoryGame.instance.playerselect(1, inputButton - 1);

                        }
                    } else if(option2[0].activeSelf) {
                        if (option2[inputButton - 1].GetComponent<Option>().isCorrect)
                        {

                          
                            MemoryGame.instance.playerselect(1, inputButton - 1);
                        }
                        else
                        {
                           
                            MemoryGame.instance.playerselect(1, inputButton - 1);

                        }
                    }
                        // do more stuff
                        break;
                    case 2:
                    if(options[0].activeSelf) {
                        if (options[inputButton - 1].GetComponent<Option>().isCorrect)
                        {

                            MemoryGame.instance.playerselect(2, inputButton - 1);
                        }
                        else
                        {

                            MemoryGame.instance.playerselect(2, inputButton - 1);

                        }
                    } else if(option2[0].activeSelf) {
                        if (option2[inputButton - 1].GetComponent<Option>().isCorrect)
                        {

                            MemoryGame.instance.playerselect(2, inputButton - 1);
                        }
                        else
                        {

                            MemoryGame.instance.playerselect(2, inputButton - 1);

                        }
                    }
                        // do more stuff
                        break;
                }
            }
        }


        int inputIndex;
        // redundancy code for keyboard keys
        if (options[0].activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                inputIndex = 0;

            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                inputIndex = 1;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                inputIndex = 2;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                inputIndex = 3;
            }



            else
            {
                return;
            }

            if (options[inputIndex].GetComponent<Option>().isCorrect)
            {

                //QuizManager.instance.correct();
                //QuizManager.instance.score(1);
                MemoryGame.instance.playerselect(1, inputIndex);
            }
            else
            {
                //QuizManager.instance.wrong();
                MemoryGame.instance.playerselect(1, inputIndex);
            }
        }
    }
}
