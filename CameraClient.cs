using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using OpenCvSharp;

namespace EZSecurityCamera
{
    public class CameraClient
    {
        public static string IP = "127.0.0.1";
        public static int Port = 1337;

        public static void Start()
        {
            Log.Warn("Trying to connect to " + IP);
            try
            {
                TcpClient client = new TcpClient(IP, Port);
                Log.Success("Connected!");
                
                VideoCapture capture = new VideoCapture(0);

                while (true)
                {
                    Mat testFrame = new Mat();
                    capture.Read(testFrame);
                    Mat src0 = testFrame.Resize(new Size(320,280), 0, 0, InterpolationFlags.Lanczos4);

                    byte[] data = new byte[src0.Total() * src0.Channels()];
                    Cv2.ImEncode(".jpg",src0,out data);

                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                    catch (IOException e)
                    {
                        Log.Error(e.Message);
                    }
                }
            }
            catch (SocketException e)
            {
                Log.Error(e.Message);
            }

            Log.Write("Client exiting...");
            Console.ReadKey();
        }
    }
}