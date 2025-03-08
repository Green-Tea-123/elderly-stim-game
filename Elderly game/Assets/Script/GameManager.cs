using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public bool Started;
    public beat bs;
    public static GameManager instance;
    public float Score;
    public float ScorePernote = 1;
    public TextMeshProUGUI scoretext;
    public bool emergencyStop;
    public float totalnotes;
    public float hitno;
    public float missno;
    public TextMeshProUGUI hitnotext;
    public TextMeshProUGUI missnotext;
    public GameObject resultScreen;
    void Start()
    {
        instance = this;
        totalnotes = FindObjectsOfType<objectpress>().Length;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            emergencyStop = !emergencyStop;
            if (emergencyStop)
            {
                music.Pause();
                Time.timeScale = 0;
            }
            else { Time.timeScale = 1; music.UnPause(); }
        }

        if (!Started)
        {
            if (Input.anyKeyDown)
            {
                Started = true;
                bs.hasStart = true;

                music.Play();
            }
        }
        else
        {
            if (!music.isPlaying && !resultScreen.activeInHierarchy && !emergencyStop) { 
            resultScreen.SetActive(true);
            hitnotext.text = " " + hitno;
            missnotext.text = "" + missno;
        }
        }
    }

    public void NoteHit() {
        Score += ScorePernote;
        hitno += 1;
        scoretext.text = "score: " + Score;
    }

    public void NoteMiss()
    {
        Score -= ScorePernote;
        missno -= 1;
        scoretext.text = "score: " + Score;
    }
}
