using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class updateTheA : MonoBehaviour
{
    // Start is called before the first frame update
    
    public TMP_InputField inputField;
    public GameObject Startpage;
    public GameObject but;
    public void updatetheAnimals() {
    MemoryGame.instance.updateLvlTest(inputField.text);
    Debug.Log(inputField.text);
        Startpage.SetActive(false);
        but.SetActive(false);  
       

   }
}
