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

  [JsonProperty("LateralDeviation")]
  public float LateralDeviation { get; set; }

  [JsonProperty("MaxLateralDeviation")]
  public float MaxLateralDeviation { get; set; }

  [JsonProperty("VerticalDeviation")]
  public float VerticalDeviation { get; set; }

  [JsonProperty("MaxVerticalDeviation")]
  public float MaxVerticalDeviation { get; set; }

  [JsonProperty("IASDeviation")]
  public float IASDeviation { get; set; }

  [JsonProperty("MaxIASDeviation")]
  public float MaxIASDeviation { get; set; }

  [JsonProperty("CorrectAnswers")]
  public string CorrectAnswers { get; set; }



}