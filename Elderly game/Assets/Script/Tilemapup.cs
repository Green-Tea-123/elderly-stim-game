using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tilemapup : MonoBehaviour
{
   public TMP_InputField inputField;

   public void updateposition() {
    GameManager.instance.positioninitialization = inputField.text;
   }
}
