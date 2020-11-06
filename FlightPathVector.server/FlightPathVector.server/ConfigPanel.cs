using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorDataReader
{
  public partial class ConfigPanel : Form
  {
    public String MyIp = "";


    public ConfigPanel()
    {
      InitializeComponent();
      //string IPAddress = textBox1.Text;
      IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
      IPAddress ipAddress = ipHostInfo.AddressList[1];

      foreach (var ipadress in ipHostInfo.AddressList)
      {
        string str = ipadress.ToString();

        if (str.StartsWith("192.168."))
        {
          MyIp = ipadress.ToString();
          break;
        }


      }

      textBox1.Text = MyIp;


    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {


      MyIp = textBox1.Text;
      StartUDPClient();
      StartUDPClient2();
      StartUDPClient3();
      StartUDPClient4();
      StartTCPConnector(MyIp);
      StartUDPListener();


      //  listView1.Items.Add("TEst");
      // listView1.Items[listView1.Items.Count - 1].SubItems.Add("John Smith");

      textBox1.Enabled = false;
      startButton.Enabled = false;
      startButton.BackColor = Color.LightGreen;
      StartLog(listView1);

     // UDPUtils.SendToSimulator(null);
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    public static void StartLog(ListView l1)
    {
      var logger = new Thread(() =>
      {
        while (true)
        {
          Dictionary<string, string> log = AsynchronousSocketListener.LogProvider();
          if (log.Count != 0)
          {
            l1.Invoke((MethodInvoker)delegate
            {
              // Running on the UI thread
              l1.Items.Add(log.First().Key); ;
              l1.Items[l1.Items.Count - 1].SubItems.Add(log.First().Value);
            });

            AsynchronousSocketListener.ResetLog();
          }
        }
      });
      logger.Start();
    }

    static void StartUDPClient()
    {
      var udpListenThread = new Thread(() =>
      {
        UDPUtils.ListenSimulator(5259, "aircraft", 124);
      });
      udpListenThread.Start();
    }

    static void StartUDPClient2()
    {
      var udpListenThread = new Thread(() =>
      {
        UDPUtils.ListenSimulator(5511, "criteria", 70);
      });
      udpListenThread.Start();
    }
    static void StartUDPClient3()
    {
      var udpListenThread = new Thread(() =>
      {
        UDPUtils.ListenSimulator(5370, "start", 16);
      });
      udpListenThread.Start();
    }

    static void StartUDPClient4()
    {
      var udpListenThread = new Thread(() =>
      {
        UDPUtils.ListenSimulator(9216, "speed", 24);
        //UDPUtils.TestRead();
      });
      udpListenThread.Start();
    }

    static void StartUDPListener()
    {
      var udpListenThread = new Thread(() =>
      {
        //UDPUtils.ListenSimulatorSignals();
      });
      udpListenThread.Start();
    }


    static void StartTCPConnector(string ip)
    {

      var tcpConnector = new Thread(() =>
      {
        AsynchronousSocketListener.StartListening(ip);

      });
      tcpConnector.Start();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
      //var json_send = "{\"Usercode\":\"USER/24/5\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\\u0000\",\"TooLeft\":false,\"TooRight\":true,\"TooLow\":true,\"TooHigh\":false,\"TooSlow\":true,\"TooFast\":false,\"LateralDeviation\":\"NaN\",\"MaxLateralDeviation\":0.75000002087065143,\"VerticalDeviation\":\"NaN\",\"MaxVerticalDeviation\":0.75000002087065143,\"IASDeviation\":2651.6507915848474,\"CorrectAnswers\":\"011010\",\"MaxIASDeviation\":147.377477910223}";
      var json_send = "{\"Content\":\"{\\\"Usercode\\\":\\\"PATRICK\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\\u0000\\\",\\\"TooShort\\\":false,\\\"TooFar\\\":false,\\\"TooSlow\\\":false,\\\"TooFast\\\":false,\\\"CorrectAnswers\\\":\\\"000000\\\",\\\"Points\\\":0.0}\",\"type\":\"criteria\"}";

      var json = new { Content = json_send, type = "criteria" };
      string test_json = JsonConvert.SerializeObject(json);
      AsynchronousSocketListener.Send(test_json);
    }

    private void runSimulationButton_Click(object sender, EventArgs e)
    {
      var json = new { Content = true, type = "start" };
      var json_send = JsonConvert.SerializeObject(json);
      AsynchronousSocketListener.Send(json_send);
    }

    public bool ValidateIPv4(string ipString)
    {
      if (String.IsNullOrWhiteSpace(ipString))
      {
        return false;
      }

      string[] splitValues = ipString.Split('.');
      if (splitValues.Length != 4)
      {
        return false;
      }

      byte tempForParsing;

      return splitValues.All(r => byte.TryParse(r, out tempForParsing));
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      var json = new { Content = false, type = "start" };
      var json_send = JsonConvert.SerializeObject(json);
      AsynchronousSocketListener.Send(json_send);
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}
