using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 120;
    public bool hasStart = false;
    public float initialPos;
    public bool musicPlay = false;
    void Start()
    {
        moveSpeed = moveSpeed / MemoryGame.instance.speed;
        if (gameObject.transform.position.x < 0)
        {
            gameObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().flipX=true;
        }
        updateIniPos();

    }

    // Update is called once per frame
    void Update()
    {
        if (initialPos > 20)
        {
            if (gameObject.transform.position.x < -10)
            {
                MemoryGame.instance.addDestoried();
                gameObject.SetActive(false);
                
            }
            else
            {
                gameObject.SetActive(true);
            }

        }else if(initialPos < -5 ) 
        {
            if (gameObject.transform.position.x > 10)
            {
                MemoryGame.instance.addDestoried();
                gameObject.SetActive(false);
               
            }
            else
            {
                gameObject.SetActive(true);
            }
        }



        if (!hasStart)
        {
            if (Input.anyKey)
           
            hasStart = true;

        }
        else
        {
            if (initialPos < 0)
            {
                gameObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                
            }
            else
            {
                gameObject.transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
            }
        }

        if(initialPos < 0) {
            if (gameObject.transform.position.x > -10)
            {
                if (!gameObject.transform.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.transform.GetComponent<AudioSource>().Play();
                    this.musicPlay = true;
                }

            };
        }
            else
        {
            if (gameObject.transform.position.x < 10)
            {
                if (!gameObject.transform.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.transform.GetComponent<AudioSource>().Play();
                    this.musicPlay = true;
                }

            }
        }

    }

    void updateIniPos()
    {
        this.initialPos = gameObject.transform.position.x;
    }
    
}
