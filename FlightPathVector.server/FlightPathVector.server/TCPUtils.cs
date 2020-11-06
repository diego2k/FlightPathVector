using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FlightPathVector.server
{
    // State object for reading client data asynchronously  
    public class StateObject
    {
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener
    {
        private static Socket handler;
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static bool ConnectionSatus = false;
        public AsynchronousSocketListener()
        {
        }

        public static void StartListening()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 11000);
            Socket listener = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true)
            {
                allDone.Reset();
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                allDone.WaitOne();
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();
            if (ConnectionSatus) throw new Exception("A second client connected!");
            ConnectionSatus = true;

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject();
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            string content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            try
            {
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));

                    content = state.sb.ToString();
                    try
                    {
                        UDPUtils.SendToSimulator(content);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message} \n {e.StackTrace}");
                    }

                    // Data is less than 1024 bytes so 
                    state = new StateObject();
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                }
            }
            catch (SocketException e)
            {
                ConnectionSatus = false;
                Console.WriteLine($"{e.Message} \n {e.StackTrace}");
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
                    Console.WriteLine(data);
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} \n {e.StackTrace}");
            }
        }

    }
}