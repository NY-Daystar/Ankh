using ConsoleTables;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Ânkh.Core;

/// <summary>
/// Utilitaries method for Ankh Application
/// </summary>
public static class Utils
{
    /// <summary>
    /// Escaping string of " & '
    /// </summary>
    /// <param name="value">string to escape</param>
    /// <returns>escaped string</returns>
    public static string EscapeQuotes(string value)
    {
        return value.Replace("\"", "").Replace("'", "");
    }

    /// <summary>
    /// Show files in table format
    /// Using ConsoleTables : https://github.com/khalidabuhakmeh/ConsoleTables
    /// </summary>
    /// <param name="files"></param>
    public static void ShowFiles(IEnumerable<AnkhFile> files)
    {
        string[] headers = ["N°", "Name",];

        ConsoleTable table = new(headers);
        foreach (AnkhFile file in files)
        {
            _ = table.AddRow(files.ToList().IndexOf(file), file.FullName);
        }

        table.Write(Format.MarkDown);
    }

    /// <summary>
    /// Display table to compare old file names with the new ones
    /// </summary>
    /// <param name="files">Files data to compare</param>
    public static void CompareFiles(IEnumerable<AnkhFile> files)
    {
        string[] headers = ["N°", "Old Name", "New Name",];

        ConsoleTable table = new(headers);
        foreach (AnkhFile file in files)
        {
            _ = table.AddRow(files.ToList().IndexOf(file), file.FullName, file.NewFullName);
        }

        table.Write(Format.MarkDown);
    }

    /// <summary>
    /// Show in a table the list of pattern available to rename files
    /// </summary>
    /// <param name="matches">list of pattern matches</param>
    public static void ShowRegexPattern(MatchCollection matches)
    {
        string[] headers = ["N°", "Pattern",];

        ConsoleTable table = new(headers);

        for (int idx = 0; idx < matches.Count; idx++)
        {
            int id = idx + 1;
            Match match = matches[idx];
            _ = table.AddRow(id, match.Value);
        }
        table.Write(Format.Alternative);
    }

    public static string StringValueOfEnum(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        if (fi is null)
            return string.Empty;
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Length > 0)
        {
            return attributes[0].Description;
        }
            return value.ToString();
    }

    /// <summary>
    /// Write output with some color
    /// </summary>
    /// <param name="oo">Objects to output</param>
    public static void WriteLine(params object[] oo)
    {
        foreach (object o in oo)
        {
            if (o == null)
            {
                Console.ResetColor();
            }
            else if (o is ConsoleColor consoleColor)
            {
                Console.ForegroundColor = consoleColor;
            }
            else
            {
                Console.Write(o.ToString());
            }
        }

        Console.WriteLine();
    }
}