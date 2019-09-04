using System;
using System.Text.RegularExpressions;

namespace EAN128
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\d{3})-(\d{3}-\d{4})";
            string input = "212-555-6666 906-932-1111 415-222-3333 425-888-9999";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine("Grupo 1: \t\t{0}", match.Groups[1].Value);
                Console.WriteLine("Grupp 2: \t\t{0}", match.Groups[2].Value);
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}

    //Output:
    //
    //Area Code:        212
    //Telephone number: 555-6666
    //
    //Area Code:        906
    //Telephone number: 932-1111
    //
    //Area Code:        415
    //Telephone number: 222-3333
    //
    //Area Code:        425
    //Telephone number: 888-9999

