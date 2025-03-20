using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpress : MonoBehaviour
{
    public bool canBePress;
    public KeyCode keyTopress;
    public GameObject hiteffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyTopress))
        {
            if (canBePress)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
                Instantiate(hiteffect, new Vector3(this.transform.position.x,this.transform.position.y),hiteffect.transform.rotation);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator" && gameObject.activeSelf)
        {
            canBePress = false;

            GameManager.instance.NoteMiss();
        }
    }

    
}
