using System;
using System.Text.RegularExpressions;
using System;
using System.Data;


public static class Utils
{
    public static void WriteLineColored(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static int ReadInt(string message)
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("----------------------------------------------");
            WriteLineColored("Entrada inválida. Digite novamente:", ConsoleColor.Red);
            Console.WriteLine("----------------------------------------------");
        }
        return result;
    }

    public static DateTime ReadDateTime(string message)
    {
        DateTime result;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out result))
        {
            Console.WriteLine("----------------------------------------------");
            WriteLineColored("Data inválida. Digite novamente (dd/MM/yyyy):", ConsoleColor.Red);
            Console.WriteLine("----------------------------------------------");
        }
        return result;
    }

    public static string ReadString(string message)

    {
        string result;
        while (string.IsNullOrWhiteSpace(result = Console.ReadLine()))
        {
            Console.WriteLine("----------------------------------------------");
            WriteLineColored("Entrada inválida. Digite novamente:", ConsoleColor.Red);
            Console.WriteLine("----------------------------------------------");
        }
        return result;
    }

}