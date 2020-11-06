using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
#if WINDOWS_UWP
using Windows.Networking.Connectivity;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
#endif

public class DataListener : MonoBehaviour
{

    [Tooltip("The IPv4 Address of the machine running the Unity editor.")]
    public string ServerIP;

    [Tooltip("The connection port on the machine to use.")]
    public int ConnectionPort = 11000;

    public GameObject vector;
    private SpriteRenderer sprite;
    public Text text;
    public Text Username;
    public Text time;
    public Text speed;

    public string userString;
    public string truespeed;
    public AirCraftKinematicsData data;
    public static CriteriaData criteria;

    public static bool SuccessfulLanding = true;
    private bool SimulationRunning = true;


    public List<float> IAS_values = new List<float>();
    public List<float> LAT_values = new List<float>();
    public List<float> VERT_values = new List<float>();

    public static float Sum_Lateral;
    public static float Sum_IAS;
    public static float Sum_VER;

#if WINDOWS_UWP
    public static StreamSocket socket;
    private static string port = "11000";
    //uni
    //private static string ip = "192.168.2.40";
    //SIM Machine
    private static string ip = "192.168.8.167";

    public Stopwatch timer;
    public static double lastTime = 0;

    public void StartConnection()
    {
        SuccessfulLanding = true;
        SimulationRunning = true;
        if (socket == null)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await StartAirCraftSocket();
                    await Task.Delay(new TimeSpan(0, 0, 10));
                }
            });
        }
    }

    public async Task StartAirCraftSocket()
    {
        socket = new StreamSocket();

        // var test_ip = GetLocalIp();
        HostName serverHost = new HostName(ip);
        try
        {
            await socket.ConnectAsync(serverHost, port);
            using (DataReader reader = new DataReader(socket.InputStream))
            {
                reader.InputStreamOptions = InputStreamOptions.ReadAhead;

                while (true)
                {
                    var bytesRead = await reader.LoadAsync(900);
                    string cleanedString = reader.ReadString(bytesRead);

                    try
                    {
                        Envelope env = JsonConvert.DeserializeObject<Envelope>(cleanedString);
                        if (env.type == "aircraft")
                        {
                            if (SimulationRunning)
                            {
                                data = JsonConvert.DeserializeObject<AirCraftKinematicsData>(env.content);
                            }
                        }
                        else if (env.type == "criteria")
                        {
                            criteria = JsonConvert.DeserializeObject<CriteriaData>(env.content);
                            userString = criteria.Usercode;
                            checkCriteriaData(criteria);
                        }
                        else if (env.type == "speed")
                        {
                            var obj = env.content;
                            truespeed = obj;
                        }
                        else if (env.type == "start")
                        {
                            if (env.content == "true" && timer == null)
                            {
                                timer = new Stopwatch();
                                UserData.time = "0";
                                await Task.Run(() => timer.Start());
                            }
                            else if (env.content == "false" && timer != null)
                            {
                                SimulationRunning = false;
                                string milliseconds = timer.ElapsedMilliseconds.ToString();
                                UserData.time = milliseconds;
                                timer.Stop();
                                timer.Reset();
                                timer = null;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                    }
                }
            }
        }
        catch (System.Runtime.InteropServices.COMException e)
        {
            Debug.Log(e.Message);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        Debug.Log("TCP listner closed.");
    }

    void Update()
    {
        if (userString != "")
        {
            Username.text = userString;
        }

        if (truespeed != "")
        {
            var speedstring = String.Format("{0:0.0}", float.Parse(truespeed));
            speed.text = speedstring;
        }
        else
        {
            speed.text = "0";
        }

        if (data != null)
        {
            vector = GameObject.Find("Vector");
            sprite = vector.GetComponent<SpriteRenderer>();

            if (data.groundspeed < 5 && data.groundspeed > 0)
            {
                Vector3 point = new Vector3(0f, 5f, 0f);

                sprite.transform.localPosition = point;
            }
            else if (data.absolute_velocity_x != 0.0)
            {
                var vx = ((635 * 0.34f) / data.absolute_velocity_x) * data.absolute_velocity_y;
                var vy = ((635 * 0.34f) / data.absolute_velocity_x) * data.absolute_velocity_z * -1;

                Vector3 point = new Vector3(vx * 5, (vy * 5) - 12, data.absolute_velocity_x);

                sprite.transform.localPosition = point;
            }
            else
            {
                sprite.transform.localPosition = new Vector3(data.absolute_velocity_y, data.absolute_velocity_z, data.absolute_velocity_x);
            }

            var heightFeet = 3.28084 * data.altitude;
            var height = String.Format("{0:0}", heightFeet);
            text.text = height;
        }
        if (timer != null)
        {
            time.text = (timer.ElapsedMilliseconds / 1000).ToString();
        }

        if (!SimulationRunning || !SuccessfulLanding)
        {
            StartFlightScript.HUD.SetActive(false);
            StartFlightScript.QuizManager.SetActive(true);
        }

    }

    public static async void SendDataToCLient(string data)
    {
        using (DataWriter writer = new DataWriter(socket.OutputStream))
        {
            writer.WriteString(data);
            await writer.StoreAsync();
            writer.DetachStream();
        }
    }

    public void checkCriteriaData(CriteriaData data)
    {
        if (!float.IsNaN(data.IASDeviation))
        {
            IAS_values.Add(data.IASDeviation * data.IASDeviation);
        }
        if (!float.IsNaN(data.LateralDeviation))
        {
            LAT_values.Add(data.LateralDeviation * data.LateralDeviation);
        }
        if (!float.IsNaN(data.VerticalDeviation))
        {
            VERT_values.Add(data.VerticalDeviation * data.VerticalDeviation);
        }

        if (timer != null)
        {
            double currenttime = timer.ElapsedTicks / Stopwatch.Frequency;
            float maxLAT = 0;
            float maxIAS = 0;
            float maxVERT = 0;

            if (currenttime + 1 > lastTime)
            {
                if (LAT_values.Count > 0)
                {
                    maxLAT = LAT_values.Max();
                    float lat_integral = (1 / (data.MaxLateralDeviation - maxLAT)) * (data.MaxLateralDeviation * data.MaxLateralDeviation) / 2 - maxLAT;
                    Sum_Lateral += lat_integral;
                }
                if (IAS_values.Count > 0)
                {
                    maxIAS = IAS_values.Max();
                    float ias_integral = (1 / (data.MaxIASDeviation - maxIAS)) * (data.MaxIASDeviation * data.MaxIASDeviation) / 2 - maxIAS;
                    Sum_IAS += ias_integral;
                }
                if (IAS_values.Count > 0)
                {
                    maxVERT = VERT_values.Max();
                    float vert_integral = (1 / (data.MaxVerticalDeviation - maxVERT)) * (data.MaxVerticalDeviation * data.MaxVerticalDeviation) / 2 - maxVERT;
                    Sum_VER += vert_integral;
                }

                IAS_values = new List<float>();
                LAT_values = new List<float>();
                VERT_values = new List<float>();
                lastTime = currenttime + 1;
            }
        }
    }
#endif
}
