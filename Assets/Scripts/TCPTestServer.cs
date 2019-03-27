using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

//public class TCPTestServer : MonoBehaviour
//{
//    #region private members 	
//    / <summary> 	
//    / TCPListener to listen for incomming TCP connection 	
//    / requests. 	
//    / </summary> 	
//    private TcpListener tcpListener;
//    / <summary> 
//    / Background thread for TcpServer workload. 	
//    / </summary> 	
//    private Thread tcpListenerThread;
//    / <summary> 	
//    / Create handle to connected tcp client. 	
//    / </summary> 	
//    private TcpClient connectedTcpClient;
//    #endregion

//    public GameManager gameManager = null;

//    private void OnApplicationQuit()
//    {
//        if (tcpListenerThread.IsAlive)
//            tcpListenerThread.Abort();
//    }
//     Use this for initialization
//    void Start()
//    {
//        CreateServeur();
//        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
//        if (!gameManager)
//            Debug.LogError("TCPServer : gameManager is null!");
//    }

//    void CreateServeur()
//    {
//        Debug.Log("New server");
//         Start TcpServer background thread 		
//        tcpListenerThread = new Thread(new ThreadStart(ListenForIncommingRequests));
//        tcpListenerThread.IsBackground = true;
//        tcpListenerThread.Start();
//    }

//    void ReCreateServeur()
//    {
//        Debug.Log("Re creating server");
//        /* if (tcpListenerThread.IsAlive == true)
//             tcpListenerThread.Join();*/
//        CreateServeur();
//    }
//    / <summary> 	
//    / Runs in background TcpServerThread; Handles incomming TcpClient requests 	
//    / </summary> 	
//    private void ListenForIncommingRequests()
//    {
//        try
//        {
//             Create listener on localhost port 8052. 			
//            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9001);
//            tcpListener.Start();
//            Debug.Log("Server is listening");
//            Byte[] bytes = new Byte[1024];
//            while (true)
//            {
//                Debug.Log("Before client connection");
//                using (connectedTcpClient = tcpListener.AcceptTcpClient())
//                {

//                    Debug.Log("Accepted client");
//                     Get a stream object for reading 					
//                    using (NetworkStream stream = connectedTcpClient.GetStream())
//                    {
//                        Debug.Log("incomming request ?");
//                        int length;
//                         Read incomming stream into byte arrary. 						
//                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
//                        {
//                            Debug.Log("reading request");
//                            var incommingData = new byte[length];
//                            Array.Copy(bytes, 0, incommingData, 0, length);
//                             Convert byte array to string message. 							
//                            string clientMessage = Encoding.ASCII.GetString(incommingData);
//                            Debug.Log("Received message: " + clientMessage);
//                            gameManager.keyManager.parseMessage(clientMessage);
//                        }
//                    }
//                }
//            }
//        }
//        catch (Exception e)
//        {
//            Debug.Log("Execption !" + e.ToString());
//            tcpListener.Stop();
//        }
//    }
//}

#if !UNITY_EDITOR
using System.Threading.Tasks;
#endif

public class TCPTestServer : MonoBehaviour
{

#if !UNITY_EDITOR
    private bool _useUWP = true;
    private Windows.Networking.Sockets.StreamSocket socket;
    private Task exchangeTask;
#endif

#if UNITY_EDITOR

        // <summary> 	
        // TCPListener to listen for incomming TCP connection 	
        // requests.
        // </summary> 	
        private TcpListener tcpListener;
        // <summary> 
        // Background thread for TcpServer workload.
        // </summary> 	
        private Thread tcpListenerThread;
        // <summary> 	
        // Create handle to connected tcp client.
        // </summary> 	
        private TcpClient connectedTcpClient;

    private bool _useUWP = false;
    System.Net.Sockets.NetworkStream stream;
    private Thread exchangeThread;
#endif

    private Byte[] bytes = new Byte[256];
    private StreamWriter writer;
    private StreamReader reader;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (!gameManager)
            Debug.LogError("TCPServer : gameManager is null!");
    }

    public void Connect(string host, string port)
    {
        if (_useUWP)
        {
            ConnectUWP(host, port);
        }
        else
        {
            CreateServeur();
        }
    }



#if UNITY_EDITOR
    private void ConnectUWP(string host, string port)
#else
    private async void ConnectUWP(string host, string port)
