using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public spotQuizManager spotquizManager;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            spotquizManager.correct();
        }

        else
        {
            Debug.Log("Wrong Answer");
            spotquizManager.correct();
        }
    }





}
