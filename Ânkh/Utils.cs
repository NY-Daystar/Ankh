using ConsoleTables;
using System.Text.RegularExpressions;

namespace Ânkh
{
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
        public static void ShowFiles(List<AnkhFile> files)
        {
            string[] headers = new string[] { "N°", "Name", };

            ConsoleTable table = new(headers);
            foreach (AnkhFile file in files)
            {
                _ = table.AddRow(files.IndexOf(file), file.Name);
            }

            table.Write(Format.Minimal);
        }

        /// <summary>
        /// Display table to compare old file names with the new ones
        /// </summary>
        /// <param name="files">Files data to compare</param>
        public static void CompareFiles(List<AnkhFile> files)
        {
            string[] headers = new string[] { "N°", "Old Name", "New Name", };

            ConsoleTable table = new(headers);
            foreach (AnkhFile file in files)
            {
                _ = table.AddRow(files.IndexOf(file), file.Name, file.NewName);
            }

            table.Write(Format.MarkDown);
        }

        /// <summary>
        /// Show in a table the list of pattern available to rename files
        /// </summary>
        /// <param name="matches">list of pattern matches</param>
        public static void ShowRegexPattern(MatchCollection matches)
        {

            string[] headers = new string[] { "N°", "Pattern", };

            ConsoleTable table = new(headers);

            for (int idx = 0; idx < matches.Count(); idx++)
            {
                int id = idx + 1;
                Match match = matches[idx];
                _ = table.AddRow(id, match.Value);
            }
            table.Write(Format.Alternative);
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
                else if (o is ConsoleColor)
                {
                    Console.ForegroundColor = (ConsoleColor)o;
                }
                else
                {
                    Console.Write(o.ToString());
                }
            }

            Console.WriteLine();
        }
    }
}