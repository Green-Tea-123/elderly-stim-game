using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
    // Start is called before the first frame update
    public float beatTempo;
    public bool hasStart = false;
    public GameObject tile;
    public GameObject RedFinal;
    public GameObject YellowFinal;
    public GameObject BlueFinal;
    public GameObject GreenFinal;


    public void Start()
    {
        beatTempo = beatTempo / GameManager.instance.framerate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStart)
        {
            //if (Input.anyKey)
            //
            //  hasStart = true;
            //
        }
        else
        {
            transform.position += new Vector3(0f, -beatTempo * Time.deltaTime, 0f);
        }
    }

    public void Updatedifficulty(string difficulty)
    {
        string difficultysetting = difficulty;
        Debug.Log(difficultysetting);
        GameManager.instance.framerate = float.Parse(difficultysetting);
        Start();

    }


}
