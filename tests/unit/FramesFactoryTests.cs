using app;
using Xunit;

namespace tests.unit
{
    public class FramesFactoryTests
    {
        [Fact]
        public void OpenFrameCreation()
        {
            var roll1 = new Roll(4);
            var roll2 = new Roll(2);

            IBowlingFrame frame = BowlingFrames.From(new Roll[]{roll1, roll2});
            Assert.IsType<OpenFrame>(frame);
        }

        [Fact]
        public void SpareFrameCreation()
        {
            var roll1 = new Roll(5);
            var roll2 = new Roll(5);

            IBowlingFrame frame = BowlingFrames.From(new Roll[]{roll1, roll2});
            Assert.IsType<SpareFrame>(frame);
        }

        [Fact]
        public void StrikeFrameCreation()
        {
            var roll1 = new Roll(10);

            IBowlingFrame frame = BowlingFrames.From(new Roll[]{roll1});
            Assert.IsType<StrikeFrame>(frame);
        }

        [Fact]
        public void LastFrameCreationWith_TwoRolls()
        {
            var roll1 = new Roll(1);
            var roll2 = new Roll(1);

            IBowlingFrame frame = BowlingFrames.From(new Roll[]{roll1, roll2}, 10);
            Assert.IsType<LastFrame>(frame);
        }

        [Fact]
        public void LastFrameCreationWith_ThreeRolls()
        {
            var roll1 = new Roll(5);
            var roll2 = new Roll(5);
            var roll3 = new Roll(1);

            IBowlingFrame frame = BowlingFrames.From(new Roll[]{roll1, roll2, roll3}, 10);
            Assert.IsType<LastFrame>(frame);
        }
    }


}