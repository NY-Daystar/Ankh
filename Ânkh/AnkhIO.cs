using Ânkh.Exceptions;

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
        public static List<AnkhFile> GetFiles(string folder)
        {
            if (folder == null)
            {
                throw new EmptyDirectoryException(folder);
            }

            if (!Directory.Exists(folder))
            {
                throw new DirectoryNotFoundException();
            }

            List<string> files = Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly).ToList();

            return AnkhFile.Load(files);
        }

        /// <summary>
        /// Rename all files with new names
        /// </summary>
        /// <param name="files">AnkhFile list to rename</param>
        public static void RenameFiles(List<AnkhFile> files)
        {
            foreach (AnkhFile file in files)
            {
                File.Move(file.FilePath, file.NewFilePath);
            }
        }
    }
}