using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeatlvl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject result;
    public void repeatlvl()
    {

        GameManager.instance.UpdatetheTile(GameManager.lvlinfo[GameManager.instance.lvlNo.ToString()]);
        result.SetActive(false);
        GameManager.instance.resetGameValue();
    }

}

