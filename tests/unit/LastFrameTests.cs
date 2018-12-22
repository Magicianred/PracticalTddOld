using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class LastFrameTests
    {
        LastFrame _frameUnderTest;
        private LastFrame _frameUnderTest2;
        private LastFrame _frameUnderTest3;
        private LastFrame _frameUnderTest4;
        private LastFrame[] _framesUnderTest;
        OpenFrame _other;

        public LastFrameTests()
        {
            _frameUnderTest = new LastFrame(new []{new Roll(5), new Roll(5), new Roll(1)});
            _frameUnderTest2 = new LastFrame(new []{new Roll(10), new Roll(10), new Roll(10)});
            _frameUnderTest3 = new LastFrame(new []{new Roll(10), new Roll(3), new Roll(2)});
            _frameUnderTest4 = new LastFrame(new []{new Roll(1), new Roll(1)});

            _framesUnderTest = new LastFrame[]{_frameUnderTest, _frameUnderTest2, _frameUnderTest3, _frameUnderTest4};
        }

        [Theory]
        [InlineData(0, 11)]
        [InlineData(1, 30)]
        [InlineData(2, 15)]
        [InlineData(3, 2)]
        public void Expectations_FromLastFrame_GetScore(int frameUnderTestIndex, int expectedResult)
        {
            Assert.Equal(expectedResult, _framesUnderTest[frameUnderTestIndex].GetScore(new BowlingFramesQueue()).Value);
        }

        [Fact]
        public void LastFrame_Consumes2()
        {
            Assert.Equal(2, _frameUnderTest.ConsumesRolls);
        }
    }
}