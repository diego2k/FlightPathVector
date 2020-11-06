using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour, IInputClickHandler, IInputHandler
{

  public void OnInputClicked(InputClickedEventData eventData)
  {
    try
    {
      SceneManager.LoadScene("Quiz", LoadSceneMode.Single);
    }
    catch (Exception e)
    {

    }

  }

  public void OnInputDown(InputEventData eventData)
  {
    throw new System.NotImplementedException();
  }

  public void OnInputUp(InputEventData eventData)
  {
    throw new System.NotImplementedException();
  }
}