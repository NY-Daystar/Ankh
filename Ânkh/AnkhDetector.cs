using Ânkh.Exceptions;
using System.Text.RegularExpressions;

namespace Ânkh
{
    /// <summary>
    /// Handler for regex file
    /// </summary>
    public partial class AnkhDetector
    {
        /// <summary>
        /// match number to change file
        /// Default : 0
        /// </summary>
        private int _match;

        /// <summary>
        /// String to get prefix template based on file before the number match
        /// </summary>
        private string? _prefix;

        public string Prefix => _prefix ?? string.Empty;

        /// <summary>
        /// Regex to detect all numeric values in filename
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("[0-9]{1,}")]
        private static partial Regex NumericRegex();

        /// <summary>
        /// Setup regex from first file and get all matches
        /// </summary>
        /// <param name="file">File to check match</param>
        /// <returns>List of match for number</returns>
        /// <exception cref="MatchRegexException"></exception>
        public void SetupRegex(AnkhFile file)
        {
            MatchCollection matches = NumericRegex().Matches(file.Name);
            if (!matches[0].Success)
            {
                throw new MatchRegexException(file);
            }

            Utils.WriteLine("List of matches from file: ", ConsoleColor.Yellow, $"'{file.Name}'", ConsoleColor.White);

            _match = validateMatch(matches);
            setPrefixTemplate(file);

            Utils.WriteLine("You select this match : ", ConsoleColor.Yellow, $"'{matches[_match]}'", ConsoleColor.White);
        }

        /// <summary>
        /// Change files names with the template
        /// </summary>
        /// <param name="files">Files to rename</param>
        /// <param name="template">Template to use to rename</param>
        public void ApplyRegex(IEnumerable<AnkhFile> files, string template)
        {
            foreach (AnkhFile file in files)
            {
                string number = NumericRegex().Matches(file.Name).ElementAt(_match).Value;
                file.NewName = template + number;
            }
        }

        /// <summary>
        /// Show matches for the user and handle selection of one
        /// </summary>
        /// <param name="matches">List of matches</param>
        /// <returns>int of the match</returns>
        private static int validateMatch(MatchCollection matches)
        {
            while (true)
            {
                Utils.ShowRegexPattern(matches);
                int choice = 0;
                try
                {
                    choice = AnkhUser.askMatch(matches.Count) - 1;
                }
                catch (FormatException)
                {
                    Utils.WriteLine(ConsoleColor.Red, $"Incorrect choice ({choice}), please choose between 1-{matches.Count}", ConsoleColor.White);
                    continue;
                }
                return choice;
            }
        }

        /// <summary>
        /// Get prefix template to get default choice based on first file on the list
        /// and the match found in method 'SetupRegex'
        /// </summary>
        /// <param name="file">File to extract prefix template</param>
        /// <returns>template of file</returns>
        private void setPrefixTemplate(AnkhFile file)
        {
            string stopAt = NumericRegex().Matches(file.Name).ElementAt(_match).Value;
            int charLocation = file.Name.IndexOf(stopAt, StringComparison.Ordinal);
            _prefix = file.Name.Substring(0, charLocation).Replace(".", " ");
        }
    }
}