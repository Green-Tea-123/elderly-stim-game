using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttoncontroller : MonoBehaviour
{
    private SpriteRenderer SR;

    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode KeyToPress;

    public string Bluetoothmsg;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress) || GameManager.blueToothMsg == Bluetoothmsg)
        {
            SR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(KeyToPress))
        {
            SR.sprite = defaultImage;
        }

    }
}
