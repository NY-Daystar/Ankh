namespace Ânkh
{
    /// <summary>
    /// File to rename with its data (name, parent folder, extension, etc...)
    /// </summary>
    public class AnkhFile
    {
        /// <summary>
        /// Initial Data of the filepath with extension
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Data of the file to work with
        /// </summary>
        private DirectoryInfo _directoryInfo => new(_filePath);

        /// <summary>
        /// Parent folder of the file if it has one
        /// </summary>
        private string _folder
        {
            get
            {
                if (_directoryInfo.Parent == null)
                {
                    return "";
                }
                else if (string.IsNullOrEmpty(_directoryInfo.Parent.FullName))
                {
                    return "";
                }

                return _directoryInfo.Parent.FullName;
            }
        }

        /// <summary>
        /// Extension of the file
        /// </summary>
        private string _extension => _directoryInfo.Extension;

        /// <summary>
        /// File name
        /// </summary>
        public string Name => Path.GetFileNameWithoutExtension(_directoryInfo.Name);

        /// <summary>
        /// Actual file path
        /// </summary>
        public string FilePath => _directoryInfo.FullName;

        /// <summary>
        /// Name and extension of file (only relative path)
        /// </summary>
        public string FullName => $"{Name}.{Extension}";

        /// <summary>
        /// extension of file without dot
        /// </summary>
        public string Extension => _extension.Replace(".", "");

        /// <summary>
        /// New file name after applying regex
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// New file path after applying when renaming file
        /// </summary>
        public string NewFilePath => Path.Combine(_folder, NewName) + _extension;

        /// <summary>
        /// Name and extension of file after renamed (only relative path)
        /// </summary>
        public string NewFullName => $"{NewName}.{Extension}";

        /// <summary>
        /// Constructor to get all data of the file to rename
        /// </summary>
        /// <param name="filePath">path to the initial file</param>
        public AnkhFile(string filePath)
        {
            _filePath = filePath;
            NewName = string.Empty;
        }

        /// <summary>
        /// Shortcut method to convert list of filePath of list of AnkhFile
        /// </summary>
        /// <param name="filePaths">list of filePath</param>
        /// <returns></returns>
        public static IEnumerable<AnkhFile> Load(IEnumerable<string> filePaths)
        {
            List<AnkhFile> ankhFiles = new();

            foreach (string filePath in filePaths)
            {
                ankhFiles.Add(new AnkhFile(filePath));
            }
            return ankhFiles;
        }
    }
}