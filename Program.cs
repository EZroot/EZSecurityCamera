using System;
using OpenCvSharp;

namespace EZSecurityCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            Log.Write("(1) Server", ConsoleColor.Green);
            Log.Write("(2) Client", ConsoleColor.Red);
            command = Console.ReadLine();
            if(command.Contains("1"))
            {
                CameraServer.Start();
            } 
            else
            {   
                CameraClient.Start();
            }
            
            /*VideoCapture capture = new VideoCapture(0);
            while(true)
            {
                Mat testFrame = new Mat();
                capture.Read(testFrame);
                Log.Warn("x:"+testFrame.Width + ", y: "+ testFrame.Height);
                Mat src0 = testFrame.Resize(new Size(320,280), 0, 0, InterpolationFlags.Lanczos4);
                Log.Warn("x:"+src0.Width + ", y: "+ src0.Height);

                byte[] buffer = new byte[src0.Total() * src0.Channels()];
                Log.Warn("byte size: "+buffer.Length.ToString());
                Cv2.ImEncode(".jpg",src0,out buffer);

                Mat frame = Cv2.ImDecode(buffer, ImreadModes.AnyColor);


                Cv2.ImShow("Webcam", frame);
                var key = Cv2.WaitKey(10);
                if(key==27)
                    break;
            }*/
        }

    }
}
