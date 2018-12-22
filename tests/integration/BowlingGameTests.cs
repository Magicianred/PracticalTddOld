using System.Collections.Generic;
using app;
using Xunit;

namespace tests.integration
{
    public class BowlingGameTests
    {
        [Fact]
        public void Test_EmptyFrames()
        {
            List<IBowlingFrame> frames = new List<IBowlingFrame>();

            BowlingGame bowlingGame = new BowlingGame(frames);
            app.FrameScores scores = bowlingGame.CalculateFrameScores();

            Assert.Equal(0, scores.TotalScore);
        }

        [Fact]
        public void Test_OneOpenFrame()
        {
            List<IBowlingFrame> frames = new List<IBowlingFrame>();
            frames.Add(new OpenFrame(new Roll(1), new Roll(1)));

            BowlingGame bowlingGame = new BowlingGame(frames);
            app.FrameScores scores = bowlingGame.CalculateFrameScores();

            Assert.Equal(2, scores.TotalScore);
        }
    }
}