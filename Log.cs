using System;

namespace EZSecurityCamera
{
    public class Log
    {
        public static int VerboseLevel = 1;

        public static void Success(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(GetDate() + text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(GetDate() +text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(GetDate() +text);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(GetDate() +text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteSingle(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(GetDate() +text);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void WriteSingle(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(GetDate() +text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warn(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GetDate() +text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string GetDate()
        {
            string result = "";
            if(VerboseLevel==1)
                result = "["+DateTime.Now.ToString("h:mm:ss tt")+"]";

            return result;
        }
    }
}