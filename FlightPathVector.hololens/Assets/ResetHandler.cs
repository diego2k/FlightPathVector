using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ResetHandler : MonoBehaviour, ISpeechHandler
{
  public void OnSpeechKeywordRecognized(SpeechEventData eventData)
  {
    string command = eventData.RecognizedText;

    if (command == "Reset App")
    {
      StartFlightScript.StartManager.SetActive(true);
      StartFlightScript.HUD.SetActive(false);
      StartFlightScript.QuizManager.SetActive(false);
    }



    eventData.Use();
  }
}
