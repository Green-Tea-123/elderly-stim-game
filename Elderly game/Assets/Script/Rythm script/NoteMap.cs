using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMap : MonoBehaviour
{
    // Start is called before the first frame update
    public static NoteMap instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
