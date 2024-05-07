using Ânkh.Exceptions;
using System.Text.RegularExpressions;

namespace Ânkh
{
    /// <summary>
    /// IO methods to get files data and to rename it
    /// </summary>
    internal static class AnkhIO
    {
        /// <summary>
        /// Get files list of a folder and convert it into AnkhFile
        /// </summary>
        /// <param name="folder">folder to get files</param>
        /// <returns>List of AnkhFile</returns>
        /// <exception cref="EmptyDirectoryException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static IEnumerable<AnkhFile> GetFiles(string folder)
        {
            if (folder == null)
            {
                throw new EmptyDirectoryException(folder);
            }

            if (!Directory.Exists(folder))
            {
                throw new DirectoryNotFoundException();
            }

            IEnumerable<string> files = Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly);

            // Order in natural number
            files = files.OrderBy(file => Regex.Replace(file, @"\d+", match => match.Value.PadLeft(4, '0')));

            return AnkhFile.Load(files);
        }

        /// <summary>
        /// Rename all files with new names
        /// </summary>
        /// <param name="files">AnkhFile list to rename</param>
        public static void RenameFiles(IEnumerable<AnkhFile> files)
        {
            foreach (AnkhFile file in files)
            {
                File.Move(file.FilePath, file.NewFilePath);
            }
        }
    }
}