using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void reloadScenes()
    {
        string lvlselection = "";
        if (SceneManager.GetActiveScene().name.Contains("Rythmgame_fast"))
        {
            lvlselection = "Rythmgame_fastlvl";

        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_medium"))
        {
            lvlselection = "Rythmgame_mediumlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_slowlvl"))
        {
            lvlselection = "Rythmgame_slowlvl";
        }

        SceneManager.LoadScene(lvlselection);
        Time.timeScale = 1.0f;
    }
}
