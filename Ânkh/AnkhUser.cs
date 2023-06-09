﻿namespace Ânkh
{
    internal static class AnkhUser
    {
        /// <summary>
        /// Ask in Console folder path
        /// </summary>
        /// <returns>string of folder</returns>
        public static string AskDirectory()
        {
            Console.Write("Enter the folder path to rename files : ");
            string folder = Console.ReadLine() ?? string.Empty;
            return Utils.EscapeQuotes(folder);
        }

        /// <summary>
        /// Ask in Console the new file template
        /// </summary>
        /// <returns>template of file</returns>
        public static string AskFileTemplate()
        {
            Console.Write("Enter the file template to set : ");
            string fileTemplate = Console.ReadLine() ?? string.Empty;
            return Utils.EscapeQuotes(fileTemplate);
        }

        /// <summary>
        /// Select the good match proposed
        /// </summary>
        /// <returns>The number of the good match to setup new files names</returns>
        public static int askMatch(int range)
        {
            do
            {
                Console.Write($"Select the appropriate match between (1/{range}) : ");
                string userLine = Console.ReadLine() ?? string.Empty;
                int match = int.Parse(userLine);

                if (match > 0 && match <= range)
                {
                    return match;
                }
                else
                {
                    Console.Write($"\nYou type '{match}'. Please ");
                }
            } while (true);
        }


        /// <summary>
        /// Ask in Console user confirmation (y or n)
        /// </summary>
        /// <returns>confirmation yes or no</returns>
        public static bool AskConfirmation()
        {
            Console.Write("Do you want to proceed (y/N) : ");
            do
            {
                char key = Console.ReadKey().KeyChar;

                if (key is 'y' or 'Y')
                {
                    Console.WriteLine();
                    return true;
                }
                else if (key is 'n' or 'N')
                {
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    Console.WriteLine($"\nYou type '{key}'. Please choose 'y' (Yes) or 'n' (No)");
                }
            } while (true);
        }
    }
}