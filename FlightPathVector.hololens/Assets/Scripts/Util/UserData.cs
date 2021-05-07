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
    public string Username;
    public string CorrectAnswers;
    public string time_;

    public float FlightScore { get; set; }

    public float QuizScore { get; set; }

    public UserData() { }
    public UserData(string username, string correctAnswers, List<bool> userAnswers, string time, float flightScore, float quizScore)
    {
        Username = username;
        CorrectAnswers = correctAnswers;
        UserAnswers = userAnswers;
        time_ = time;
        FlightScore = flightScore;
        QuizScore = quizScore;
    }


    public override string ToString()
    {
        try
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        catch (Exception e)
        {
            var x = 0;
        }
        return "";
    }

}
