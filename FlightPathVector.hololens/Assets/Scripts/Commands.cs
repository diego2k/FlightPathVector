using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Commands : MonoBehaviour, IInputClickHandler, IInputHandler
{
  public GameObject Help;
  // Start is called before the first frame update
  public void OnInputClicked(InputClickedEventData eventData)
  {
    Help.SetActive(true);
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
