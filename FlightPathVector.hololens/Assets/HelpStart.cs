using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpStart : MonoBehaviour, ISpeechHandler
{
  public GameObject Help;
  public void OnSpeechKeywordRecognized(SpeechEventData eventData)
  {
    string command = eventData.RecognizedText;

    if (command == "Help")
    {
      if (Help.active)
      {
        Help.SetActive(false);
      }
      else
      {
        Help.SetActive(true);
      }
    }
    eventData.Use();
  }
}
