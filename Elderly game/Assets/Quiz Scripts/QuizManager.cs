using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;
using static UnityEngine.EventSystems.PointerEventData;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    public List<QuestionBank> QnA;
    public GameObject[] options;
    public TextMeshProUGUI[] correcttxt;
    public TextMeshProUGUI[] wrongtxt;

    public TextMeshProUGUI scoretxt1;
    public TextMeshProUGUI scoretxt2;
    public GameObject scoretxtfinal1;
    public GameObject scoretxtfinal2;
    public GameObject endscreen;

    public int currentQuestion;
    public UnityEngine.UI.Image QuestionTxt;
    public TextMeshProUGUI TimerTxt;
    public int score1 = 0;
    public int score2 = 0;
    public float currentTime;
    public int timelimit = 15;
    private bool gamestatus = false;
    private bool answerstatus = true;
    public GameObject correctText;
    public GameObject wrongText;
    public GameObject continuebutton;
    public GameObject showanswerbutton;
    public int optionpickplayer2 = 0;
    public int optionpickplayer1 = 0;


    private void Awake() {
        instance = this;
    }
    private void Start()
    {

        for (int i = 0; i < options.Length; i++)
        {
            correcttxt[i].enabled = false;
            wrongtxt[i].enabled = false;
            options[i].transform.GetChild(5).GetComponent<UnityEngine.UI.Image>().enabled = false;
            options[i].transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            options[i].transform.GetChild(6).GetComponent<UnityEngine.UI.Image>().enabled = false;
            options[i].transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            //options[i].transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            //options[i].transform.GetChild(6).GetComponent<TextMeshProUGUI>().enabled = false;
            options[i].transform.GetChild(4).GetComponent<RawImage>().enabled = false;
            options[i].transform.GetChild(7).GetComponent<RawImage>().enabled = false;

        }
        generateQuestion();
        gamestatus = true;
    }


    public void correct()
    {
        int showoptiontxt = QnA[currentQuestion].CorrectAnswer - 1;
        if (QnA.Count > 0)
        {
            QnA.RemoveAt(currentQuestion);
            correcttxt[showoptiontxt].enabled = true;
            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(7).GetComponent<RawImage>().enabled = true;
            }
            options[showoptiontxt].transform.GetChild(7).GetComponent<RawImage>().enabled = false;
            options[showoptiontxt].transform.GetChild(4).GetComponent<RawImage>().enabled = true;
            if (currentTime == 0)
            {
                gamestatus = false;
                //generateQuestion();

            }
        }
        else
        {
            correcttxt[showoptiontxt].enabled = true;
            options[showoptiontxt].transform.GetChild(4).GetComponent<RawImage>().enabled = true;
            if (currentTime == 0)
            {
                gamestatus = false;
                //generateQuestion();

            }
        }
            
        //if (QnA.Count > 0 ) {
 
        //    for (int i = 0; i<options.Length; i++)
        //    {
               
          //      options[i].SetActive(false);
                

         //   }
            //Instantiate(correctText, new Vector3(options[showoptiontxt].transform.position.x, options[showoptiontxt].transform.position.y),correctText.transform.rotation);

            
        //} else {
        //   endQuiz();
        //}
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
                //Instantiate(wrongText, new Vector3(options[showoptiontxt].transform.position.x, options[showoptiontxt].transform.position.y), wrongText.transform.rotation);


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

       // if (currentTime <= 0)
       // {
        //    if (QnA.Count > 0)
        //    {
       //         //generateQuestion();
       //     }
       //     else
       //     {
      //          endQuiz();
       //     }
      //  }
    }
    void generateQuestion() 
    {
        
        gamestatus = true;
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(true);
            correcttxt[i].enabled = false;
            wrongtxt[i].enabled = false;
            options[i].transform.GetChild(4).GetComponent<RawImage>().enabled = false;
            options[i].transform.GetChild(7).GetComponent<RawImage>().enabled = false;
        }

        for (int i = 0; i < options.Length; i++) {
            options[i].transform.GetChild(5).GetComponent<UnityEngine.UI.Image>().enabled = false;
            options[i].transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            options[i].transform.GetChild(6).GetComponent<UnityEngine.UI.Image>().enabled = false;
            options[i].transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        currentTime = timelimit;
        currentQuestion = UnityEngine.Random.Range(0, QnA.Count);
        QuestionTxt.sprite = QnA[currentQuestion].Question;
        SetAnswers();
        SetTimer(currentTime);
 
       
    }
    public void continuegame()
    {
        answerstatus = true;
        continuebutton.SetActive(true);
        if (QnA.Count > 0)
        {
            generateQuestion();
        }
        else
        {
            endQuiz();
        }
            
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
    public void showanswer()
    {
        if (answerstatus == true)
        {
            showanswerbutton.SetActive(true);
            Debug.Log("player1 pick:" + optionpickplayer1);
            if (options[optionpickplayer1].GetComponent<Option>().isCorrect && options[optionpickplayer2].GetComponent<Option>().isCorrect)
            {
                correct();
                score(1);
                score(2);
                answerstatus = false;
            }
            else if (options[optionpickplayer1].GetComponent<Option>().isCorrect)
            {
                correct();
                score(1);
                answerstatus = false;
            }
            else if (options[optionpickplayer2].GetComponent<Option>().isCorrect)
            {
                correct();
                score(2);
                answerstatus = false;
            }
            else
            {
                correct();
                answerstatus = false;
            }

        }
    }
    public void playerselect(int id,int optionpick)
    {
        if (id == 1)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(5).GetComponent<UnityEngine.UI.Image>().enabled = false;
                options[i].transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
            options[optionpick].transform.GetChild(5).GetComponent<UnityEngine.UI.Image>().enabled = true;
            options[optionpick].transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            optionpickplayer1 = optionpick;
        }
        else
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(6).GetComponent<UnityEngine.UI.Image>().enabled = false;
                options[i].transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
            options[optionpick].transform.GetChild(6).GetComponent<UnityEngine.UI.Image>().enabled = true;
            options[optionpick].transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            optionpickplayer2 = optionpick;
        }
    }
    void endQuiz() {
        endscreen.SetActive(true);
        scoretxtfinal1.SetActive(true);
        scoretxtfinal2.SetActive(true);
        scoretxtfinal1.GetComponent<TextMeshProUGUI>().text = "Player 1 final score is: " + score1;
        scoretxtfinal2.GetComponent<TextMeshProUGUI>().text = "Player 2 final score is: " + score2;

        for (int i = 0; i < options.Length; i++) {
            options[i].SetActive(false);
        }
    }
}
