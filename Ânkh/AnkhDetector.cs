using Ânkh.Exceptions;
using System.Text.RegularExpressions;

namespace Ânkh
{
    /// <summary>
    /// Handler for regex file
    /// </summary>
    public class AnkhDetector
    {
        /// <summary>
        /// Regex to get number of file
        /// </summary>
        private readonly Regex _regex;

        /// <summary>
        /// match number to change file
        /// Default : 0
        /// </summary>
        private int _match;

        public AnkhDetector()
        {
            const string pattern = "[0-9]{1,}";
            _regex = new Regex(pattern);
        }

        /// <summary>
        /// Setup regex from first file and get all matches
        /// </summary>
        /// <param name="file">File to check match</param>
        /// <returns>List of match for number</returns>
        /// <exception cref="MatchRegexException"></exception>
        public void SetupRegex(AnkhFile file)
        {
            MatchCollection matches = _regex.Matches(file.Name);

            if (!matches.ElementAt(0).Success)
            {
                throw new MatchRegexException(file);
            }

            Utils.WriteLine($"List of matches from file: ", ConsoleColor.Yellow, $"'{file.Name}'", ConsoleColor.White);

            _match = validateMatch(matches);

            Utils.WriteLine("You select this match : ", ConsoleColor.Yellow, $"'{matches.ElementAt(_match)}'", ConsoleColor.White);
        }

        /// <summary>
        /// Change files names with the template
        /// </summary>
        /// <param name="files">Files to rename</param>
        /// <param name="template">Template to use to rename</param>
        public void ApplyRegex(List<AnkhFile> files, string template)
        {
            foreach (AnkhFile file in files)
            {
                try
                {
                    string number = int.Parse(_regex.Matches(file.Name).ElementAt(_match).Value).ToString();
                    file.NewName = $"{template} {number}";
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Can't get number for this file: '{file.Name}'\n.Skip");
                }
            }
        }

        /// <summary>
        /// Show matches for the user and handle selection of one
        /// </summary>
        /// <param name="matches">List of matches</param>
        /// <returns>int of the match</returns>
        private int validateMatch(MatchCollection matches)
        {
            Utils.ShowRegexPattern(matches);

            return AnkhUser.askMatch(matches.Count()) - 1;
        }
    }
}