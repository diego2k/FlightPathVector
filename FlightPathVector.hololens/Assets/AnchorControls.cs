// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
// Ritchie Lozada (rlozada@microsoft.com)

using System;
using HoloToolkit.Unity;
using UnityEngine;
using Vuforia;

public class AnchorControls : MonoBehaviour
{

  public string ClientId = "Client";
  public string AnchorName;
  public GameObject anchoredObject;
  public GameObject startObject;
  public GameObject imageTarget;
  public static bool PlacementFinished = false;
   
  void Start()
  {
    
  }


  public void FoundMarker(Vector3 pos, Quaternion rot, Vector3 euler, Vector3 scale, Transform transform)
  {
    //WorldAnchorManager.Instance.RemoveAnchor(anchoredObject);

    float p_x = pos.x;
    float p_y = pos.y;
    float p_z = pos.z;
    var position = new Vector3(p_x, p_y, p_z);

    anchoredObject.transform.position = imageTarget.transform.position;
    anchoredObject.transform.rotation = imageTarget.transform.rotation;

    startObject.transform.position = imageTarget.transform.position;
    startObject.transform.rotation = imageTarget.transform.rotation;

    StartFlightScript.QuizManager.transform.position = imageTarget.transform.position;
    StartFlightScript.QuizManager.transform.rotation = imageTarget.transform.rotation;

    StartFlightScript.DoneManager.transform.position = imageTarget.transform.position;
    StartFlightScript.DoneManager.transform.rotation = imageTarget.transform.rotation;


    if (PlacementFinished)
    {
      VuforiaBehaviour.Instance.enabled = false;

      //anchoredObject.SetActive(false);
      //startObject.SetActive(true);
      var ids = WorldAnchorManager.Instance.AnchorStore.GetAllIds();
      //WorldAnchorManager.Instance.RemoveAllAnchors();
      WorldAnchorManager.Instance.RemoveAnchor(anchoredObject);
      WorldAnchorManager.Instance.RemoveAnchor(startObject);
      WorldAnchorManager.Instance.RemoveAnchor(StartFlightScript.QuizManager);
      WorldAnchorManager.Instance.RemoveAnchor(StartFlightScript.DoneManager);


      WorldAnchorManager.Instance.AttachAnchor(anchoredObject);
      WorldAnchorManager.Instance.AttachAnchor(startObject);
      WorldAnchorManager.Instance.AttachAnchor(StartFlightScript.QuizManager);
      WorldAnchorManager.Instance.AttachAnchor(StartFlightScript.DoneManager);
      startObject.SetActive(true);
      PlacementFinished = false;
    }
  }

}