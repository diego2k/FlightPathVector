using FlightPathVector.server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace FlightPathVector.server
{
    public class UDPUtils
    {
        public static void ListenSimulator(int port, string type, int size)
        {
            var endpoint = new IPEndPoint(IPAddress.Any, port);
            UdpClient receivingUdpClient = new UdpClient(endpoint);
            receivingUdpClient.Client.ReceiveBufferSize = size;

            receivingUdpClient.EnableBroadcast = true;
            receivingUdpClient.Client.EnableBroadcast = true;

            while (true)
            {
                try
                {
                    Byte[] receiveBytes = receivingUdpClient.Receive(ref endpoint);

                    if (type == "aircraft")
                    {
                        var json = AircraftKinematicsData.ConvertAircraftKinematicsData(receiveBytes);
                        AsynchronousSocketListener.Send(json);
                    }
                    else if (type == "criteria")
                    {
                        var json = CriteriaData.ConvertCriteriaData(receiveBytes);
                        AsynchronousSocketListener.Send(json);
                    }
                    else if (type == "speed")
                    {
                        var json = CriteriaData.ConvertSpeedData(receiveBytes);
                        AsynchronousSocketListener.Send(json);
                    }
                    else
                    {
                        var json = AircraftKinematicsData.CheckSimulationRunning(receiveBytes);
                        AsynchronousSocketListener.Send(json);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static void SendToSimulator(string toSend)
        {
            //string data = "{\"UserAnswers\":[false,false,false,false,false,true],\"username\":\"USER/22/5\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\",\"CorrectAnswers\":\"011010\",\"time_\":\"19\",\"score_\":4}";
            string data = "{\"UserAnswers\":[false,false,false,false],\"username\":\"RB\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\",\"CorrectAnswers\":\"0101\",\"time_\":\"7.304\",\"score_\":0.0,\"FlightScore\":82.85173,\"QuizScore\":50.0}";
            var send = JsonConvert.DeserializeObject<UserData>(data);

            var cleaned_user = send.username.Replace("\0", string.Empty);
            string user = Regex.Replace(cleaned_user, @"[^0-9a-zA-Z]+", "-");
            var date = DateTime.Now.ToString("M/d/yyyy");
            string directory = Environment.CurrentDirectory;
            var fileName = directory + "\\" + user + " " + date + ".csv";

            var correctAnswerArray = Utils.GetArrayFromString(send.CorrectAnswers);

            if (!File.Exists(fileName))
            {
                string csvRow = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                  "UserCode", "DateTime", "Time", "FlightScore", "QuizScore",
                  "User: Too short", "User: Too far", "User: Too slow", "User: Too fast",
                  "Sim: Too short", "Sim: Too far", "Sim: Too slow", "Sim: Too fast") + Environment.NewLine;

                File.WriteAllText(fileName, csvRow);
            }

            string dataRow = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
              send.username, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), send.Time, send.FlightScore, send.QuizScore,
              send.UserAnswers[0], send.UserAnswers[1], send.UserAnswers[2], send.UserAnswers[3],
              correctAnswerArray[0], correctAnswerArray[1], correctAnswerArray[2], correctAnswerArray[3]) + Environment.NewLine;

            File.AppendAllText(fileName, dataRow);

            int[] byteLengthList = { 16, 1, 1, 2, 2 };

            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(send.username);
            Array.Resize(ref bytes, 16);

            var correctAnswers = Utils.GetBitsFromString(send.CorrectAnswers);


            var userAnswerbyte = Utils.GetBitsfromArray(send.UserAnswers);

            var time_f = Convert.ToSingle(send.Time, CultureInfo.InvariantCulture.NumberFormat);
            var q_score_f = Convert.ToSingle(send.QuizScore, CultureInfo.InvariantCulture.NumberFormat);
            var f_score_f = Convert.ToSingle(send.FlightScore, CultureInfo.InvariantCulture.NumberFormat);

            var time = BitConverter.GetBytes(time_f);
            var QuizScore = BitConverter.GetBytes(q_score_f);
            var FlightScore = BitConverter.GetBytes(q_score_f);

            var byteIndex = new byte[2];
            var byteHeader = new byte[2];
            byteHeader[0] = 0x0E;
            byteHeader[1] = 00;

            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 5510);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var index = 0;

            while (stopwatch.Elapsed < TimeSpan.FromSeconds(30))
            {
                byte[] intBytes = BitConverter.GetBytes(index);
                Array.Reverse(intBytes);
                byte[] res = intBytes;
                byteIndex = res;

                IEnumerable<byte> rv = byteHeader.Concat(byteHeader).Concat(bytes).Concat(Encoding.ASCII.GetBytes(send.username))
                  .Concat(correctAnswers).Concat(userAnswerbyte).Concat(time).Concat(QuizScore).Concat(FlightScore);

                byte[] result = rv.ToArray();

                index++;
                client.Send(result, result.Length, ip);
            }
            client.Close();

        }

    }
}