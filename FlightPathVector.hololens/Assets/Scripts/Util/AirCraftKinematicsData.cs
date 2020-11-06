using Newtonsoft.Json;

public class AirCraftKinematicsData
{

    [JsonProperty("simulated_Time")]
    public string Simulated_Time { get; set; }

    [JsonProperty("longitude")]
    public string longitude { get; set; }

    [JsonProperty("latitude")]
    public string latitude { get; set; }

    [JsonProperty("altitude")]
    public double altitude { get; set; }

    [JsonProperty("true_heading")]
    public float true_heading { get; set; }

    [JsonProperty("pitch_angle")]
    public float pitch_angle { get; set; }

    [JsonProperty("roll_angle")]
    public float roll_angle { get; set; }

    [JsonProperty("absolute_velocity_x")]
    public float absolute_velocity_x { get; set; }

    [JsonProperty("absolute_velocity_y")]
    public float absolute_velocity_y { get; set; }

    [JsonProperty("absolute_velocity_z")]
    public float absolute_velocity_z { get; set; }

  [JsonProperty("ground_speed")]
  public float groundspeed { get; set; }

}