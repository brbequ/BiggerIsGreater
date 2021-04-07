using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the biggerIsGreater function below.
    static string biggerIsGreater(string w)
    {
        List<char> r = new List<char>(w);

        // Walk the string right-to-left
        for (int idx = r.Count - 1; idx >= 0; idx--)
        {
            // Walk each character to the right from right-to-left
            for (int idx2 = r.Count - 1; idx2 > idx; idx2--)
            {
                // Swap
                if (r[idx] < r[idx2])
                {
                    char tmp = r[idx];
                    r[idx] = r[idx2];
                    r[idx2] = tmp;

                    // sort everything to the right of idx
                    r.Sort(idx + 1, r.Count - (idx + 1), null);

                    return String.Concat(r);
                }
            }

        }

        return "no answer";
    }

    static void Main(string[] args)
    {
        const string InFile = @"..\..\..\input01.txt";
        const string OutFile = @"..\..\..\output01.txt";

        using (StreamReader input = new StreamReader(InFile))
        {
            using (StreamReader output = new StreamReader(OutFile))
            {
                string linein = input.ReadLine(); // Read the line count, but ignore it
                string lineout;

                while ((linein = input.ReadLine()) != null &&
                       (lineout = output.ReadLine()) != null)
                {
                    string result = biggerIsGreater(linein);
                    if (result != lineout)
                    {
                        Console.WriteLine(linein);
                        Console.WriteLine(result + " - Oops!");
                        Console.WriteLine(lineout);
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
            }
        }

        List<string> testcases = new List<string>()
        {
            "lmno",
            "dcba",
            "dcbb",
            "abdc",
            "abcd",
            "fedcbabcd",
            "dkhc"

        };

        foreach (string w in testcases)
        {
            string result = biggerIsGreater(w);

            Console.WriteLine(result);
        }
    }
}
