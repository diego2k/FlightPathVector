using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class QuizButton : MonoBehaviour, IInputClickHandler, IInputHandler
{

  public void OnInputClicked(InputClickedEventData eventData)
  {
    AnchorControls.PlacementFinished = true;
  }

  public void SetQuiz()
  {
    AnchorControls.PlacementFinished = true;
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