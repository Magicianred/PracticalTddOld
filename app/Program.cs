using System;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBowlingFrame> frames = InitializeFrames(args);
            int[] framesScore = CalculateFramesScores(frames);
            int totalScore = CalculateTotalScore(framesScore);
            OutputScoresToConsole(args, framesScore, totalScore);
        }

        private static List<IBowlingFrame> InitializeFrames(string[] args)
        {
            string[] inputFramesStr = args[1].Split(',');
            IBowlingFrame[] frames = StringToArrayOfFrames(inputFramesStr);
            return frames.ToList();
        }

        private static IBowlingFrame[] StringToArrayOfFrames(string[] inputFramesStr)
        {
            return inputFramesStr
                .Select(frameInputStr => frameInputStr.Split('-'))
                .Select((frameAsStr, i) => BowlingFrames.From(Array.ConvertAll(frameAsStr, rollStr => new Roll(Convert.ToInt32(rollStr))), i + 1))
                .ToArray();
        }

        private static int[] CalculateFramesScores(List<IBowlingFrame> frames)
        {
            List<int> scores = new List<int>();

            var framesQueue = new BowlingFramesQueue(frames);

            while(framesQueue.TryDequeue(out var frame)){
                int score = frame.GetScore(framesQueue);
                scores.Add(score);
            }

            return scores.ToArray();
        }

        private static KeyValuePair<int, int>[] ComputePartialScores(List<Roll[]> standardFrames)
        {
            return standardFrames
                .Select(frame => KeyValuePair.Create((frame.Length % 2) + 1, frame.Sum(roll => roll.RollValue)))
                .ToArray();
        }

        private static int CalculateTotalScore(int[] framesScore)
        {
            return framesScore
                            .Take(10)
                            .TakeWhile(score => score > 0)
                            .Sum();
        }

        private static void OutputScoresToConsole(string[] args, int[] framesScore, int totalScore)
        {
            Console.WriteLine(args[1]);
            Console.WriteLine(framesScore
                .Take(10)
                .Take(framesScore.TakeWhile(score => score > 0).Count() + 1)
                .Aggregate("", (acc, rollScore) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{(rollScore < 0 ? "-" : rollScore.ToString())}"));
            Console.WriteLine(totalScore > 0 ? totalScore.ToString() : "-");
        }
    }
}
