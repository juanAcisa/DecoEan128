using System;
using System.Text.RegularExpressions;

public class CodeFile1
{
    public static void Main()
    {
        string input = "This is one sentence. This is another.";
        string pattern = @"\b(\w+[;,]?\s?)+[.?!]";
        //string input = "Esta es la primera sentencia. Esta es la otra sentencia. Y esto no tiene nada que ver con las sentencias anteriores.";
        //string pattern = @"([eE]st[aeiou])\ .*\.";

        Console.WriteLine("Input is: {0}", input);

        foreach (Match match in Regex.Matches(input, pattern))
        {
            Console.WriteLine("Match: '{0}' at index {1}.",
                              match.Value, match.Index);
            int grpCtr = 0;
            foreach (Group grp in match.Groups)
            {
                Console.WriteLine("   Group {0}: '{1}' at index {2}.",
                                  grpCtr, grp.Value, grp.Index);
                int capCtr = 0;
                foreach (Capture cap in grp.Captures)
                {
                    Console.WriteLine("      Capture {0}: '{1}' at {2}.",
                                      capCtr, cap.Value, cap.Index);
                    capCtr++;
                }
                grpCtr++;
            }
            Console.WriteLine();

        }
        Console.ReadKey();
    }
}
