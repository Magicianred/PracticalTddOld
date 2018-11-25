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

            List<int[]> standardFrames = frames.Where(frame => frame.Length < 3).ToList();
            int[] lastFrame = frames.Where(frame => frame.Length == 3).FirstOrDefault() ?? new int[0];

            if(lastFrame.Length > 0)
            {
                if(lastFrame.First() == 10)
                {
                    standardFrames.Add(new int[]{lastFrame.First()});
                    standardFrames.Add(new int[]{lastFrame[1]});
                    standardFrames.Add(new int[]{lastFrame[2]});
                }
                else
                {
                    standardFrames.Add(new int[]{lastFrame[0], lastFrame[1]});
                    standardFrames.Add(new int[]{lastFrame.Last()});
                }
            }

            KeyValuePair<int, int>[] framesPartialScore = standardFrames
                .Select(frame => KeyValuePair.Create((frame.Length % 2) + 1, frame.Sum()))
                .ToArray();

            int length = framesPartialScore.Length > 10 ? framesPartialScore.Length - 1 : framesPartialScore.Length;
            int[] framesScore = new int[length];
            Array.Copy(framesPartialScore.Select(partialScore => partialScore.Value).ToArray(), framesScore, length);

            for (int i = 0; i < framesPartialScore.Length && i < 10; i++)
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
                        break;
                    }
                }
            }

            int totalScore = framesScore
                .Take(10)
                .TakeWhile(score => score > 0)
                .Sum();

            Console.WriteLine(args[1]);
            Console.WriteLine(framesScore
                .Take(10)
                .Take(framesScore.TakeWhile(score => score > 0).Count() + 1)
                .Aggregate("", (acc, rollScore) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{(rollScore < 0 ? "-" : rollScore.ToString())}"));
            Console.WriteLine(totalScore > 0 ? totalScore.ToString() : "-");
        }
    }
}
