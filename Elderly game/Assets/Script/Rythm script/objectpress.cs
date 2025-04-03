using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpress : MonoBehaviour
{
    public bool canBePress;
    public KeyCode keyTopress;
    public GameObject hiteffect;

    public string targetBlutTooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(keyTopress) || GameManager.staticBlueToothMsg == targetBlutTooth)
        {
            if (canBePress)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
                Instantiate(hiteffect, new Vector3(this.transform.position.x,this.transform.position.y),hiteffect.transform.rotation);
            }
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            if (gameObject.name.Substring(0,1) == "r") {
              GameManager.instance.updateRed(true, gameObject.name,gameObject);
            }
            else if(gameObject.name.Substring(0, 1) == "g")
            {
                GameManager.instance.updateGreen(true, gameObject.name,gameObject);
            }else if(gameObject.name.Substring(0, 1) == "y")
            {
                GameManager.instance.updateYellow(true, gameObject.name, gameObject);
            }else if(gameObject.name.Substring(0, 1) == "b")
            {
                GameManager.instance.updateBlue(true, gameObject.name, gameObject);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator" && gameObject.activeSelf)
        {

            if (gameObject.name.Substring(0,1) == "r")
            {
                GameManager.instance.updateRed(false, "empty",null);
            }
            else if (gameObject.name.Substring(0, 1) == "g")
            {
                GameManager.instance.updateGreen(false, "empty",null);
            }
            else if (gameObject.name.Substring(0, 1) == "y")
            {
                GameManager.instance.updateYellow(false, "empty", null);
            }
            else if (gameObject.name.Substring(0, 1) == "b")
            {
                GameManager.instance.updateBlue(false, "empty", null);
            }

            GameManager.instance.NoteMiss();
        }
    }

    public void objectDisappear()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            GameManager.instance.NoteHit();
            Instantiate(hiteffect, new Vector3(this.transform.position.x, this.transform.position.y), hiteffect.transform.rotation);
        } else
        {

        }
    }
}
