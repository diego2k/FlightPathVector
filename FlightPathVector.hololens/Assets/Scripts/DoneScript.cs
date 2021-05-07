using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneScript : MonoBehaviour, IInputClickHandler, IInputHandler, ISpeechHandler
{
    public Text eval;
    public Text points;
    public Text points2;

    public void Start()
    {
        Update();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        StartFlightScript.DoneManager.SetActive(false);
        StartFlightScript.CallStart();
    }


    void Update()
    {
        var sc = UserData.score + UserData.calculateScore;
        eval.text = "Congratulation! You Scored " + sc + " points!";
        points.text = "Your Approach: " + UserData.calculateScore + " points";
        points2.text = "Correct Answers: " + UserData.score;
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        string command = eventData.RecognizedText;

        if (command == "Restart")
        {
            StartFlightScript.DoneManager.SetActive(false);
            StartFlightScript.CallStart();
        }
    }

    public void OnInputDown(InputEventData eventData)
    {
    }

    public void OnInputUp(InputEventData eventData)
    {
    }
}
