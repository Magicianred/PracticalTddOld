using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class BonusFrameTests
    {
        BonusFrame _frameUnderTest;

        public BonusFrameTests()
        {
            _frameUnderTest = new BonusFrame(new Roll(1), new Roll(1));
        }

        [Fact]
        public void Expectations_FromBonusFrame_GetScore()
        {
            Assert.Equal(2, _frameUnderTest.GetScore(new BowlingFramesQueue()));
        }

        [Fact]
        public void Expectations_FromBonusFrame_OpenValue()
        {
            Assert.Equal(2, _frameUnderTest.OpenValue);
        }

        [Fact]
        public void BonusFrame_Consumes1()
        {
            Assert.Equal(1, _frameUnderTest.Consumes);
        }
    }
}