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


    void Start()
    {
        beatTempo = beatTempo / 60f;
        PositionIni(GameManager.instance.positioninitialization);
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
            transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }

    void PositionIni(string a)
    {
        string b = a.ToUpper();
        int alength = a.Length;
        for (int i = 1; i < alength + 1; i++)
        {
            char c = b[i - 1];
            if (c == 'R')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("red").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(RedFinal.transform.position.x, RedFinal.transform.position.y - 4 - (i-1)*4,-0); 
            }
            if (c == 'B')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("Blue").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(BlueFinal.transform.position.x, BlueFinal.transform.position.y - 4 - (i - 1) * 4, -0);
            }

            if (c == 'Y')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("yellow").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(YellowFinal.transform.position.x, YellowFinal.transform.position.y - 4 - (i - 1) * 4, -0);
            }
            if (c == 'G')
            {
                GameObject buttonz = tile.transform.GetChild(i).gameObject;
                GameObject actualbutton = buttonz.transform.Find("green").gameObject;
                actualbutton.SetActive(true);
                actualbutton.transform.position = new Vector3(GreenFinal.transform.position.x, GreenFinal.transform.position.y - 4 - (i - 1) * 4, -0);
            }
        }
    }
}
