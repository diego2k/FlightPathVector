using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightPathVector.server.Models
{
    public class UserData
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("UserAnswers")]
        public List<bool> UserAnswers { get; set; }

        [JsonProperty("time_")]
        public string Time { get; set; }

        [JsonProperty("CorrectAnswers")]
        public string CorrectAnswers { get; set; }

        [JsonProperty("FlightScore")]
        public string FlightScore { get; set; }

        [JsonProperty("QuizScore")]
        public string QuizScore { get; set; }
    }
}