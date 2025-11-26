using System;
using System.Text;

namespace Phetolo.Math28.PuzzleGenerator.Constants;

public static class Extensions
{
    //write extension methods for string
    public static string ReplaceOperatorsWithColon(this string str)
    {
        char[] operators = ['+', '-', '*', '/'];
        
        var sb = new StringBuilder(str.Length);
        foreach (var ch in str)
            sb.Append(operators.Contains(ch) ? ':' : ch);

        return sb.ToString();
    }
}
