
using System.ComponentModel;

namespace Ânkh.Core;

public enum AnkhAction
{
    /// <summary>
    /// Sort in ordonate number files
    /// </summary>
    [Description("Ordonate files with pattern selected")]
    ORDONATE,
    /// <summary>
    /// Generate GUID for each files
    /// </summary>
    [Description("Generate GUID to randomize file name")]
    RANDOMIZE,   
}