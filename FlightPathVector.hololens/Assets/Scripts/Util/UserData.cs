using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class UserData
{
  public static string time;

  public List<bool> UserAnswers;
  public string username;
  public string CorrectAnswers;
  public string time_;
  public static int score;
  public static float calculateScore;
  public float score_;

  public UserData() { }
  public UserData(string username, string CorrectAnswers, List<bool> UserAnswers, string time, float score)
  {
    this.username = username;
    this.UserAnswers = UserAnswers;
    this.CorrectAnswers = CorrectAnswers;
    this.time_ = time;
    this.score_ = score;
  }


  public override string ToString()
  {
    try
    {
      string json = JsonConvert.SerializeObject(this);
      return json;
    }
    catch(Exception e)
    {
      var x = 0;
    }
    return "";
  }

}
