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
                .ToArray();

            KeyValuePair<int, int>[] framesPartialScore = frames
                .Select(frame => KeyValuePair.Create((frame.Length % 2) + 1, frame.Sum()))
                .ToArray();

            int[] framesScore = new int[framesPartialScore.Length];
            Array.Copy(framesPartialScore.Select(partialScore => partialScore.Value).ToArray(), framesScore, framesPartialScore.Length);

            for (int i = 0; i < framesPartialScore.Length; i++)
            {

                int score = framesPartialScore[i].Value;
                int framesToAdd = framesPartialScore[i].Key;
                if (score == 10)
                {
                    if (i < framesPartialScore.Length - framesToAdd)
                    {
                        for (int j = 0; j < framesToAdd; j++)
                        {
                            framesScore[i] += framesPartialScore[i + j + 1].Value;
                        }
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
