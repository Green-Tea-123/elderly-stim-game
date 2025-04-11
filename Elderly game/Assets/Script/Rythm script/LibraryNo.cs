using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LibraryNo : MonoBehaviour
{
    // Start is called before the first frame update
    public static LibraryNo instance;
    public int currentStagenumber;
    public int nextStageNumber;
    public bool moveon;
    public GameObject frontPage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (moveon) { 
        frontPage.SetActive(false);
        GameManager.instance.UpdatetheTile(GameManager.lvlinfo[getNextStageNo().ToString()]);

        GameManager.instance.updateLvl(getNextStageNo());
            moveon = !false;

    }
    }

    /*private void Update()
    {
        Updatestagenumber(GameManager.instance.lvlNo);
    }*/
    public void Updatestagenumber(int a)
    {
        this.currentStagenumber = a;
        this.nextStageNumber = a + 1;
    }
    public int getStageNo()
    {
        return this.currentStagenumber;
    }
    public int getNextStageNo(){ 
        return this.nextStageNumber; 
    }


}
