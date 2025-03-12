using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA = QuestionBank.generateQuestions();
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;
    public int score = 0;

    private void Start()
    {

        generateQuestion();
    }

    public void correct()
    {
        score++;
        QnA.RemoveAt(currentQuestion);
        if (QnA.Count > 0) {
            generateQuestion();
        } else {
            endQuiz();
        }
    }

    public void wrong() {
        QnA.RemoveAt(currentQuestion);
        if (QnA.Count > 0) {
            generateQuestion();
        } else {
            endQuiz();
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }

        }

    }

    void generateQuestion() 
    {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }

    void endQuiz() {
        QuestionTxt.text = "Your final score is: " + score;
        for (int i = 0; i < options.Length; i++) {
            options[i].SetActive(false);
        }
    }
}
