using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SavePosition : MonoBehaviour
{
  // Start is called before the first frame update
  public void SetPosition()
  {
    AnchorControls.PlacementFinished = true;
  }

}
