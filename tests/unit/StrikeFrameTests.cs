using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class StrikeFrameTests
    {
        private StrikeFrame _frameUnderTest;
        private OpenFrame _other1;
        private OpenFrame _other2;

        public StrikeFrameTests()
        {
            _frameUnderTest = new StrikeFrame();
            _other1 = new OpenFrame(new Roll(1), new Roll(1));
            _other2 = new OpenFrame(new Roll(1), new Roll(1));
        }

        [Fact]
        public void Expectations_From_GetScore()
        {
            var frames = new Queue<IBowlingFrame>(new []{ _other1, _other2 });
            Assert.Equal(14, _frameUnderTest.GetScore(frames));
        }


        [Fact]
        public void Expectations_From_GetScore_OfAnOpen_StrikeFrame_WithOne_Subsequent()
        {
            var frames = new Queue<IBowlingFrame>(new []{ _other1 });
            Assert.Equal(-1, _frameUnderTest.GetScore(frames));
        }

        [Fact]
        public void Expectations_From_GetScore_OfAnOpen_StrikeFrame_WithNo_Subsequent()
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