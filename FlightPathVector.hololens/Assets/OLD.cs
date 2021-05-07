using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using HoloToolkit.Unity;
using System.Threading.Tasks;

public class TestSpeechTest2 : MonoBehaviour, IInputClickHandler, IInputHandler, ISpeechHandler
{
    //  public Button button1;
    //  public Button button2;
    //  public Button button3;
    //  public Button button4;
    //  public Button button5;
    //  public Button button6;
    //  public Text help;

    //  public Button finish;
    //  private Button activeButton;


    //  public void Start()
    //  {
    //    help.enabled = false;
    //  }

    //  public void OnInputClicked(InputClickedEventData eventData)
    //  {
    //  }

    //  public void OnInputDown(InputEventData eventData)
    //  {
    //  }

    //  public void OnInputUp(InputEventData eventData)
    //  {
    //  }

    //  public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    //  {
    //    string command = eventData.RecognizedText;

    //    if (command == "finish")
    //    {
    //      FinishSession();
    //    }
    //    else
    //    {
    //      CallTest(command);
    //    }
    //    eventData.Use();
    //  }

    //  public void CallTest(string command)
    //  {
    //    switch (command)
    //    {
    //      case "one":
    //        {
    //          activeButton = button1;
    //        }
    //        break;
    //      case "two":
    //        {
    //          activeButton = button2;
    //        }
    //        break;
    //      case "three":
    //        {
    //          activeButton = button3;
    //        }
    //        break;
    //      case "four":
    //        {
    //          activeButton = button4;
    //        }
    //        break;
    //      case "five":
    //        {
    //          activeButton = button5;
    //        }
    //        break;
    //      case "six":
    //        {
    //          activeButton = button6;
    //        }
    //        break;
    //      case "help":
    //        {
    //          help.enabled = !help.enabled;
    //        }
    //        break;
    //      default:
    //        break;

    //    }

    //    try
    //    {
    //      Image image = activeButton.GetComponent<Image>();
    //      string hexCode = "#84D0FF";
    //      Color lightblue;
    //      ColorUtility.TryParseHtmlString(hexCode, out lightblue);

    //      if (image != null)
    //      {
    //        if ((int)(image.color.r * 1000) == (int)(lightblue.r * 1000))

    //        {
    //          image.color = Color.yellow;
    //        }
    //        else
    //        {
    //          image.color = lightblue;
    //        }
    //      }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //  }

    //  public void FinishSession()
    //  {
    //    List<string> answers = new List<string>();

    //    GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
    //    string hexCode = "#84D0FF";
    //    Color lightblue;
    //    ColorUtility.TryParseHtmlString(hexCode, out lightblue);

    //    foreach (var button in buttons)
    //    {
    //      if (button.GetComponent<Image>().color == Color.yellow)
    //      {
    //        answers.Add(button.GetComponentInChildren<Text>().text);
    //        Image image = button.GetComponent<Image>();
    //        image.color = lightblue;
    //      }
    //    }

    //#if WINDOWS_UWP

    //    try
    //    {
    //      if (DataListener.socket != null)
    //      {
    //        var time = "";
    //        if (UserData.time != null)
    //        {
    //          time = (float.Parse(UserData.time) / 1000).ToString();
    //        }
    //        else
    //        {
    //          UserData.time = "7";
    //        }
    //        UserData userData = new UserData(DataListener.criteria.Usercode, DataListener.criteria.CorrectAnswers, null, UserData.time, UserData.score);
    //        var json = userData.ToString();

    //        DataListener.SendDataToCLient(json);
    //        StartFlightScript.QuizManager.SetActive(false);

    //        //StartFlightScript.Missile.SetActive(true);
    //        //Task.Delay(TimeSpan.FromSeconds(7));
    //        // StartFlightScript.Missile.SetActive(false);

    //        StartFlightScript.DoneManager.SetActive(true);

    //        //

    //      }
    //    }
    //    catch(Exception e)
    //    {

    //    }

    //#endif
}
}
