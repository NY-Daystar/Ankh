namespace Ânkh.Exceptions;

/// <summary>
/// Exception generate when folder is empty
/// </summary>
public class EmptyDirectoryException : Exception
{
    public EmptyDirectoryException(string? folder) :
        base($"The folder '{folder}' contains no files")
    { }

    public EmptyDirectoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}