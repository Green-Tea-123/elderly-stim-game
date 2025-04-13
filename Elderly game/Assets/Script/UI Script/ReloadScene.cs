using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void reloadScenes()
    {
        string lvlselection = "";
        


        if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_fast"))
        {
            lvlselection = "Rythmgame_single_fastlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_medium"))
        {
            lvlselection = "Rythmgame_single_mediumlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_single_slow"))
        {
            lvlselection = "Rythmgame_single_slowlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_fast"))
        {
            lvlselection = "Rythmgame_coop_fastlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_medium"))
        {
            lvlselection = "Rythmgame_coop_mediumlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Rythmgame_coop_slow"))
        {
            lvlselection = "Rythmgame_coop_slowlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Guess_fast"))
        {
            lvlselection = "Guess_fastlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Guess_medium"))
        {
            lvlselection = "Guess_mediumlvl";
        }
        else if (SceneManager.GetActiveScene().name.Contains("Guess_slow"))
        {
            lvlselection = "Guess_slowlvl";
        }

        SceneManager.LoadScene(lvlselection);
        Time.timeScale = 1.0f;
    }
}
