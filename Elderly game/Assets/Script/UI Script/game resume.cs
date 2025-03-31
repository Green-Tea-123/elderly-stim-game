using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameresume : MonoBehaviour
{
    // Start is called before the first frame update
    public void gameResume()
    {
        GameManager.instance.gameResume();
    }
}
