using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;


public class MemoryGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static MemoryGame instance;
    public int correctNo;

    [Header("Scoring panel setting ")]
    public GameObject correctAnswer;
    public GameObject wrongAnswer;
    public GameObject model3;
    public GameObject model4;
    public GameObject LeftScoller;
    public GameObject RightScoller;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        updateAnswer(correctNo);
    }

    public void updateAnswer(int correctNo)
    {
        int oneside = Random.Range(0, correctNo);
        int onesideDistraction = 2* correctNo;
        int theOtherside = correctNo- oneside;
        int theOtherSideDistraction = 3*theOtherside;
        int leftSideTotal = oneside+onesideDistraction;
        int rightSideTotal = theOtherside+ theOtherSideDistraction;
        List<int> correctCountLeft = new List<int>();
        List<int> correctCountRight = new List<int>();

        for (int i = 0; i < oneside; i++)
        {
            int a = Random.Range(0, leftSideTotal-i);
            if (correctCountLeft.Contains(a))
            {
                i--;
            }
            else
            {
                correctCountLeft.Add(a);
            }

        }

        for (int i = 0; i < theOtherside; i++)
        {
            int a = Random.Range(0, leftSideTotal - i);
            if (correctCountRight.Contains(a))
            {
                i--;
            }
            else
            {
                correctCountRight.Add(a);
            }

        }


        for (int i = 0;i < leftSideTotal; i++)
        {
            if (correctCountLeft.Contains(i))
            {
                GameObject correctobj = Instantiate(correctAnswer, new Vector3(LeftScoller.transform.position.x - 1 * i, this.transform.position.y), correctAnswer.transform.rotation);
                correctobj.transform.SetParent(LeftScoller.transform);
            }
            else
            {
                GameObject wrongObj = Instantiate(wrongAnswer, new Vector3(LeftScoller.transform.position.x - 1 * i, this.transform.position.y), correctAnswer.transform.rotation);
                wrongObj.transform.SetParent(LeftScoller.transform);
            }

        }

        for (int i = 0; i < rightSideTotal; i++)
        {
            if (correctCountLeft.Contains(i))
            {
                GameObject correctobj = Instantiate(correctAnswer, new Vector3(RightScoller.transform.position.x + 1 * i, this.transform.position.y), correctAnswer.transform.rotation);
                correctobj.transform.SetParent(RightScoller.transform);
            }
            else
            {
                GameObject wrongObj = Instantiate(wrongAnswer, new Vector3(RightScoller.transform.position.x + 1 * i, this.transform.position.y), correctAnswer.transform.rotation);
                wrongObj.transform.SetParent(RightScoller.transform);
            }
        }
    }

    
}
