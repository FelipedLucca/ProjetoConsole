using System;
using System.Text.RegularExpressions;

using System;

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
            WriteLineColored("Entrada inválida. Digite novamente:", ConsoleColor.Red);
        }
        return result;
    }

    public static DateTime ReadDateTime(string message)
    {
        DateTime result;
        while (!DateTime.TryParseExact(Console.ReadLine(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out result))
        {
            WriteLineColored("Data inválida. Digite novamente (ddMMyyyy):", ConsoleColor.Red);
        }
        return result;
    }

    public static string ReadString(string message)
    {
        string result;
        while (string.IsNullOrWhiteSpace(result = Console.ReadLine()))
        {
            WriteLineColored("Entrada inválida. Digite novamente:", ConsoleColor.Red);
        }
        return result;
    }
}