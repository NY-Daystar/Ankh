namespace Ânkh.Exceptions;

/// <summary>
/// Exception generate when no regex match
/// </summary>
public class MatchRegexException : Exception
{
    public MatchRegexException(AnkhFile file) :
        base($"No regex match for this file : {file}")
    { }

    public MatchRegexException(string? message) : base(message)
    {
    }

    public MatchRegexException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}