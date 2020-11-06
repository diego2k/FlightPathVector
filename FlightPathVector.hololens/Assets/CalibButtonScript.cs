using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;
using Vuforia;
using System;
using HoloToolkit.Unity;

public class CalibButtonScript : MonoBehaviour, IInputClickHandler, IInputHandler
{
  public string AnchorName = "HUD-Anchor";
  public GameObject hud;
  public static bool PlacementFinished = false;

  void Start()
  {
    VuforiaBehaviour.Instance.enabled = false;
   // WorldAnchorManager.Instance.AttachAnchor(hud, AnchorName);
  }
  public void AnchorPosition()
  {
    AnchorControls.PlacementFinished = true;
  }



  public void StartCalibration()
  {
    StartFlightScript.StartManager.SetActive(false);
    //StartFlightScript.HUD.SetActive(false);

    WorldAnchorManager.Instance.RemoveAllAnchors();
    VuforiaBehaviour.Instance.enabled = true;
  }

  public void OnInputClicked(InputClickedEventData eventData)
  {
    StartFlightScript.StartManager.SetActive(true);
    //StartFlightScript.HUD.SetActive(false);
    VuforiaBehaviour.Instance.enabled = true;
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
