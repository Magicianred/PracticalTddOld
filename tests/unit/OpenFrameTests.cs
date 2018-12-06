using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class OpenFrameTests
    {
        OpenFrame _frameOnTest;
        OpenFrame _other;

        public OpenFrameTests()
        {
            _frameOnTest = new OpenFrame(new Roll(1), new Roll(1));
            _other = new OpenFrame(new Roll(1), new Roll(1));
        }

        [Fact]
        public void Expectations_FromOpenFrame_GetScore()
        {
            var frames = new Queue<IBowlingFrame>(new []{ _other });
            Assert.Equal(2, _frameOnTest.GetScore(frames));
        }

        [Fact]
        public void Expectations_FromOpenFrame_OpenValue()
        {
            Assert.Equal(2, _frameOnTest.OpenValue);
        }
    }
}