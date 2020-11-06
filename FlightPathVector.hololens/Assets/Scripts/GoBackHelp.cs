using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackHelp : MonoBehaviour, IInputClickHandler, IInputHandler
{
  public void Start()
  {
  }

  public GameObject helper;

  public void OnInputClicked(InputClickedEventData eventData)
  {
    helper.SetActive(false);
  }

  public void OnInputDown(InputEventData eventData)
  {
    //throw new System.NotImplementedException();
  }

  public void OnInputUp(InputEventData eventData)
  {
    // throw new System.NotImplementedException();
  }

  
}
