using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    public List<QuestionsAndAnswers> QnA = QuestionBank.generateQuestions();
    public GameObject[] options;
    public TextMeshProUGUI[] correcttxt;
    public TextMeshProUGUI[] wrongtxt;
  
    public int currentQuestion;
    public Text QuestionTxt;
    public TextMeshProUGUI TimerTxt;
    public int score = 0;
    public float currentTime;
    public int timelimit = 15;
    private bool gamestatus = false;
    public GameObject correctText;
    public GameObject wrongText;
    private void Awake() {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < options.Length; i++)
        {
            correcttxt[i].enabled = false;
            wrongtxt[i].enabled = false;
        }
        generateQuestion();
        gamestatus = true;
    }


    public void correct()
    {
        int showoptiontxt = QnA[currentQuestion].CorrectAnswer - 1;
        score++;
        QnA.RemoveAt(currentQuestion);
        if (QnA.Count > 0 ) {
 
            for (int i = 0; i<options.Length; i++)
            {
               
                options[i].SetActive(false);
                

            }
            Instantiate(correctText, new Vector3(options[showoptiontxt].transform.position.x, options[showoptiontxt].transform.position.y),correctText.transform.rotation);
            correcttxt[showoptiontxt].enabled = true;
            if (currentTime == 0){
                gamestatus = false;
                generateQuestion();

            }
            
        } else {
            endQuiz();
        }
    }

    public void wrong()
    {
        int showoptiontxt = QnA[currentQuestion].CorrectAnswer - 1;
        score++;
        QnA.RemoveAt(currentQuestion);
        if (QnA.Count > 0)
        {

            for (int i = 0; i < options.Length; i++)
            {

                options[i].SetActive(false);
                Instantiate(wrongText, new Vector3(options[showoptiontxt].transform.position.x, options[showoptiontxt].transform.position.y), wrongText.transform.rotation);


            }
            wrongtxt[showoptiontxt].enabled = true;
            if (currentTime == 0)
            {
                gamestatus = false;
                generateQuestion();

            }

        }
        else
        {
            endQuiz();
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Option>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Option>().isCorrect = true;

            }

        }

    }
    private void SetTimer(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(value);
        TimerTxt.text = "Time:" + time.ToString("ss");

        if (currentTime <= 0)
        {
            if (QnA.Count > 0)
            {
                generateQuestion();
            }
            else
            {
                endQuiz();
            }
        }
    }
    void generateQuestion() 
    {
     
        gamestatus = true;
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(true);
        }
        currentTime = timelimit;
        currentQuestion = UnityEngine.Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
        SetTimer(currentTime);
 
       
    }

    private void Update()
    {
        if(gamestatus == true)
        {
            currentTime -= Time.deltaTime;
            SetTimer(currentTime);
        }
    }

    void endQuiz() {
        QuestionTxt.text = "Your final score is: " + score;
        for (int i = 0; i < options.Length; i++) {
            options[i].SetActive(false);
        }
    }
}
