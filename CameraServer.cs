using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using OpenCvSharp;

namespace EZSecurityCamera
{
    public class CameraServer
    {
        public static string IPString = "127.0.0.1";
        public static int Port = 1337;

        public static void Start()
        {
            IPAddress localIP = IPAddress.Parse(IPString);

            TcpListener server = new TcpListener(localIP, Port);
            server.Start();

            Byte[] bytes = new Byte[268800];
            string data = null;

            while(true)
            {
                Log.Write("Waiting for connection...");
                TcpClient client = server.AcceptTcpClient();
                Log.Success("Connected! ");

                Thread t = new Thread(new ThreadStart(()=>ConnectClient(client,bytes,data))); 
                t.Start();
            }
            Log.Write("Finished");
        }

        public static void ConnectClient(TcpClient _client, byte[] _bytes, string _data)
        {
             _data = null;
        
            NetworkStream stream = _client.GetStream();
            int i;
            while((i = stream.Read(_bytes,0,_bytes.Length))!=0)
            {
                Mat frame = Cv2.ImDecode(_bytes,ImreadModes.AnyColor);

                if(!frame.Empty())
                    Cv2.ImShow("Webcam", frame);
                    
                var key = Cv2.WaitKey(10);
                if(key==27)
                   break;
            }

            _client.Close();
        }
    }
}