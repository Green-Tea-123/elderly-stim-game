using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttoninterface : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextPage;
    public void nextUI()
    {
        nextPage.SetActive(true);
    }
    
}
