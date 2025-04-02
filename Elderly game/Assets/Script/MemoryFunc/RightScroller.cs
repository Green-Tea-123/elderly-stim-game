using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public bool hasStart = false;


    public void Start()
    {
        moveSpeed = moveSpeed / 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStart)
        {
            if (Input.anyKey)
           
            hasStart = true;

        }
        else
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

}
