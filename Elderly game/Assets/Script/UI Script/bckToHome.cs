using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bckToHome : MonoBehaviour
{
    public static bckToHome instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("bcking");
            SceneManager.LoadScene("Homepage");
        }
    }
}
