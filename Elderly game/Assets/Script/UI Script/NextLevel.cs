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
    public void nxtlvl()
    {
        string lvlno = string.Empty;
        string difficulty = string.Empty;
        if (SceneManager.GetActiveScene().name.Contains("Rythmgame_fast"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_fast");
            difficulty = "Rythmgame_fast";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_medium"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_medium");
            difficulty = "Rythmgame_medium";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_slow"))
        {
            lvlno = SceneManager.GetActiveScene().name.TrimStart("Rythmgame_slow");
            difficulty = "Rythmgame_slow";
        }
        int lvl = int.Parse(lvlno);
        SceneManager.LoadScene(difficulty + (lvl+1).ToString());

    }

}
