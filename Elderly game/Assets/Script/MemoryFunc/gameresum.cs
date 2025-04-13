using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameresum : MonoBehaviour
{
    // Start is called before the first frame update
    public void gamecont() {
        MemoryGame.instance.resumeGame();
    }
}
