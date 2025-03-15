using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tilemapup : MonoBehaviour
{
   public TMP_InputField inputField;
    public GameObject Startpage;

   public void updateposition() {
    GameManager.instance.UpdatetheTile(inputField.text);
        Startpage.SetActive(false);

   }

}
