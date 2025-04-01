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
        this.currentStagenumber = 0;
        this.nextStageNumber=this.currentStagenumber++;
    }
    public void Updatestagenumber(int a)
    {
        this.currentStagenumber = a;    
    }
    public int getStageNo()
    {
        return this.currentStagenumber;
    }
    public int getNextStageNo(){ 
        return this.nextStageNumber; 
    }


}
