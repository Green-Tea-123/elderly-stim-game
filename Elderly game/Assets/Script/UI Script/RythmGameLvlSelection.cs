using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RythmGameLvlSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject initializePage;
    public TMP_Text textz;

    public void gameStart()
    {

        GameManager.instance.updateLvl(int.Parse(textz.text));
        GameManager.instance.PositionIni(GameManager.lvlinfo[textz.text]);
        initializePage.SetActive(false);
    }


}
