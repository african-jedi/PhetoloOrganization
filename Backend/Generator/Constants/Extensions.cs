using System;
using System.Text;
using System.Text.RegularExpressions;

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
        string[] arrayWithOutOperators = Regex.Split(str, @"[+\-*/]");
        string[] operators = ["+", "-", "*", "/"];

        string[] completeArray = arrayWithOutOperators.Concat(operators).ToArray();
        string[] scramble = arrayWithOutOperators.Concat(operators).ToArray();

        var sb = new StringBuilder(str.Length);
        Random random = new Random();

        for (int i = 0; i < completeArray.Length - 1; i++)
            if (random.Next(0, 2) != 0)
            {
                scramble[i] = completeArray[completeArray.Length - i - 1];
                scramble[completeArray.Length - i - 1] = completeArray[i];
            }

        for (int i=0;i < scramble.Length; i++){
            sb.Append($"{scramble[i]}" + (i<scramble.Length-1 ? ":" : ""));
        }

        return sb.ToString();
    }
}
