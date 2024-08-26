using System;
using System.Linq;
using System.Collections.Generic;

public class StringCalculator
{
    private const int UpperLimit = 1000;

    public int Add(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0;

        var delimiters = ExtractDelimiters(ref input);
        var numbers = ParseNumbers(input, delimiters);

        CheckForNegatives(numbers);

        return numbers.Where(n => n <= UpperLimit).Sum();
    }

    private List<string> ExtractDelimiters(ref string input)
    {
        var delimiters = new List<string> { ",", "\n" };

        if (input.StartsWith("//"))
        {
            var delimiterEnd = input.IndexOf('\n');
            var customDelimiter = input.Substring(2, delimiterEnd - 2);
            delimiters.Add(customDelimiter);
            input = input.Substring(delimiterEnd + 1);
        }

        return delimiters;
    }

    private int[] ParseNumbers(string input, List<string> delimiters)
    {
        return input.Split(delimiters.ToArray(), StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();
    }

    private void CheckForNegatives(int[] numbers)
    {
        var negatives = numbers.Where(n => n < 0).ToArray();
        if (negatives.Any())
            throw new Exception("Negative numbers not allowed: " + string.Join(", ", negatives));
    }
}
