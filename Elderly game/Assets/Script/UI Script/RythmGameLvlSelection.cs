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

    public TMP_Text textz;


    public void gameStart()
    {
        string lvlselection = "";
        if(SceneManager.GetActiveScene().name == "Rythmgame_single_fastlvl")
        {
            lvlselection = "Rythmgame_single_fast";

        } else if (SceneManager.GetActiveScene().name == "Rythmgame_single_mediumlvl")
        {
            lvlselection = "Rythmgame_single_medium";
        } else if (SceneManager.GetActiveScene().name == "Rythmgame_single_slowlvl")
        {
            lvlselection = "Rythmgame_single_slow";
        } else if(SceneManager.GetActiveScene().name == "Rythmgame_coop_fastlvl")
        {
            lvlselection = "Rythmgame_coop_fast";

        } else if (SceneManager.GetActiveScene().name == "Rythmgame_coop_mediumlvl")
        {
            lvlselection = "Rythmgame_coop_medium";
        } else if (SceneManager.GetActiveScene().name == "Rythmgame_coop_slowlvl")
        {
            lvlselection = "Rythmgame_coop_slow";
        }
        lvlselection = lvlselection + textz.text;
        SceneManager.LoadScene(lvlselection);

    }


}
