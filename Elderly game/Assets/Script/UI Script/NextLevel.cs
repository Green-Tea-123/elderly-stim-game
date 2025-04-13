using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject result;
    public GameObject frontPage;

    public GameObject lastStage;
    public void nxtlvl()
    {
        string lvlno = string.Empty;
        string difficulty = string.Empty;
        if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_fast"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_single_fast");
            difficulty = "Rythmgame_single_fast";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_medium"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_single_medium");
            difficulty = "Rythmgame_single_medium";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_slow"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_single_slow");
            difficulty = "Rythmgame_single_slow";
        }else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_fast"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_coop_fast");
            difficulty = "Rythmgame_coop_fast";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_medium"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_coop_medium");
            difficulty = "Rythmgame_coop_medium";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_slow"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_coop_slow");
            difficulty = "Rythmgame_coop_slow";
        }
        int lvl = int.Parse(lvlno);
        if(lvl <12) {
        SceneManager.LoadScene(difficulty + (lvl+1).ToString());
        } else {
            SceneManager.LoadScene(difficulty+"lvl");
        }

    }

}
