using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class FrameScoreTests
    {
        [Fact]
        public void ValueOfAScore()
        {
            FrameScore frameScore = new FrameScore(1);
            Assert.Equal(1, frameScore.Value);
        }

        [Fact]
        public void ToStringOfAScore()
        {
            FrameScore frameScore = new FrameScore(1);
            Assert.Equal(@"1", frameScore.ToString());
        }
    }
}