using Newtonsoft.Json;

public class CriteriaData
{

    [JsonProperty("Usercode")]
    public string Usercode { get; set; }

    [JsonProperty("TooShort")]
    public bool TooShort { get; set; }

    [JsonProperty("TooFar")]
    public bool TooFar { get; set; }

    [JsonProperty("TooFast")]
    public bool TooFast { get; set; }

    [JsonProperty("TooSlow")]
    public bool TooSlow { get; set; }

    [JsonProperty("CorrectAnswers")]
    public string CorrectAnswers { get; set; }

    [JsonProperty("Points")]
    public float Points { get; set; }

}