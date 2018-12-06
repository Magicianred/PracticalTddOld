﻿using System;
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
            return ConvertLastFrameToAStandardFrame(frames);
        }

        private static List<IBowlingFrame> ConvertLastFrameToAStandardFrame(IBowlingFrame[] frames)
        {
            // List<Roll[]> standardFrames = frames.Where(frame => frame.Length < 3).ToList();
            // Roll[] lastFrame = frames.Where(frame => frame.Length == 3).FirstOrDefault() ?? new Roll[0];

            // if (lastFrame.Length > 0)
            // {
            //     if (lastFrame.First().RollValue == 10)
            //     {
            //         standardFrames.Add(new Roll[] { lastFrame.First() });
            //         standardFrames.Add(new Roll[] { lastFrame[1] });
            //         standardFrames.Add(new Roll[] { lastFrame[2] });
            //     }
            //     else
            //     {
            //         standardFrames.Add(new Roll[] { lastFrame[0], lastFrame[1] });
            //         standardFrames.Add(new Roll[] { lastFrame.Last() });
            //     }
            // }

            // return standardFrames;
            return frames.ToList();
        }

        private static IBowlingFrame[] StringToArrayOfFrames(string[] inputFramesStr)
        {
            return inputFramesStr
                .Select(frameInputStr => frameInputStr.Split('-'))
                .Select(frameAsStr => BowlingFrames.From(Array.ConvertAll(frameAsStr, rollStr => new Roll(Convert.ToInt32(rollStr)))))
                .ToArray();
        }

        private static int[] CalculateFramesScores(List<IBowlingFrame> frames)
        {
            List<int> scores = new List<int>();
            var framesQueue = new Queue<IBowlingFrame>(frames);

            while(framesQueue.TryDequeue(out var frame)){
                int score = frame.GetScore(framesQueue);
                scores.Add(score);
            }

            return scores.ToArray();

            // KeyValuePair<int, int>[] framesPartialScore = ComputePartialScores(frames);

            // int length = framesPartialScore.Length > 10 ? framesPartialScore.Length - 1 : framesPartialScore.Length;
            // int[] framesScore = new int[length];
            // Array.Copy(framesPartialScore.Select(partialScore => partialScore.Value).ToArray(), framesScore, length);

            // for (int i = 0; i < framesPartialScore.Length && i < 10; i++)
            // {
            //     int score = framesPartialScore[i].Value;
            //     int framesToAdd = framesPartialScore[i].Key;
            //     if (score == 10)
            //     {
            //         if (i < framesPartialScore.Length - framesToAdd)
            //         {
            //             for (int j = 0; j < framesToAdd; j++)
            //             {
            //                 framesScore[i] += framesPartialScore[i + j + 1].Value;
            //             }
            //         }
            //         else
            //         {
            //             framesScore[i] = -1;
            //             break;
            //         }
            //     }
            // }

            // return framesScore;
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
