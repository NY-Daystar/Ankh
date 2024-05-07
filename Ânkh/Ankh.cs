namespace Ânkh;

/// <summary>
/// Mainframe of the program
/// </summary>
internal static class Ankh
{
    private const string _application = "Ânkh";

    private const string _version = "1.1.0";

    public static void Main()
    {
        Utils.WriteLine("Welcome to ", ConsoleColor.Yellow, _application, ConsoleColor.White,
            " - Version : ", ConsoleColor.Yellow, _version, ConsoleColor.White);
        Console.WriteLine("This program allows you to rename files in folder quickly\n");
        Console.WriteLine("---------------------");

        // 1 - Choose directory to modify files
        string directory = AnkhUser.AskDirectory();

        if (string.IsNullOrEmpty(directory))
        {
            Console.WriteLine("Directory has null value");
            Environment.Exit(0);
        }
        Console.WriteLine("---------------------");

        // 2 - Get all files on the directory
        IEnumerable<AnkhFile> files = AnkhIO.GetFiles(directory);

        if (!files.Any())
        {
            Console.WriteLine($"No files in this directory : {directory}");
            Exit();
        }
        Utils.WriteLine("Files from folder :", ConsoleColor.Yellow, directory, ConsoleColor.White);
        Utils.ShowFiles(files);
        Console.WriteLine("---------------------");

        // 3 - Get via regex file number from first file
        AnkhDetector detector = new();
        detector.SetupRegex(files.ElementAt(0));
        Console.WriteLine("---------------------");

        // 4 - Ask the new file template to rename all files
        string template = AnkhUser.AskFileTemplate(detector.Prefix);
        if (string.IsNullOrEmpty(template))
        {
            Console.WriteLine("No template file set");
            Exit();
        }
        Console.WriteLine("---------------------");

        // 5 - Create new files names
        detector.ApplyRegex(files, template);
        Utils.CompareFiles(files);
        Console.WriteLine("---------------------");

        // 6 - Ask to the user if it's ok to change
        bool validation = AnkhUser.AskConfirmation();

        if (!validation)
        {
            Console.WriteLine("Refuse to rename.\nAbort process...");
            Exit();
        }
        Console.WriteLine("---------------------");

        // 7 - Renaming all files
        Console.WriteLine("Renaming files...");
        AnkhIO.RenameFiles(files);

        Console.WriteLine($"All files are renamed in {directory}");
        Console.WriteLine("Exiting application in 15 seconds");
        Exit(15000);
    }

    /// <summary>
    /// Quit program
    /// </summary>
    /// <param name="timeout">time(s) to quit program</param>
    private static void Exit(int timeout = 2000)
    {
        Thread.Sleep(timeout);
        Environment.Exit(0);
    }
}