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
    public List<QuestionBank> QnA;
    public GameObject[] options;
    public TextMeshProUGUI[] correcttxt;
    public TextMeshProUGUI[] wrongtxt;
    public TextMeshProUGUI scoretxt1;
    public TextMeshProUGUI scoretxt2;
    public TextMeshProUGUI scoretxtfinal1;
    public TextMeshProUGUI scoretxtfinal2;

    public int currentQuestion;
    public UnityEngine.UI.Image QuestionTxt;
    public TextMeshProUGUI TimerTxt;
    public int score1 = 0;
    public int score2 = 0;
    public float currentTime;
    public int timelimit = 15;
    private bool gamestatus = false;
    public GameObject correctText;
    public GameObject wrongText;
    public GameObject continuebutton;
    
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
                //generateQuestion();

            }
            
        } else {
            endQuiz();
        }
    }

    public void score(int id)
    {
        if (id == 1)
        {
            score1++;
        }
        else
        {
            score2++;
        }
    }
    public void wrong()
    {
        int showoptiontxt = QnA[currentQuestion].CorrectAnswer - 1;
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
                //generateQuestion();

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
            options[i].transform.GetChild(3).GetComponent<UnityEngine.UI.Image>().sprite = QnA[currentQuestion].Answers[i];

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
                //generateQuestion();
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
        QuestionTxt.sprite = QnA[currentQuestion].Question;
        SetAnswers();
        SetTimer(currentTime);
 
       
    }
    public void continuegame()
    {
        continuebutton.SetActive(true);
        generateQuestion();
    }

    private void Update()
    {
        if(gamestatus == true)
        {
            currentTime -= Time.deltaTime;
            SetTimer(currentTime);
            scoretxt1.text = "Player 1 score:" + score1;
            scoretxt2.text = "Player 2 score:" + score2;
        }
    }

    void endQuiz() {
        scoretxtfinal1.text = "Player 1 final score is: " + score1;
        scoretxtfinal2.text = "Player 2 final score is: " + score2;

        for (int i = 0; i < options.Length; i++) {
            options[i].SetActive(false);
        }
    }
}
