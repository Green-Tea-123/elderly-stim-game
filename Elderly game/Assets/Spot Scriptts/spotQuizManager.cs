using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class spotQuizManager : MonoBehaviour
{
    public List<spotQuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public UnityEngine.UI.Image QuestionTxt;

    private void Start()
    {

        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<spotAnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<spotAnswerScript>().isCorrect = true;
            }

        }

    }

    void generateQuestion() 
    {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.sprite = QnA[currentQuestion].Question;
        SetAnswers();

        

    }



}
