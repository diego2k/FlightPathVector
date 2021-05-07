using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class FinishHandler : MonoBehaviour, IInputClickHandler, IInputHandler
{
  public Sprite check;
  public Sprite cross;

  public bool QuizFinished = false;

  void Start()
  {
    var text = GameObject.Find("Question").GetComponent<Text>();

    var ch1 = GameObject.Find("Image 1").GetComponent<Image>();
    var ch2 = GameObject.Find("Image 2").GetComponent<Image>();
    var ch3 = GameObject.Find("Image 3").GetComponent<Image>();
    var ch4 = GameObject.Find("Image 4").GetComponent<Image>();

    ch1.enabled = false;
    ch2.enabled = false;
    ch3.enabled = false;
    ch4.enabled = false;

  }
  public void OnInputClicked(InputClickedEventData eventData)
  {
    var ch1 = GameObject.Find("Image 1").GetComponent<Image>();
    var ch2 = GameObject.Find("Image 2").GetComponent<Image>();
    var ch3 = GameObject.Find("Image 3").GetComponent<Image>();
    var ch4 = GameObject.Find("Image 4").GetComponent<Image>();
    var text = GameObject.Find("Question").GetComponent<Text>();


    var finish = GameObject.Find("Finish").GetComponentInChildren<Text>();

    if (QuizFinished)
    {

      GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
      string hexCode = "#84D0FF";
      Color lightblue;
      ColorUtility.TryParseHtmlString(hexCode, out lightblue);

      var index = 0;
      foreach (var button in buttons)
      {
        if (button.GetComponent<Image>().color == Color.yellow)
        {
          Image image = button.GetComponent<Image>();
          image.color = lightblue;
        }
        index++;
      }

      StartFlightScript.QuizManager.SetActive(false);

      StartFlightScript.DoneManager.SetActive(true);

      QuizFinished = false;

      ch1.enabled = false;
      ch2.enabled = false;
      ch3.enabled = false;
      ch4.enabled = false;
      finish.text = "Finish";
      text.text = "Rate your approach!";
      
    }
    else
    {

      //temporary
      List<string> answers = new List<string>();

      List<bool> user_answers = new List<bool>();
      for(var i = 0; i<6; i++)
      {
        user_answers.Add(false);
      }

      GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
      string hexCode = "#84D0FF";
      Color lightblue;
      ColorUtility.TryParseHtmlString(hexCode, out lightblue);

      var index = 0;
      foreach (var button in buttons)
      {
        user_answers[index] = false;
        if (button.GetComponent<Image>().color == Color.yellow)
        {
          user_answers[index] = true;
          answers.Add(button.GetComponentInChildren<Text>().text);
          Image image = button.GetComponent<Image>();
          //image.color = lightblue;
        }
        index++;
      }

#if WINDOWS_UWP

      try
      {
        if (DataListener.socket != null)
        {
          var time = "";
          if (UserData.time != null)
          {
            time = (float.Parse(UserData.time) / 1000).ToString();
          }
          else
          {
            UserData.time = "0";
          }

          text.text = "YOUR RESULTS";

          ch1.enabled = true;
          ch2.enabled = true;
          ch3.enabled = true;
          ch4.enabled = true;

          var checkSprite = Resources.Load<Sprite>("check");
          var crossSprite = Resources.Load<Sprite>("cross");

          ch1.sprite = (DataListener.criteria.TooShort == user_answers[0]) ? checkSprite : crossSprite;
          ch2.sprite = (DataListener.criteria.TooFar == user_answers[1]) ? checkSprite : crossSprite;
          ch3.sprite = (DataListener.criteria.TooSlow == user_answers[2]) ? checkSprite : crossSprite;
          ch4.sprite = (DataListener.criteria.TooFast == user_answers[3]) ? checkSprite : crossSprite;

          int score = 0;
          score += (DataListener.criteria.TooShort == user_answers[0]) ? 2 : 0;
          score += (DataListener.criteria.TooFar == user_answers[1]) ? 2 : 0;
          score += (DataListener.criteria.TooSlow == user_answers[2]) ? 2 : 0;
          score += (DataListener.criteria.TooFast == user_answers[3]) ? 2 : 0;


          var calculated_score = DataListener.Sum_IAS + DataListener.Sum_Lateral + DataListener.Sum_VER;


          UserData.score = score;
          UserData.calculateScore = calculated_score;
          finish.text = "Continue";
          UserData userData = new UserData(DataListener.criteria.Usercode, DataListener.criteria.CorrectAnswers, user_answers, time, UserData.score + calculated_score);
          var json = userData.ToString();

          DataListener.SendDataToCLient(json);

          QuizFinished = true;
        }

      }
      catch (Exception e)
      {
      }
#endif


    }
  }

  public void OnInputDown(InputEventData eventData)
  {
    // throw new NotImplementedException();
  }

  public void OnInputUp(InputEventData eventData)
  {
    // throw new NotImplementedException();
  }
}