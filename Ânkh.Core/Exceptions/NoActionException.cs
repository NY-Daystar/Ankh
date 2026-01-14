namespace Ânkh.Core.Exceptions;

/// <summary>
/// Exception generate when folder is empty
/// </summary>
public class NoActionException : IOException
{
    public NoActionException() :
        base("No action chosen")
    { }

    public NoActionException(string? message, IOException? innerException) : base(message, innerException)
    {
    }
}