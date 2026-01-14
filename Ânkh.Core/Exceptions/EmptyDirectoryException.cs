namespace Ânkh.Core.Exceptions;

/// <summary>
/// Exception generate when folder is empty
/// </summary>
public class EmptyDirectoryException : IOException
{
    public EmptyDirectoryException(string? folder) :
        base($"The folder '{folder}' contains no files")
    { }

    public EmptyDirectoryException(string? message, IOException? innerException) : base(message, innerException)
    {
    }
}