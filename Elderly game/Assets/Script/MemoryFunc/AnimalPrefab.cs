using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public bool hasStart = false;
    void Start()
    {
        moveSpeed = moveSpeed / MemoryGame.instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x<20 && gameObject.transform.position.x> 0) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
        if (!hasStart)
        {
            if (Input.anyKey)
           
            hasStart = true;

        }
        else
        {
            if (gameObject.transform.position.x < 0) {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
            }
            else{
                transform.position += new Vector3(- moveSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
