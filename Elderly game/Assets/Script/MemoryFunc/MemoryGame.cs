using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;



public class MemoryGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static MemoryGame instance;
    public int correctNo;
    [Header("Game settings")]
    public float xMin = 4;
    public float xMax = 20;
    public float yMin = 1;
    public float yMax = -3;

    public float speed = 60;
    public List<float> yaxis = new List<float>();
    public List<float> xaxis = new List<float>();
    public int destoriedCount;
    public bool isQnUpdated;

    public bool isCoop;
    public int optionpickplayer1;
    public int optionpickplayer2;
    public GameObject qnPanel;
    public GameObject qnPanel2;
    public bool qnGenerated = false;

    [Header("Animal prefebs")]
    public GameObject dog;
    public GameObject cat;
    public GameObject chick;
    public GameObject cow;
    public GameObject donkey;
    public GameObject duck;
    public GameObject elephant;
    public GameObject frog;
    public GameObject goat;
    public GameObject lilpok;
    public GameObject lion;
    public GameObject monkey;
    public GameObject pig;
    public GameObject rooster;
    public GameObject sheep;
    public static Dictionary<string, string> names = new Dictionary<string, string>(){
    {"C", "cat"},
    {"Q", "chicken"},
    {"N", "cow"},
    {"D", "dog"},
    {"F", "donkey"},
    {"X", "duck"},
    {"E", "elephant"},
    {"H", "frog"},
    {"G", "goat"},
    {"L", "chick"},
    {"S", "lion"},
    {"M", "monkey"},
    {"P", "pig"},
    {"R", "rooster"},
    {"V", "sheep"}
    };
    public static List<string> keyList = new List<string>(names.Keys);

    public static Dictionary<string, string> prefebDict = new Dictionary<string, string>(){
    {"C", "Cat"},
    {"Q", "Chick"},
    {"N", "Cow"},
    {"D", "Dog"},
    {"F", "Donkey"},
    {"X", "Duck"},
    {"E", "Elephant"},
    {"H", "Frog"},
    {"G", "Goat"},
    {"L", "Lilpok"},
    {"S", "Lion"},
    {"M", "Monkey"},
    {"P", "Pig"},
    {"R", "Rooster"},
    {"V", "Sheep"}
    };

    public static Dictionary<char, int> appearing = new Dictionary<char, int>()
    {
    };

    public static List<List<int>> qntype = new List<List<int>>();

    [Header("UIUX")]
    public GameObject quizpage;
    public GameObject qns;
    public GameObject qnSprite;
    public GameObject[] options;
    public GameObject[] option2;





    public string lvlset;
    void Awake()
    {
        instance = this;
        for (int i = 0; i < lvlset.Length; i++)
        {
            yaxis.Add(UnityEngine.Random.Range(yMin, yMax));
            xaxis.Add(UnityEngine.Random.Range(0, 2));
        }
        for (int i = 0; i < 3; i++)
        {
            List<int> qn = new List<int>();
            /*qn.Add(UnityEngine.Random.Range(1, 4));
            qn.Add((UnityEngine.Random.Range(1, 4)));*/
            qn.Add(2);
            qn.Add(2);
            qntype.Add(qn);
        }

    }

    void Start()
    {
        initiateAnimals(lvlset);
        countOccurances(lvlset);
    }

    // Update is called once per frame
    void Update()
    {
        if (destoriedCount == lvlset.Length && !quizpage.activeSelf)
        {
            quizpage.SetActive(true);
        }

        if (quizpage.activeSelf && !qnGenerated)
        {
            generateQuestion();

        }
    }

    public void initiateAnimals(string animals)
    {
        string b = animals.ToUpper();
        int alength = animals.Length;
        for (int i = 0; i < alength; i++)
        {
            char c = b[i];
            if (c == 'C')
            {
                GameObject catz = Instantiate(cat, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), cat.transform.rotation);
            }
            if (c == 'Q')
            {
                GameObject chickz = Instantiate(chick, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), chick.transform.rotation);
            }
            if (c == 'N')
            {
                GameObject cowz = Instantiate(cow, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), cow.transform.rotation);
            }
            if (c == 'D')
            {
                GameObject dogz = Instantiate(dog, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), dog.transform.rotation);
            }
            if (c == 'F')
            {
                GameObject donkeyz = Instantiate(donkey, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), donkey.transform.rotation);
            }
            if (c == 'X')
            {
                GameObject duckz = Instantiate(duck, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), duck.transform.rotation);
            }
            if (c == 'E')
            {
                GameObject elephantz = Instantiate(elephant, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), elephant.transform.rotation);
            }
            if (c == 'H')
            {
                GameObject frogz = Instantiate(frog, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), frog.transform.rotation);
            }
            if (c == 'G')
            {
                GameObject goatZ = Instantiate(goat, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), goat.transform.rotation);
            }
            if (c == 'L')
            {
                GameObject Lilpokz = Instantiate(lilpok, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), lilpok.transform.rotation);
            }
            if (c == 'S')
            {
                GameObject lionz = Instantiate(lion, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), lion.transform.rotation);
            }
            if (c == 'M')
            {
                GameObject monkeyz = Instantiate(monkey, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), monkey.transform.rotation);
            }
            if (c == 'P')
            {
                GameObject pigz = Instantiate(pig, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), pig.transform.rotation);
            }
            if (c == 'R')
            {
                GameObject roosterz = Instantiate(rooster, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), rooster.transform.rotation);
            }
            if (c == 'V')
            {
                GameObject sheepz = Instantiate(sheep, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), sheep.transform.rotation);
            }
        };



    }
    public void addDestoried()
    {
        destoriedCount++;
    }

    public void countOccurances(string qnlist)
    {
        for (int i = 0; i < qnlist.Length; i++)
        {
            if (appearing.ContainsKey(qnlist[i]))
            {
                appearing[qnlist[i]]++;
            }
            else
            {
                appearing[qnlist[i]] = 1;
            }
        }
    }

    public void playerselect(int id, int optionpick)
    {
        if (qnPanel.activeSelf)
        {
            if (id == 1)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    options[i].transform.Find("player1").GetComponent<UnityEngine.UI.Image>().enabled = false;
                    options[i].transform.Find("player1").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                }
                options[optionpick].transform.Find("player1").GetComponent<UnityEngine.UI.Image>().enabled = true;
                options[optionpick].transform.Find("player1").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                optionpickplayer1 = optionpick;
            }
            else
            {
                for (int i = 0; i < options.Length; i++)
                {
                    options[i].transform.Find("player2").GetComponent<UnityEngine.UI.Image>().enabled = false;
                    options[i].transform.Find("player2").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                }
                options[optionpick].transform.Find("player2").GetComponent<UnityEngine.UI.Image>().enabled = true;
                options[optionpick].transform.Find("player2").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                optionpickplayer2 = optionpick;
            }
        }
        else if (qnPanel2.activeSelf)
        {
            if (id == 1)
            {
                for (int i = 0; i < option2.Length; i++)
                {
                    option2[i].transform.Find("player1").GetComponent<UnityEngine.UI.Image>().enabled = false;
                    option2[i].transform.Find("player1").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                }
                option2[optionpick].transform.Find("player1").GetComponent<UnityEngine.UI.Image>().enabled = true;
                option2[optionpick].transform.Find("player1").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                optionpickplayer1 = optionpick;
            }
            else
            {
                for (int i = 0; i < option2.Length; i++)
                {
                    option2[i].transform.Find("player2").GetComponent<UnityEngine.UI.Image>().enabled = false;
                    option2[i].transform.Find("player2").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                }
                option2[optionpick].transform.Find("player2").GetComponent<UnityEngine.UI.Image>().enabled = true;
                option2[optionpick].transform.Find("player2").GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                optionpickplayer2 = optionpick;
            }
        }
    }
    void generateQuestion()
    {
        qnGenerated = true;
        string reLoad = "AnimalSprite/";
        if (qntype.Count != 0)
        {
            List<int> qn = qntype[0];
            qntype.Remove(qn);
            int req = 4;
            string qnNew = lvlset;
            string ansSwq = "";
            Debug.Log(qn);
            Debug.Log(qn[0]);
            Debug.Log(qn[1]);
            switch (qn[0])
            {
                case 1:
                    qnPanel.SetActive(true);
                    GameObject targetGameObject = Resources.Load<GameObject>(reLoad + prefebDict[lvlset[qn[1]].ToString().ToUpper()]);
                    Instantiate(targetGameObject, new Vector3(qnPanel.transform.position.x, qnPanel.transform.position.y, 0), targetGameObject.transform.rotation);
                    qnPanel.transform.Find("QnText").GetComponent<TMP_Text>().text = "How many " + names[lvlset[qn[1]].ToString().ToUpper()] + " are present";
                    ansSwq= appearing[lvlset[qn[1]]].ToString();
                    while (ansSwq.Length < req)
                    {
                        string additionalQn = Random.Range(0,lvlset.Length+3).ToString();
                        if (!ansSwq.Contains(additionalQn))
                        {
                            ansSwq = ansSwq + additionalQn;
                        }
 
                    }
                    for (int i = 0; i < options.Length; i++)
                    {
                        options[i].GetComponent<Option>().isCorrect = false;
                        options[i].transform.Find("Text (TMP)").GetComponent<TMP_Text>().text = ansSwq[i].ToString();

                        if (options[i].transform.Find("Text (TMP)").GetComponent<TMP_Text>().text == appearing[lvlset[qn[1]]].ToString()) 
                        {
                            options[i].GetComponent<Option>().isCorrect = true;

                        }

                    }


                    break;

                case 2:
                    qnPanel2.SetActive(true);
                    if (qnNew.Length < 4)
                    {
                        while (qnNew.Length < req)
                        {
                            string additionalQn = keyList[Random.Range(0, keyList.Count + 1)];
                            if (!qnNew.Contains(additionalQn))
                            {
                                qnNew = qnNew + additionalQn;
                            }
                        }
                        while (ansSwq.Length<req)
                        {
                            string additionalQn = qnNew[Random.Range(0, qnNew.Length)].ToString();
                            if (!ansSwq.Contains(additionalQn))
                            {
                                ansSwq = ansSwq + additionalQn;
                            }
                            
                        }
                    }
                    else
                    {
                        qnNew = lvlset[0].ToString();
                        while (qnNew.Length< req)
                        {

                            string additionalQn = lvlset[Random.Range(0, keyList.Count)].ToString();
                            if (!qnNew.Contains(additionalQn))
                            {
                                qnNew = qnNew + additionalQn;
                            }
                            
                        }
                        while (ansSwq.Length< req)
                        {
                            string additionalQn = qnNew[Random.Range(0, qnNew.Length + 1)].ToString();
                            if (!ansSwq.Contains(additionalQn))
                            {
                                ansSwq = ansSwq + additionalQn;
                            }
           
                        }
                    }
                    qnPanel2.transform.Find("QnText").GetComponent<TMP_Text>().text = "Which is the first animal";
                    for (int i = 0; i < option2.Length; i++)
                    {
                        option2[i].GetComponent<Option>().isCorrect = false;
                        GameObject targets = Resources.Load<GameObject>(reLoad + prefebDict[ansSwq[i].ToString().ToUpper()]);
                   
                        GameObject target2 = Instantiate(targets, new Vector3(option2[i].transform.position.x, option2[i].transform.position.y, 0), targets.transform.rotation);
                        target2.transform.SetParent(option2[i].transform, false);


                        if (ansSwq[i] == lvlset[0])
                        {
                            option2[i].GetComponent<Option>().isCorrect = true;

                        }

                    }
                    break;

                case 3:
                    qnPanel2.SetActive(true);
                    if (qnNew.Length < 4)
                    {
                        while (qnNew.Length< req)
                        {
                            string additionalQn = keyList[Random.Range(0, keyList.Count )];
                            if (!qnNew.Contains(additionalQn))
                            {
                                qnNew = qnNew + additionalQn;
                            }
                        }
                        while (ansSwq.Length < req)
                        {
                            string additionalQn = qnNew[Random.Range(0, qnNew.Length )].ToString();
                            if (!ansSwq.Contains(additionalQn))
                            {
                                ansSwq = ansSwq + additionalQn;
                            }
                        }
                    }
                    else
                    {
                        qnNew = lvlset[0].ToString();
                        while (qnNew.Length< 4)
                        {

                            string additionalQn = lvlset[Random.Range(0, keyList.Count)].ToString();
                            if (!qnNew.Contains(additionalQn))
                            {
                                qnNew = qnNew + additionalQn;
                            }
                        }
                        while (ansSwq.Length < req)
                        {
                            string additionalQn = qnNew[Random.Range(0, qnNew.Length )].ToString();
                            if (!ansSwq.Contains(additionalQn))
                            {
                                ansSwq = ansSwq + additionalQn;
                            }
                        }
                    }
                    qnPanel2.transform.Find("QnText").GetComponent<TMP_Text>().text = "Which is the last animal";
                    for (int i = 0; i < option2.Length; i++)
                    {
                        option2[i].GetComponent<Option>().isCorrect = false;
                        GameObject targets = Resources.Load<GameObject>(reLoad + prefebDict[ansSwq[i].ToString().ToUpper()]);
                        Instantiate(targets, new Vector3(option2[i].transform.position.x, option2[i].transform.position.y, 0), targets.transform.rotation);


                        if (ansSwq[i] == lvlset[lvlset.Length-1])
                        {
                            option2[i].GetComponent<Option>().isCorrect = true;

                        }

                    }


                    break;






            }
        }
    }

}




