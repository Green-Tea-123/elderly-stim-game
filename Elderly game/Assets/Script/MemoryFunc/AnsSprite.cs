using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MemoryGame.instance.showedAns==false) {
            Destroy(gameObject);
        }
    }
}
