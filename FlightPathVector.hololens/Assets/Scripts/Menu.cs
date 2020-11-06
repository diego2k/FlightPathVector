using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Toggle toggle;
    public static bool ActivateTunnel = false;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }


    public void ChangeScene(string sceneName)
    {
        //ActivateTunnel = toggle.isOn;
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}