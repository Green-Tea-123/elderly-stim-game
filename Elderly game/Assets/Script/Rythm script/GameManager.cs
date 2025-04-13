using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using static UnityEngine.EventSystems.PointerEventData;
using Unity.VisualScripting;

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
    public bool hasended = false;
    [Header("In game Score")]
    public TextMeshProUGUI scoretext;
    public float Score;
    public float ScorePernote = 1;
    public bool isCoop = true; //TODO change to false
    public int playerTurn = 1;
    public int[] isPressedDown = { 0, 0, 0, 0 };
    public static int pressedDownDelay = 30;

    public List<Sprite> defaultButtonImages;
    public List<Sprite> pressedButtonImages;

    public GameObject background;
    public TextMeshProUGUI playerIndicator;
    public bool locked = false;


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

    public static string staticBlueToothMsg = null;

    [Header("tilereceiver setting ")]
    public bool redCanBePressed;
    public string redName = "empty";
    public bool blueCanBePressed;
    public string blueName = "empty";
    public bool greenCanBePressed;
    public string greenName = "empty";
    public bool yellowCanBePressed;
    public string yellowName = "empty";
    public GameObject redToDis;
    public GameObject greenToDis;
    public GameObject yellowToDis;
    public GameObject blueToDis;


    [Header("Sprite setting ")]
    public GameObject redSprite;
    public GameObject greenSprite;
    public GameObject blueSprite;
    public GameObject yellowSprite;
    public static Dictionary<string, string> lvlinfo = new Dictionary<string, string>(){
    {"1", "RBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYGRBYG"},
    {"2", "RSBYHGRBYGSBYHGRBYGRSBYHGRBYGRBYRSBYHGRBYGSBYHGRBYGRSBYHGRBYGRBY"},
    {"3", "RDBKYGRSBHYGDBKYGRSBGRDBKYGRSBHYRDBKYGRSBHYGDBKYGRSBGRDBKYGRSBHY"},
    {"4", "RFBDYHGRSBKYGFBDGRHYGRFBDYHGRSBKRFBDYHGRSBKYGFBDGRHYGRFBDYHGRSBK"},
    {"5", "RFDSBYHGRBKYGFDSBGRJYGRFDSBYHGRBRFDSBYHGRBKYGFDSBGRJYGRFDSBYHGRB"},
    {"6", "RFDSBYHJGRBKYGFDSBGRHYGRFDSBYHJGRFDSBYHJGRBKYGFDSBGRHYGRFDSBYHJG"},
    {"7", "RFDSHBYJGRKYGFDSHBYJGRBYGRFDSHBYRFDSHBYJGRKYGFDSHBYJGRBYGRFDSHBY"},
    {"8", "RFDSHKBYJGRBYGFDSHKBYJGRHYGRFDSHRFDSHKBYJGRBYGFDSHKBYJGRHYGRFDSH"},
    {"9", "RFDSHKBJYGRBYGFDSHKBJYGRBKYGJFDSRFDSHKBJYGRBYGFDSHKBJYGRBKYGJFDS"},
    {"10", "RFDSHKBJYGRBKYGFDSHKBJYGRBKYGFHJRFDSHKBJYGRBKYGFDSHKBJYGRBKYGFHJ"},
    {"11", "RFDSHKBJYGRBKYGFDSHKBJYGRBKYGFDSRFDSHKBJYGRBKYGFDSHKBJYGRBKYGFDS"},
    {"12", "RFDSHKBJYGRBKYGFDSHKBJYGRBKYGFDSRFDSHKBJYGRBKYGFDSHKBJYGRBKYGFDS"},
    {"customizable", ""}
    };
    private void Awake()
    {
      
        instance = this;
        string lvlno = "";
        if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_fast"))
        {
            this.framerate = 30f;
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_single_fast");
            GameManager.instance.isCoop=false;
        } else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_medium")) {
            this.framerate = 60f;
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_single_medium");
            GameManager.instance.isCoop=false;
        } else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_slow")) { 
            this.framerate = 90f;
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_single_slow");
            GameManager.instance.isCoop=false;
        } else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_fast"))
        {
            this.framerate = 30f;
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_coop_fast");
            GameManager.instance.isCoop=true;
        } else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_medium")) {
            this.framerate = 60f;
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_coop_medium");
            GameManager.instance.isCoop=true;
        } else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_slow")) { 
            this.framerate = 90f;
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_coop_slow");
            GameManager.instance.isCoop=true;
        }
        Debug.Log(lvlno);
        UpdatetheTile(lvlinfo[lvlno]);

    }

    void Start()
    {

        totalnotes = this.CountNoChild(tile);
    }

    // Update is called once per frame
    void Update()
    {
        List<BluetoothInput> blueToothMsg = InputManager.instance.getKeyDown();
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
            Started=false;
            playerIndicator.transform.parent.gameObject.SetActive(false);
            resultScreen.SetActive(true);
                hasended = true;
            hitnotext.text = " " + hitno;
            missnotext.text = "" + missno;
            }
        }

        if (isCoop && blueToothMsg != null) {
            for (int i = 0; i < blueToothMsg.Count; i++) {
                if (blueToothMsg[i].controllerId == playerTurn) {
                    staticBlueToothMsg = blueToothMsg[i].input.ToString();
                    int inputButton = blueToothMsg[i].input;
                    switch (inputButton) {
                        case 1:
                            RedFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[0];
                            isPressedDown[inputButton - 1] = pressedDownDelay;
                            if (redCanBePressed) {
                                redToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                            }
                            break;
                        case 2:
                            GreenFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[1];
                            isPressedDown[inputButton - 1] = pressedDownDelay;
                            if (greenCanBePressed)
                            {
                                greenToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                            }
                            break;
                        case 3:
                            BlueFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[2];
                            isPressedDown[inputButton - 1] = pressedDownDelay;
                            if (blueCanBePressed)
                            {
                                blueToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                            }
                            break;
                        case 4:
                            YellowFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[3];
                            isPressedDown[inputButton - 1] = pressedDownDelay;
                            if (yellowCanBePressed)
                            {
                                yellowToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                            }
                            break;
                    }
                }
            }
        } else {
            if (blueToothMsg == null) {
                if (Input.GetKeyDown(KeyCode.Q)) {
                    RedFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[0];

                } else if (Input.GetKeyDown(KeyCode.R)) {
                    GreenFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[1];
                } else if (Input.GetKeyDown(KeyCode.W)) {
                    BlueFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[2];
                } else if (Input.GetKeyDown(KeyCode.E)) {
                    YellowFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[3];
                }

                if (Input.GetKeyUp(KeyCode.Q)) {
                    RedFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[0];
                } else if (Input.GetKeyUp(KeyCode.R)) {
                    GreenFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[1];
                } else if (Input.GetKeyUp(KeyCode.W)) {
                    BlueFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[2];
                } else if (Input.GetKeyUp(KeyCode.E)) {
                    YellowFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[3];
                }
            } else {
                staticBlueToothMsg = blueToothMsg[0].input.ToString();
                int inputButton = blueToothMsg[0].input;
                switch (inputButton) {
                    case 1:
                        RedFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[0];
                        isPressedDown[inputButton - 1] = pressedDownDelay;
                        if (redCanBePressed)
                        {
                            redToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                        }
                        break;
                    case 2:
                        GreenFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[1];
                        isPressedDown[inputButton - 1] = pressedDownDelay;
                        if (greenCanBePressed)
                        {
                            greenToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                        }
                        break;
                    case 3:
                        BlueFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[2];
                        isPressedDown[inputButton - 1] = pressedDownDelay;
                        if (blueCanBePressed)
                        {
                            blueToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                        }
                        break;
                    case 4:
                        YellowFinal.GetComponent<SpriteRenderer>().sprite = pressedButtonImages[3];
                        isPressedDown[inputButton - 1] = pressedDownDelay;
                        if (yellowCanBePressed)
                        {
                            yellowToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                        }
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (redCanBePressed)
                {
                    redToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (greenCanBePressed)
                {
                    greenToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (blueCanBePressed)
                {
                    blueToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (yellowCanBePressed)
                {
                    yellowToDis.gameObject.GetComponent<objectpress>().objectDisappear();
                }
            }
        }

        for (int j = 0; j < isPressedDown.Length; j++) {
            if (isPressedDown[j] > 0) {
                isPressedDown[j]--;
            } else {
                switch (j) {
                    case 0:
                        RedFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[0];
                        break;
                    case 1:
                        GreenFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[1];
                        break;
                    case 2:
                        BlueFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[2];
                        break;
                    case 3:
                        YellowFinal.GetComponent<SpriteRenderer>().sprite = defaultButtonImages[3];
                        break;
                }
            }
        }
        if(isCoop ==true && Started == true) {
        playerIndicator.transform.parent.gameObject.SetActive(true);}
             else {playerIndicator.transform.parent.gameObject.SetActive(false);
             }
        // A bit stupid way to implement co op but whatever
        if (isCoop && ((int)Time.time % 20 == 0)) {
            if (!locked) {
                locked = true;
                playerTurn = (playerTurn == 1) ? 2 : 1;
                this.playerIndicator.text = "Player " + playerTurn;
                this.background.GetComponent<SpriteRenderer>().color = (playerTurn == 1) ? new Color(77f / 255f, 85 / 255f, 101f / 255f, 1f) : new Color(124f / 255f, 156f / 255f, 130f / 255f, 1f);
                Debug.Log("Turn changing");
            }
        } else if ((int)Time.time % 10 != 0) {
            locked = false;
        }
    }
    public void gameResume()
    {

        emergencyStop = !emergencyStop;
        Time.timeScale = 1; music.UnPause();
        pausePage.SetActive(false);
    }

    public void resetGameValue()
    {
        hitno = 0;
        missno = 0;
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
        /*for (int i = 0; i < this.tile.transform.childCount; i++)
        {
            this.tile.transform.GetChild(i).gameObject.SetActive(false);
        }

        this.positioninitialization = a;

        for (int i = 0; i < a.Length +1; i++)
        {
            this.tile.transform.GetChild(i).gameObject.SetActive(true);
        }*/

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
                /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);*/
                GameObject redtile = Instantiate(redSprite, new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0), redSprite.transform.rotation);
                redtile.transform.SetParent(this.tile.transform);

            }
            if (c == 'B')
            {
                /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("blue").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);*/
                GameObject bluetile = Instantiate(blueSprite, new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0), blueSprite.transform.rotation);
                bluetile.transform.SetParent(this.tile.transform);
            }

            if (c == 'Y')
            {
                /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("yellow").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);*/
                GameObject yellowtile = Instantiate(yellowSprite, new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0), yellowSprite.transform.rotation);
                yellowtile.transform.SetParent(this.tile.transform);
            }
            if (c == 'G')
            {
            /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
            GameObject actualbutton = buttonz.transform.Find("green").gameObject;
            actualbutton.SetActive(true);
            actualbutton.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);*/
            GameObject greentile = Instantiate(greenSprite, new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0), greenSprite.transform.rotation);
            greentile.transform.SetParent(this.tile.transform);
            }
            if (c == 'F')
            {
                /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("blue").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton2.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);*/
                GameObject redtile = Instantiate(redSprite, new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0), redSprite.transform.rotation);
                redtile.transform.SetParent(this.tile.transform);
                GameObject bluetile = Instantiate(blueSprite, new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0), blueSprite.transform.rotation);
                bluetile.transform.SetParent(this.tile.transform);

            }
            if (c == 'D')
            {
                /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("yellow").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton2.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);
            */
                GameObject redtile = Instantiate(redSprite, new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0), redSprite.transform.rotation);
                redtile.transform.SetParent(this.tile.transform);
                GameObject yellowtile = Instantiate(yellowSprite, new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0), yellowSprite.transform.rotation);
                yellowtile.transform.SetParent(this.tile.transform);

            }
            if (c == 'S')
            {
                /*
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("green").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton2.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);
            */
                GameObject redtile = Instantiate(redSprite, new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y + 4 + (i) * 4, -0), redSprite.transform.rotation);
                redtile.transform.SetParent(this.tile.transform);
                GameObject greentile = Instantiate(greenSprite, new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0), greenSprite.transform.rotation);
                greentile.transform.SetParent(this.tile.transform);


            }

            if (c == 'H')
            {
                /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("blue").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("yellow").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton2.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);
           */
                GameObject yellowtile = Instantiate(yellowSprite, new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0), yellowSprite.transform.rotation);
                yellowtile.transform.SetParent(this.tile.transform);
                GameObject bluetile = Instantiate(blueSprite, new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0), blueSprite.transform.rotation);
                bluetile.transform.SetParent(this.tile.transform);


            }

            if (c == 'J')
            {

                /*GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("blue").gameObject;
                GameObject actualbutton2 = buttonz.transform.Find("green").gameObject;
                actualbutton.SetActive(true);
                actualbutton2.SetActive(true);
                actualbutton2.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);
                actualbutton.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0);
           
                */
                GameObject greentile = Instantiate(greenSprite, new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0), greenSprite.transform.rotation);
                greentile.transform.SetParent(this.tile.transform);
                GameObject bluetile = Instantiate(blueSprite, new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y + 4 + (i) * 4, -0), blueSprite.transform.rotation);
                bluetile.transform.SetParent(this.tile.transform);

            }
            if (c == 'K')
            {
                /* GameObject buttonz = tile.transform.GetChild(i).gameObject;
                 GameObject actualbutton = buttonz.transform.Find("yellow").gameObject;
                 GameObject actualbutton2 = buttonz.transform.Find("green").gameObject;
                 actualbutton.SetActive(true);
                 actualbutton2.SetActive(true);
                 actualbutton2.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0);

                 actualbutton.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0);
             */
                GameObject yellowtile = Instantiate(yellowSprite, new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y + 4 + (i) * 4, -0), yellowSprite.transform.rotation);
                yellowtile.transform.SetParent(this.tile.transform);

                GameObject greentile = Instantiate(greenSprite, new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y + 4 + (i) * 4, -0), greenSprite.transform.rotation);
                greentile.transform.SetParent(this.tile.transform);

            }
        }
    }

    public void updateLvl(int lvl)
    {
        this.lvlNo = lvl;
    }

    int CountNoChild(GameObject a)
    {
        int NoNote = 0;
        /*int Noactive = this.positioninitialization.Length;
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

        }*/
        foreach (Transform child in a.transform)
        {
            if (child.gameObject.activeInHierarchy)
                NoNote++;
        }
        return NoNote;
    }

    void makeCoop() {
        isCoop = true;
    }
    public void updateRed(bool rd,string str,GameObject tile)
    {
        this.redCanBePressed = rd;
        this.redName = str;
        this.redToDis = tile;
    }
    public void updateBlue(bool rd, string str, GameObject tile)
    {
        this.blueCanBePressed = rd;
        this.blueName = str;
        this.blueToDis = tile;
    }
    public void updateYellow(bool rd, string str, GameObject tile)
    {
        this.yellowCanBePressed = rd;
        this.yellowName = str;
        this.yellowToDis = tile;
    }
    public void updateGreen(bool rd, string str, GameObject tile)
    {
        this.greenCanBePressed = rd;
        this.greenName = str;
        this.greenToDis = tile;
    }


}
