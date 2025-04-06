using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RythmGameLvlSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject initializePage;
    public TMP_Text textz;
    public GameObject score;

    public void gameStart()
    {
        string lvlselection = "";
        if(SceneManager.GetActiveScene().name == "Rythmgame_fastlvl")
        {
            lvlselection = "Rythmgame_fast";

        } else if (SceneManager.GetActiveScene().name == "Rythmgame_mediumlvl")
        {
            lvlselection = "Rythmgame_medium";
        } else if (SceneManager.GetActiveScene().name == "Rythmgame_slowlvl")
        {
            lvlselection = "Rythmgame_slow";
        }
        lvlselection = lvlselection + textz.text;
        SceneManager.LoadScene(lvlselection);

    }


}
