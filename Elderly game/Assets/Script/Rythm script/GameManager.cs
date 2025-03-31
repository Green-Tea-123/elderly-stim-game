using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coverpage;
    public AudioSource music;
    public AudioSource scoremusic;
    public bool Started;
    public beat bs;
    public static GameManager instance;
    public bool emergencyStop;
    public float framerate = 60f;
    public int lvlNo;
    [Header("In game Score")]
    public TextMeshProUGUI scoretext;
    public float Score;
    public float ScorePernote = 1;


    [Header("Scoring panel setting ")]
    public float totalnotes;
    public float hitno;
    public float missno;
    public TextMeshProUGUI hitnotext;
    public TextMeshProUGUI missnotext;
    public GameObject resultScreen;
 


    [Header("TileMap setting ")]
    public GameObject tile;
    public GameObject RedFinal;
    public GameObject YellowFinal;
    public GameObject BlueFinal;
    public GameObject GreenFinal;
    public string positioninitialization = "yybg";


    [Header("Game Pause setting ")]
    public GameObject pausePage;

    public static string blueToothMsg = null;


    public static Dictionary<string, string> lvlinfo = new Dictionary<string, string>(){
    {"1", "gggbbbggrrggbbbggf"},
    {"2", "rrrbbggjjkj"},
    {"3", "jjjkkkbbbbrrrrr"},
    {"4", "rrrrjjjjjjjkkkk"},
    {"5", "rrrbbbjjjyyyy"},
    {"6", "yyyyyyyyyy"},
    {"7", "bbbbbbbbb"},
    {"8", "yyyyyyy"},
    {"9", "bbbbbbb"},
    {"10", "yyyrrrr"},
    {"11", "bbjjkk"},
    {"12", "jjjjjjjjjjjjj"}
    };
    private void Awake()
    {
        instance = this;

    }

    void Start()
    {

        totalnotes = this.CountNoChild(tile);
        this.lvlNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //blueToothMsg = InputManager.instance.getKeyDown();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            emergencyStop = !emergencyStop;
            if (emergencyStop)
            {
                music.Pause();
                Time.timeScale = 0;
                pausePage.SetActive(true);
            }
            else { Time.timeScale = 1; music.UnPause(); pausePage.SetActive(false); }
        }

        if (!Started & !coverpage.activeInHierarchy)
        {
            if (Input.anyKeyDown || blueToothMsg != null)
            {
                Started = true;
                bs.hasStart = true;
                music.Play();
            }
        }
        else
        {
            if ( hitno + missno == totalnotes && !resultScreen.activeInHierarchy && !emergencyStop && !coverpage.activeSelf) { 
            resultScreen.SetActive(true);
            hitnotext.text = " " + hitno;
            missnotext.text = "" + missno;
            }
        }
    }
    public void gameResume()
    {

        emergencyStop = !emergencyStop;
        Time.timeScale = 1; music.UnPause();
        pausePage.SetActive(false);
    }

    public void NoteHit() {
        Score += ScorePernote;
        hitno += 1;
        scoretext.text = "score: " + Score;
        scoremusic.Play();
        if (!music.isPlaying)
        {
            music.UnPause();
        }
    }

    public void NoteMiss()
    {
        Score -= ScorePernote;
        missno += 1;
        scoretext.text = "score: " + Score;
        music.Pause();
    }

    public void UpdatetheTile(string a) {
        for (int i = 0; i < this.tile.transform.childCount; i++)
        {
            this.tile.transform.GetChild(i).gameObject.SetActive(false);
        }

        this.positioninitialization = a;

        for (int i = 0; i < a.Length +1; i++)
        {
            this.tile.transform.GetChild(i).gameObject.SetActive(true);
        }

        PositionIni(a);
        Start();
    }

    public void Updatedifficulty(string difficulty)
    {
        string difficultysetting = difficulty;
        Debug.Log(difficultysetting);
        this.framerate = float.Parse(difficultysetting);
        Start();

    }

    public void PositionIni(string positionString)
    {
        string b = positionString.ToUpper();
        int alength = positionString.Length;
        for (int i = 0; i < alength ; i++)
        {
            char c = b[i];
            if (c == 'R')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);
            }
            if (c == 'B')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("blue").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);
            }

            if (c == 'Y')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("yellow").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);
            }
            if (c == 'G')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("green").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);
            }
            if (c == 'F')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("blue").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton2.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);
            }
            if (c == 'D')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("yellow").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton2.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);
            }
                if (c == 'S')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("green").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton2.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);
            }

            if (c == 'H')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("blue").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("yellow").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton2.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);
            }

            if (c == 'J')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("blue").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("green").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton2.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);
            }
            if (c == 'K')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("yellow").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("green").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton2.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);
            }
        }
    }

    public void updateLvl(int lvl)
    {
        this.lvlNo = lvl;
    }

    int CountNoChild(GameObject a)
    {
        int Noactive = this.positioninitialization.Length;
        int NoNote = 0;

        for (int i = 0; i < Noactive; i++)
        {
            foreach (Transform child in a.transform.GetChild(i))
            {
                if (child.gameObject.activeSelf)
                {
                    NoNote++;
                }
            }

        }
        return NoNote;
    }
}
