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
                if(i < framesPartialScore.Length - 1){
                    if(framesPartialScore[i] == 10){
                       framesScore[i] += framesPartialScore[i + 1];
                    }
                }
            }

            int totalScore = framesScore.Sum();
            Console.WriteLine(args[1]);
            Console.WriteLine(framesScore
                .Aggregate("", (acc, rollScore) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{rollScore}"));
            Console.WriteLine(totalScore);
        }
    }
}
