using Ânkh.Core;
using Ânkh.Core.Exceptions;
using System.Threading;

namespace Ânkh;

/// <summary>
/// Mainframe of the program
/// </summary>
internal static class Ankh
{
    private const string _application = "Ânkh";

    private const string _version = "1.2.0";

    public static void Main()
    {
        // Proposer une option pour générer des noms de fichiers aléatoirement
        Core.Utils.WriteLine("Welcome to ", ConsoleColor.Yellow, _application, ConsoleColor.White,
            " - Version : ", ConsoleColor.Yellow, _version, ConsoleColor.White);
        Console.WriteLine("This program allows you to rename files in folder quickly\n");
        Console.WriteLine("---------------------");

        // 1 - Choose directory to modify files
        string directory = AnkhUser.AskDirectory();

        if (string.IsNullOrEmpty(directory))
        {
            Console.WriteLine("Directory has null value");
            return;
        }
        Console.WriteLine("---------------------");

        // 2 - Get all files on the directory
        IEnumerable<AnkhFile> files = AnkhIO.GetFiles(directory);

        if (!files.Any())
        {
            Console.WriteLine($"No files in this directory : {directory}");
            Thread.Sleep(15000);
            return;
        }
        Utils.WriteLine("Files from folder :", ConsoleColor.Yellow, directory, ConsoleColor.White);
        Utils.ShowFiles(files);
        Console.WriteLine("---------------------");

        // 3 - What user wants to do directory to modify files
        var action = AnkhUser.AskAction();

        // 4 - Execute the action chosen at step 1
        AnkhDetector detector = new();
        if (action.Equals(AnkhAction.ORDONATE))
        {

            // 4.1.1 - Get via regex file number from first file
            detector.SetupRegex(files.ElementAt(0));
            Console.WriteLine("---------------------");

            // 4.1.2 - Ask the new file template to rename all files
            string template = AnkhUser.AskFileTemplate(detector.Prefix);
            if (string.IsNullOrEmpty(template))
            {
                Console.WriteLine("No template file set");
                Thread.Sleep(15000);
                return;
            }
            Console.WriteLine("---------------------");

            // 4.1.3 - Create new files names
            detector.ApplyRegex(files, template);
            Utils.CompareFiles(files);

        }
        else
        {
            // 4.2.1 -- Apply randomize file
            detector.ApplyRandomizer(files);
        }

        Console.WriteLine("---------------------");
        Utils.CompareFiles(files);

        // 6 - Ask to the user if it's ok to change
        bool validation = AnkhUser.AskConfirmation();

        if (!validation)
        {
            Console.WriteLine("Refuse to rename.\nAbort process...");
            Thread.Sleep(15000);
            return;
        }
        Console.WriteLine("---------------------");

        // 7 - Renaming all files
        Console.WriteLine("Renaming files...");
        AnkhIO.RenameFiles(files);

        Console.WriteLine($"All files are renamed in {directory}");
        Console.WriteLine("Exiting application in 5 seconds");
        Thread.Sleep(5000);
        return;
    }
}