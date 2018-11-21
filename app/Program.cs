using System;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputRollsStr = args[1].Split(',');
            int[] inputScorebyRolls = inputRollsStr
                .Select(rollPairStr => rollPairStr.Split('-'))
                .Select(rollPair => Array.ConvertAll(rollPair, rollStr => Convert.ToInt32(rollStr)))
                .Select(roll => roll[0] == 10 ? new []{30} : roll )
                .Select(roll => roll.Sum())
                .ToArray();


            int totalScore = inputScorebyRolls.Sum();
            Console.WriteLine(args[1]);
            Console.WriteLine(inputScorebyRolls
                .Aggregate("", (acc, rollScore) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{rollScore}"));
            Console.WriteLine(totalScore);
        }
    }
}
