using System;

namespace PhiEngine
{
    public static class Debug
    {
        public static void Log(string message) 
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message + '\n');
            Console.ResetColor();
        }

        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message + '\n');
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message + '\n');
            Console.ResetColor();

            Environment.Exit(-1);
        }
    }
}