#endif
    {
#if UNITY_EDITOR
        errorStatus = "UWP TCP client used in Unity!";
#else
        try
        {
            if (exchangeTask != null) StopExchange();
        
            socket = new Windows.Networking.Sockets.StreamSocket();
            Windows.Networking.HostName serverHost = new Windows.Networking.HostName(host);
            await socket.ConnectAsync(serverHost, port);
        
            Stream streamOut = socket.OutputStream.AsStreamForWrite();
            writer = new StreamWriter(streamOut) { AutoFlush = true };
        
            Stream streamIn = socket.InputStream.AsStreamForRead();
            reader = new StreamReader(streamIn);

            RestartExchange();
            successStatus = "Connected!";
        }
        catch (Exception e)
        {
            errorStatus = e.ToString();
            Debug.LogError("Fail serveur creation : " + e.ToString());
        }
#endif
    }

    private void ConnectUnity()
    {
#if !UNITY_EDITOR
        errorStatus = "Unity TCP client used in UWP!";
#else
        try
        {
            if (exchangeThread != null) StopExchange();

            tcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 5050);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[1024];
            TcpClient connectedTcpClient;
            while (true)
            {
                Debug.Log("Before client connection");
                using (connectedTcpClient = tcpListener.AcceptTcpClient())
                {

                    Debug.Log("Accepted client");
// Get a stream object for reading
                    using (NetworkStream stream = connectedTcpClient.GetStream())
                        {
                            Debug.Log("incomming request ?");
                            int length;
                          //  Read incomming stream into byte arrary. 						
                                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                Debug.Log("reading request");
                                var incommingData = new byte[length];
                                Array.Copy(bytes, 0, incommingData, 0, length);
                               // Convert byte array to string message. 							
                                        string clientMessage = Encoding.ASCII.GetString(incommingData);
                                Debug.Log("Received message: " + clientMessage);
                                gameManager.keyManager.parseMessage(clientMessage);
                            }
                        }
                }
            }

            RestartExchange();
            successStatus = "Connected!";
        }
        catch (Exception e)
        {
            errorStatus = e.ToString();
            Debug.LogError("Fail serveur creation : " + e.ToString());
        }
#endif
    }
    void CreateServeur()
    {
        Debug.Log("New server");
       // Start TcpServer background thread
            tcpListenerThread = new Thread(new ThreadStart(ConnectUnity));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
    }
    private bool exchanging = false;
    private bool exchangeStopRequested = false;
    private string lastPacket = null;

    private string errorStatus = null;
    private string warningStatus = null;
    private string successStatus = null;
    private string unknownStatus = null;

    public void RestartExchange()
    {
#if UNITY_EDITOR
        if (exchangeThread != null) StopExchange();
        exchangeStopRequested = false;
        exchangeThread = new System.Threading.Thread(ExchangePackets);
        exchangeThread.Start();
#else
        if (exchangeTask != null) StopExchange();
        exchangeStopRequested = false;
        exchangeTask = Task.Run(() => ExchangePackets());
#endif
    }

    public void Update()
    {
        if (lastPacket != null)
        {
            ReportDataToTrackingManager(lastPacket);
        }

    }

    public void ExchangePackets()
    {
        while (!exchangeStopRequested)
        {
            if (writer == null || reader == null) continue;
            exchanging = true;

            string received = null;

#if UNITY_EDITOR
            /*byte[] bytes = new byte[client.SendBufferSize];
            int recv = 0;
            while (true)
            {
                recv = stream.Read(bytes, 0, client.SendBufferSize);
                received += Encoding.UTF8.GetString(bytes, 0, recv);
                if (received.EndsWith("\n")) break;
            }*/
#else
            received = reader.ReadLine();
#endif

            lastPacket = received;
            Debug.Log("Read data: " + received);

            exchanging = false;
        }
    }

    private void ReportDataToTrackingManager(string data)
    {
        if (data == null)
        {
            Debug.Log("Received a frame but data was null");
            return;
        }

        gameManager.keyManager.parseMessage(data);
    }


    public void StopExchange()
    {
        exchangeStopRequested = true;

#if UNITY_EDITOR
        if (exchangeThread != null)
        {
            exchangeThread.Abort();
            stream.Close();
         //   client.Close();
            writer.Close();
            reader.Close();

            stream = null;
            exchangeThread = null;
        }
#else
        if (exchangeTask != null) {
            exchangeTask.Wait();
            socket.Dispose();
            writer.Dispose();
            reader.Dispose();

            socket = null;
            exchangeTask = null;
        }
#endif
        writer = null;
        reader = null;
    }

    public void OnDestroy()
    {
        StopExchange();
    }

}