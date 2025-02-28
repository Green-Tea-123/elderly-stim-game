using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
    // Start is called before the first frame update
    public float beatTempo;
    public bool hasStart = false;
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStart)
        {
            if (Input.anyKey)
            {
                hasStart = true;
            }
        }
        else
        {
            transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
