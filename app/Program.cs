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
            BowlingGame bowlingGame = new BowlingGame(frames);
            FrameScores scores = bowlingGame.CalculateFrameScores();
            OutputScoresToConsole(args, scores);
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

        private static void OutputScoresToConsole(string[] args, FrameScores framesScore)
        {
            Console.WriteLine(args[1]);
            Console.WriteLine(framesScore.ToString());
            int totalScore = framesScore.TotalScore;
            Console.WriteLine(totalScore > 0 ? totalScore.ToString() : "-");
        }
    }
}
