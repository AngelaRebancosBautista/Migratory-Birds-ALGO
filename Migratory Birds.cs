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

class Result
{

    /*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int bird in arr)
        {
            if (!freq.ContainsKey(bird))
                freq[bird] = 0;

            freq[bird]++;
        }

        int maxCount = 0;
        int birdType = int.MaxValue;

        foreach (var kvp in freq)
        {
            int type = kvp.Key;
            int count = kvp.Value;

            if (count > maxCount || (count == maxCount && type < birdType))
            {
                maxCount = count;
                birdType = type;
            }
        }
        return birdType;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
