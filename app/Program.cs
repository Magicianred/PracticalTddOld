using System;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputFramesStr = args[1].Split(',');
            int[][] frames = inputFramesStr
                .Select(frameInputStr => frameInputStr.Split('-'))
                .Select(frameAsStr => Array.ConvertAll(frameAsStr, rollStr => Convert.ToInt32(rollStr)))
                .Select(frame => frame[0] == 10 ? new []{30} : frame )
                .ToArray();

            int[] framesPartialScore = frames
                .Select(frame => frame.Sum())
                .ToArray();

            int[] framesScore = new int[framesPartialScore.Length];
            Array.Copy(framesPartialScore, framesScore, framesPartialScore.Length);

            for (int i = 0; i < framesPartialScore.Length; i++)
            {
                if(framesPartialScore[i] == 10)
                {
                    if(i < framesPartialScore.Length - 1)
                    {
                        framesScore[i] += framesPartialScore[i + 1];
                    }
                    else
                    {

                        framesScore[i] = -1;
                    }
                }
            }

            int totalScore = framesScore
                .Where(score => score > 0)
                .Sum();

            Console.WriteLine(args[1]);
            Console.WriteLine(framesScore
                .Aggregate("", (acc, rollScore) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{(rollScore < 0 ? "-" : rollScore.ToString())}"));
            Console.WriteLine(totalScore > 0 ? totalScore.ToString() : "-");
        }
    }
}
