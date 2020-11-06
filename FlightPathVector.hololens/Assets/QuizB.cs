using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class QuizB : MonoBehaviour, IInputClickHandler, IInputHandler
{

  public void OnInputClicked(InputClickedEventData eventData)
  {
    StartFlightScript.HUD.SetActive(false);
    StartFlightScript.QuizManager.SetActive(true);
  }

  public void OnInputDown(InputEventData eventData)
  {
    // throw new System.NotImplementedException();
  }

  public void OnInputUp(InputEventData eventData)
  {
    //throw new System.NotImplementedException();
  }
}