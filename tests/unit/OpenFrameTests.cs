using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class OpenFrameTests
    {
        OpenFrame _frameUnderTest;
        OpenFrame _other;

        public OpenFrameTests()
        {
            _frameUnderTest = new OpenFrame(new Roll(1), new Roll(1));
            _other = new OpenFrame(new Roll(1), new Roll(1));
        }

        [Fact]
        public void Expectations_FromOpenFrame_GetScore()
        {
            var frames = new BowlingFramesQueue(new []{ _other });
            Assert.Equal(2, _frameUnderTest.GetScore(frames));
        }

        [Fact]
        public void Expectations_FromOpenFrame_OpenValue()
        {
            Assert.Equal(2, _frameUnderTest.OpenValue);
        }

        [Fact]
        public void OpenFrame_Consumes1()
        {
            Assert.Equal(1, _frameUnderTest.Consumes);
        }
    }
}