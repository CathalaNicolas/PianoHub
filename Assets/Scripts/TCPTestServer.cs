using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCPTestServer : MonoBehaviour
{
    #region private members 	
    /// <summary> 	
    /// TCPListener to listen for incomming TCP connection 	
    /// requests. 	
    /// </summary> 	
    private TcpListener tcpListener;
    /// <summary> 
    /// Background thread for TcpServer workload. 	
    /// </summary> 	
    private Thread tcpListenerThread;
    /// <summary> 	
    /// Create handle to connected tcp client. 	
    /// </summary> 	
    private TcpClient connectedTcpClient;
    #endregion

    public GameManager gameManager = null;

    private void OnApplicationQuit()
    {
        if (tcpListenerThread.IsAlive)
            tcpListenerThread.Abort();
    }
    // Use this for initialization
    void Start()
    {
        CreateServeur();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (!gameManager)
            Debug.LogError("TCPServer : gameManager is null!");
    }

    void CreateServeur()
    {
        Debug.Log("New server");
        // Start TcpServer background thread 		
        tcpListenerThread = new Thread(new ThreadStart(ListenForIncommingRequests));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
    }

    void ReCreateServeur()
    {
        Debug.Log("Re creating server");
        /* if (tcpListenerThread.IsAlive == true)
             tcpListenerThread.Join();*/
        CreateServeur();
    }
    /// <summary> 	
    /// Runs in background TcpServerThread; Handles incomming TcpClient requests 	
    /// </summary> 	
    private void ListenForIncommingRequests()
    {
        try
        {
            // Create listener on localhost port 8052. 			
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 4243);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[1024];
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
                        // Read incomming stream into byte arrary. 						
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
        }
        catch
        {
            Debug.Log("Execption !");
            tcpListener.Stop();
            ReCreateServeur();
        }
    }
}