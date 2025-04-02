using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject result;
    public GameObject frontPage;
    public void nxtlvl()
    {
        LibraryNo.instance.Updatestagenumber(GameManager.instance.lvlNo);
        LibraryNo.instance.moveon = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
    }

}
