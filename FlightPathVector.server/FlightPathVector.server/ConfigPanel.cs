using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FlightPathVector.server
{
    public partial class ConfigPanel : Form
    {
        public ConfigPanel()
        {
            InitializeComponent();
            Load += ConfigPanel_Load;
        }

        private void ConfigPanel_Load(object sender, EventArgs e)
        {
            (new Thread(() =>
            {
                UDPUtils.ListenSimulator(5259, "aircraft", 124);
            })).Start();

            (new Thread(() =>
            {
                UDPUtils.ListenSimulator(5511, "criteria", 70);
            })).Start();

            (new Thread(() =>
            {
                UDPUtils.ListenSimulator(5370, "start", 16);
            })).Start();

            (new Thread(() =>
            {
                UDPUtils.ListenSimulator(9216, "speed", 24);
            })).Start();

            (new Thread(() =>
            {
                try
                {
                    AsynchronousSocketListener.StartListening();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }

            })).Start();

            (new Thread(() =>
            {
                while (true)
                {
                    lblStatus.Invoke((MethodInvoker)delegate
                    {
                        if (AsynchronousSocketListener.ConnectionSatus)
                        {
                            lblStatus.Text = "Connected";
                            lblStatus.BackColor = Color.Green;
                        }
                        else
                        {
                            lblStatus.Text = "Disconnected";
                            lblStatus.BackColor = Color.Red;
                        }
                    });
                    Thread.Sleep(1000);
                }
            })).Start();
        }

        private void SendCriteria_Click(object sender, EventArgs e)
        {
            //var json_send = "{\"Usercode\":\"USER/24/5\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\",\"TooLeft\":false,\"TooRight\":true,\"TooLow\":true,\"TooHigh\":false,\"TooSlow\":true,\"TooFast\":false,\"LateralDeviation\":\"NaN\",\"MaxLateralDeviation\":0.75000002087065143,\"VerticalDeviation\":\"NaN\",\"MaxVerticalDeviation\":0.75000002087065143,\"IASDeviation\":2651.6507915848474,\"CorrectAnswers\":\"011010\",\"MaxIASDeviation\":147.377477910223}";
            var json_send = "{\"Content\":\"{\\\"Usercode\\\":\\\"PATRICK\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\",\\\"TooShort\\\":false,\\\"TooFar\\\":false,\\\"TooSlow\\\":false,\\\"TooFast\\\":false,\\\"CorrectAnswers\\\":\\\"000000\\\",\\\"Points\\\":0.0}\",\"type\":\"criteria\"}";

            var json = new { Content = json_send, type = "criteria" };
            string test_json = JsonConvert.SerializeObject(json);
            AsynchronousSocketListener.Send(test_json);
        }

        private void StartSimulation_Click(object sender, EventArgs e)
        {
            var json = new { Content = true, type = "start" };
            var json_send = JsonConvert.SerializeObject(json);
            AsynchronousSocketListener.Send(json_send);
        }

        private void StopSimulation_Click(object sender, EventArgs e)
        {
            var json = new { Content = false, type = "start" };
            var json_send = JsonConvert.SerializeObject(json);
            AsynchronousSocketListener.Send(json_send);
        }

    }
}
