using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class SpareFrameTests
    {
        SpareFrame _frameUnderTest;

        public SpareFrameTests()
        {
            _frameUnderTest = new SpareFrame(new Roll(5));
        }

        [Fact]
        public void Expectations_From_GetScore()
        {
            var frames = new BowlingFramesQueue(new []{ new OpenFrame(new Roll(1), new Roll(1)) });
            Assert.Equal(12, _frameUnderTest.GetScore(frames).Value);
        }

        [Fact]
        public void Expectations_From_GetScore_FromLastFrame_WithTwoValues()
        {
            var frames = new BowlingFramesQueue(new []{ new LastFrame(new[]{ new Roll(1), new Roll(1) } ) });
            Assert.Equal(12, _frameUnderTest.GetScore(frames).Value);
        }

        [Fact]
        public void Expectations_From_GetScore_FromLastFrame_WithOneSpare()
        {
            var frames = new BowlingFramesQueue(new []{ new LastFrame(new[]{ new Roll(5), new Roll(5), new Roll(5) } ) });
            Assert.Equal(20, _frameUnderTest.GetScore(frames).Value);
        }

        [Fact]
        public void Expectations_From_GetScore_FromLastFrame_WithTwoStrikes()
        {
            var frames = new BowlingFramesQueue(new []{ new LastFrame(new[]{ new Roll(10), new Roll(10), new Roll(10) } ) });
            Assert.Equal(20, _frameUnderTest.GetScore(frames).Value);
        }


        [Fact]
        public void Expectations_From_GetScore_OfAnOpen_SpareFrame()
        {
            var frames = new BowlingFramesQueue();
            Assert.Equal(0, _frameUnderTest.GetScore(frames).Value);
        }

        [Fact]
        public void Expectations_FromOpenFrame_OpenValue()
        {
            Assert.Equal(10, _frameUnderTest.OpenValue);
        }

        [Fact]
        public void SpareFrame_Consumes1()
        {
            Assert.Equal(1, _frameUnderTest.ConsumesRolls);
        }
    }
}