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
    public List<float> yaxis= new List<float>();
    public List<float> xaxis = new List<float>();
    public int destoriedCount;

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
    {"G", "duck"},
    {"E", "elephant"},
    {"H", "frog"},
    {"G", "goat"},
    {"L", "chick"},
    {"S", "lion"},
    {"M", "monkey"},
    {"P", "pig"},
    {"R", "rooster"},
    {"M", "sheep"}
    };

    public static Dictionary<char,int> appearing = new Dictionary<char, int>(){
    };

    [Header("UIUX")]
    public GameObject quizpage;
    public GameObject[] options;







    public string lvlset;
    void Awake() {
        instance = this;
        for (int i = 0; i < lvlset.Length; i++)
        {
            yaxis.Add(Random.Range(yMin, yMax));
            xaxis.Add(Random.Range(0, 2));
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
        if (destoriedCount == lvlset.Length)
        {
            quizpage.SetActive(true);
        }
    }

    public void initiateAnimals(string animals)
    {
        string b = animals.ToUpper();
        int alength = animals.Length;
        for (int i = 0; i < alength ; i++)
        {
            char c = b[i];
            if (c == 'C') {
                GameObject catz = Instantiate(cat, new Vector3((this.xaxis[i])<1? -20 - i*20 : 25 + i*20, this.yaxis[i],0), cat.transform.rotation);
            }
            if (c == 'Q') {
                GameObject chickz = Instantiate(chick, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), chick.transform.rotation);
            }
            if (c == 'N') {
                GameObject cowz = Instantiate(cow, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), cow.transform.rotation);
            }
            if (c == 'D') {
                GameObject dogz = Instantiate(dog, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), dog.transform.rotation);
            }
            if (c == 'F') {
                GameObject donkeyz = Instantiate(donkey, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), donkey.transform.rotation);
            }
            if (c == 'G') {
                GameObject duckz = Instantiate(duck, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), duck.transform.rotation);
            }
            if (c == 'E') {
                GameObject elephantz = Instantiate(elephant, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), elephant.transform.rotation);
            }
            if (c == 'H') {
                GameObject frogz = Instantiate(frog, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), frog.transform.rotation);
            }
            if (c == 'G') {
                GameObject goatZ = Instantiate(goat, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), goat.transform.rotation);
            }
            if (c == 'L') {
                GameObject Lilpokz = Instantiate(lilpok, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), lilpok.transform.rotation);
            }
            if (c == 'S') {
                GameObject lionz = Instantiate(lion, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), lion.transform.rotation);
            }
            if (c == 'M') {
                GameObject monkeyz = Instantiate(monkey, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), monkey.transform.rotation);
            }
            if (c == 'P') {
                GameObject pigz = Instantiate(pig, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), pig.transform.rotation);
            }
            if (c == 'R') {
                GameObject roosterz = Instantiate(rooster, new Vector3((this.xaxis[i]) < 1 ? -20 - i * 20 : 25 + i * 20, this.yaxis[i], 0), rooster.transform.rotation);
            }
            if (c == 'M') {
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
            } else
            {
                appearing[qnlist[i]] = 1;
            }
        }
    }
}
