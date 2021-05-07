using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        if (DataListener.LAST_USERDATA != null)
        {
            eval.text = $"Congratulation! You Scored {(DataListener.LAST_USERDATA.FlightScore + DataListener.LAST_USERDATA.QuizScore).ToString("F0", CultureInfo.InvariantCulture)} Points!";
            points.text = "Your Approach: " + DataListener.LAST_USERDATA.FlightScore.ToString("F0", CultureInfo.InvariantCulture) + " Points";
            points2.text = "Correct Answers: " + DataListener.LAST_USERDATA.QuizScore.ToString("F0", CultureInfo.InvariantCulture);
        }
        else
        {
            eval.text = "No data available!";
        }
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
