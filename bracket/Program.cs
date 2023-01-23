internal class Program
{
    static List<string> brackets = new List<string> { "{", "}" };

    static char openBracket = '{';
    static char closeBracket = '}';

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Please enter string: ");
            string inputString = Console.ReadLine() ?? "";
            if (inputString == string.Empty) return;
            Console.WriteLine(IsValidBrackets(inputString));
        }
    }

    /// <summary>
    /// Main function to check for valid brackets
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static bool IsValidBrackets(string input)
    {
        // remove all characters except for open and close brackets
        string cleanedString = CleanString(input);
        // check for total number of open and close brackets
        if (HaveSameCountOfOpenAndCloseBracket(cleanedString))
        {
            return CheckForPair(cleanedString);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// A recursive function to check for "{}" bracket pair
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static bool CheckForPair(string input)
    {
        if (input.Length == 0) return true;

        if (input.Contains("{}"))
        {
            input = input.Replace("{}", "");
            return CheckForPair(input);
        }
        else
        {
            return input.Length == 0;
        }
    }

    /// <summary>
    /// This will remove all characters aside from square bracket
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static string CleanString(string input)
    {
        string retVal = string.Empty;

        foreach (char c in input)
        {
            if (brackets.Contains(c.ToString()))
            {
                retVal += c.ToString();
            }
        }
        return retVal;
    }
    /// <summary>
    /// Check if the total count of open bracket is equal to the total count of close bracket
    /// If the count of open bracket and close bracket are not equal then automatically return false for the main function
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static bool HaveSameCountOfOpenAndCloseBracket(string input)
    {
        return input.Count(x => x == openBracket) == input.Count(x => x == closeBracket);
    }
}