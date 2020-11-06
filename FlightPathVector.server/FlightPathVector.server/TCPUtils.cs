﻿using Newtonsoft.Json;
using SimulatorDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// State object for reading client data asynchronously  
public class StateObject
{
  // Client  socket.  
  public Socket workSocket = null;
  // Size of receive buffer.  
  public const int BufferSize = 1024;
  // Receive buffer.  
  public byte[] buffer = new byte[BufferSize];
  // Received data string.  
  public StringBuilder sb = new StringBuilder();
}

public class AsynchronousSocketListener
{
  // Thread signal.  
  public static ManualResetEvent allDone = new ManualResetEvent(false);

  public static Dictionary<string, string> dict = new Dictionary<string, string>();

  public AsynchronousSocketListener()
  {
  }

  public static Dictionary<string, string> LogProvider()
  {
    return dict;
  }
  public static void ResetLog()
  {
    dict = new Dictionary<string, string>();
  }

  public static void StartListening(string ip)
  {
    // Establish the local endpoint for the socket.  
    // The DNS name of the computer  
    // running the listener is "host.contoso.com".  

    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 11000);

    // Create a TCP/IP socket.  
    Socket listener = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream, ProtocolType.Tcp);

    // Bind the socket to the local endpoint and listen for incoming connections.  
    try
    {
      listener.Bind(localEndPoint);
      listener.Listen(100);

      while (true)
      {
        // Set the event to nonsignaled state.  
        allDone.Reset();

        // Start an asynchronous socket to listen for connections.  
        Console.WriteLine("Waiting for a connection...");
        listener.BeginAccept(
            new AsyncCallback(AcceptCallback),
            listener);

        // Wait until a connection is made before continuing.  
        allDone.WaitOne();
      }

    }
    catch (Exception e)
    {
      // Console.WriteLine(e.ToString());
    }

    Console.WriteLine("\nPress ENTER to continue...");
    Console.Read();

  }
  static Socket handler;
  public static void AcceptCallback(IAsyncResult ar)
  {
    // Signal the main thread to continue.  
    allDone.Set();

    // Get the socket that handles the client request.  
    Socket listener = (Socket)ar.AsyncState;
    handler = listener.EndAccept(ar);

    var date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
    dict.Add(date, "Client Connected");
    // Create the state object.  
    StateObject state = new StateObject();
    state.workSocket = handler;
    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
        new AsyncCallback(ReadCallback), state);
  }

  public static void ReadCallback(IAsyncResult ar)
  {
    String content = String.Empty;

    // Retrieve the state object and the handler socket  
    // from the asynchronous state object.  
    StateObject state = (StateObject)ar.AsyncState;
    //Socket handler2 = state.workSocket;
    try
    {
      // Read data from the client socket.   
      int bytesRead = handler.EndReceive(ar);

      if (bytesRead > 0)
      {
        // There  might be more data, so store the data received so far.  
        state.sb.Append(Encoding.ASCII.GetString(
            state.buffer, 0, bytesRead));

        // Check for end-of-file tag. If it is not there, read   
        // more data.  

        var data = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);
        content = state.sb.ToString();
        try
        {
          // var toSend = JsonConvert.DeserializeObject<UserData>(content);

          UDPUtils.SendToSimulator(data);
          state.buffer = new byte[1024];
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          Console.WriteLine("not valid");
        }


        // Not all data received. Get more.  
        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
        new AsyncCallback(ReadCallback), state);

      }
    }
    catch (SocketException e)
    {

    }

  }

  public static void Send(String data)
  {
    // Convert the string data to byte data using ASCII encoding.  
    byte[] byteData = Encoding.ASCII.GetBytes(data);

    var missingBytes = 900 - byteData.Length;
    Array.Resize(ref byteData, byteData.Length + missingBytes);
    var str = System.Text.Encoding.Default.GetString(byteData);



    if (handler != null)
    {
      bool ConnectionClosed = handler.Poll(1000, SelectMode.SelectRead);
      if (!ConnectionClosed)
      {

        // Begin sending the data to the remote device.  
        handler.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), handler);
      }
    }
  }

  private static void Send(Socket handler, String data)
  {
    // Convert the string data to byte data using ASCII encoding.  
    byte[] byteData = Encoding.ASCII.GetBytes(data);

    // Begin sending the data to the remote device.  
    handler.BeginSend(byteData, 0, byteData.Length, 0,
        new AsyncCallback(SendCallback), handler);
  }

  private static void SendCallback(IAsyncResult ar)
  {
    try
    {
      // Retrieve the socket from the state object.  
      Socket handler = (Socket)ar.AsyncState;

      // Complete sending the data to the remote device.  
      if (handler != null)
      {
        bool ConnectionClosed = handler.Poll(1000, SelectMode.SelectRead);
        if (!ConnectionClosed)
        {
          int bytesSent = handler.EndSend(ar);
          Console.WriteLine("Sent {0} bytes to client.", bytesSent);
        }
      }


      // handler.Shutdown(SocketShutdown.Both);
      //handler.Close();

    }
    catch (Exception e)
    {
      Console.Write("Client Disconnected");
      Console.WriteLine(e.ToString());
    }
  }




}