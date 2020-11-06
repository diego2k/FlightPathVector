using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPositioning : MonoBehaviour, IInputClickHandler, IInputHandler
{

  public GameObject HUD;

  public void OnInputClicked(InputClickedEventData eventData)
  {
    if (HUD.active == true)
    {
      HUD.SetActive(false);
    }
    else
    {
      HUD.SetActive(true);
    }
  }

  //sedond button (test)
  public void ShowHideMarker()
  {
    if (StartFlightScript.HUD.active == true)
    {
      StartFlightScript.HUD.SetActive(false);
    }
    else
    {
      StartFlightScript.HUD.SetActive(true);
    }
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
