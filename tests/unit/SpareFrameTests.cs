using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class SpareFrameTests
    {
        SpareFrame _frameUnderTest;
        OpenFrame _other;

        public SpareFrameTests()
        {
            _frameUnderTest = new SpareFrame(new Roll(5));
            _other = new OpenFrame(new Roll(1), new Roll(1));
        }

        [Fact]
        public void Expectations_From_GetScore()
        {
            var frames = new Queue<IBowlingFrame>(new []{ _other });
            Assert.Equal(12, _frameUnderTest.GetScore(frames));
        }


        [Fact]
        public void Expectations_From_GetScore_OfAnOpen_SpareFrame()
        {
            var frames = new Queue<IBowlingFrame>();
            Assert.Equal(-1, _frameUnderTest.GetScore(frames));
        }

        [Fact]
        public void Expectations_FromOpenFrame_OpenValue()
        {
            Assert.Equal(10, _frameUnderTest.OpenValue);
        }
    }
}