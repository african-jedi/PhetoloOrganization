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

    public static string Scramble(this string str)
    {
        char[] arrayChar = str.ToCharArray();
        char[] scramble = str.ToCharArray();

        var sb = new StringBuilder(str.Length);
        Random random = new Random();

        for (int i = 0; i < 9; i++)
            if (random.Next(0, 2) != 0)
            {
                scramble[i] = arrayChar[8 - i];
                scramble[8 - i] = arrayChar[i];
            }

        foreach (var ch in scramble)
            sb.Append(ch + ":");

        return sb.ToString();
    }
}
