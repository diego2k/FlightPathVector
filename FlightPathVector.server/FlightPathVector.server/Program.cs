using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Windows.Forms;

namespace SimulatorDataReader
{
  class Program
  {
    static ConfigPanel myForm;

    static void Main(string[] args)
    {
      //StartUDPClient();
      //StartUDPClient2();
     // StartTCPConnector();
      //StartUDPListener();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      myForm = new ConfigPanel();
      Application.Run(myForm);

    }

    static void StartUDPClient()
    {
      var udpListenThread = new Thread(() =>
      {
        //UDPUtils.ListenSimulator(5259, "aircraft");
      });
      udpListenThread.Start();
    }

    static void StartUDPClient2()
    {
      var udpListenThread = new Thread(() =>
      {
        //UDPUtils.ListenSimulator(5511, "criteria");
      });
      udpListenThread.Start();
    }
    static void StartUDPClient3()
    {
      var udpListenThread = new Thread(() =>
      {
        //UDPUtils.ListenSimulator(5200, "start");
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


    static void StartTCPConnector()
    {

      var tcpConnector = new Thread(() =>
      {
        AsynchronousSocketListener.StartListening("");

      });
      tcpConnector.Start();
    }

  }
}