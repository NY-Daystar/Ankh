namespace Ânkh.Core.Exceptions;

/// <summary>
/// Exception generate when no regex match
/// </summary>
public class MatchRegexException : FormatException
{
    public MatchRegexException(AnkhFile file) :
        base($"No regex match for this file : {file}")
    { }

    public MatchRegexException(string? message) : base(message)
    {
    }

    public MatchRegexException(string? message, FormatException? innerException) : base(message, innerException)
    {
    }
}