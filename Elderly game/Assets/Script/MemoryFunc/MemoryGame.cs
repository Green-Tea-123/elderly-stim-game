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
    [Header("Game settings")]
    public float xMin = 4;
    public float xMax = 20;
    public float yMin = 0;
    public float yMax = 4;

    public float speed = 60;


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

    public string lvlset;
    void Awake() {
        instance = this;

    }

    void Start()
    {
        initiateAnimals(lvlset);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initiateAnimals(string animals)
    {
        string b = animals.ToUpper();
        int alength = animals.Length;
        for (int i = 0; i < alength ; i++)
        {
            char c = b[i];
            if (c == 'C') {
                GameObject catz = Instantiate(cat, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), cat.transform.rotation);
            }
            if (c == 'Q') {
                GameObject chickz = Instantiate(chick, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), chick.transform.rotation);
            }
            if (c == 'N') {
                GameObject cowz = Instantiate(cow, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), cow.transform.rotation);
            }
            if (c == 'D') {
                GameObject dogz = Instantiate(dog, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), dog.transform.rotation);
            }
            if (c == 'F') {
                GameObject donkeyz = Instantiate(donkey, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), donkey.transform.rotation);
            }
            if (c == 'G') {
                GameObject duckz = Instantiate(duck, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), duck.transform.rotation);
            }
            if (c == 'E') {
                GameObject elephantz = Instantiate(elephant, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), elephant.transform.rotation);
            }
            if (c == 'H') {
                GameObject frogz = Instantiate(frog, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), frog.transform.rotation);
            }
            if (c == 'G') {
                GameObject goatZ = Instantiate(goat, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), goat.transform.rotation);
            }
            if (c == 'L') {
                GameObject Lilpokz = Instantiate(lilpok, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), lilpok.transform.rotation);
            }
            if (c == 'S') {
                GameObject lionz = Instantiate(lion, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), lion.transform.rotation);
            }
            if (c == 'M') {
                GameObject monkeyz = Instantiate(monkey, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), monkey.transform.rotation);
            }
            if (c == 'P') {
                GameObject pigz = Instantiate(pig, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), pig.transform.rotation);
            }
            if (c == 'R') {
                GameObject roosterz = Instantiate(rooster, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), rooster.transform.rotation);
            }
            if (c == 'M') {
                GameObject sheepz = Instantiate(sheep, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), sheep.transform.rotation);
            }
    };

    
}
}
