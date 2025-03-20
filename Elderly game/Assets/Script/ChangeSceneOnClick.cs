using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnClick : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    [SerializeField]
    private Button button;

    private void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClicked);
    }

    void onClicked() {
        SceneManager.LoadScene(nextSceneName);
    }
}
