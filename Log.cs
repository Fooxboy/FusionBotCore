using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.FusionBot
{
    public static class Log
    {
        public static void Error(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"({DateTime.Now})[ERROR]: {s}");
            Console.ResetColor();
        }

        public static void Error(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"({DateTime.Now})[ERROR]: Возникло исключение: {e.Message} в {e.Source} " +
                $"\n Стек трейс: {e.StackTrace}");
            Console.ResetColor();
        }

        public static void Wr(string s)
        {
            if(Globals.Log) Console.WriteLine($"({DateTime.Now})[LOG]: {s}");

        }

        public static void Json(string s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Globals.LogJson) Console.WriteLine($"({DateTime.Now})[JSON]: {s}");
            Console.ResetColor();
        }

        public static void War(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"({DateTime.Now})[WARNING]: {s}");
            Console.ResetColor();
        }
    }
}
