using app;
using Moq;
using Xunit;

namespace tests.unit
{
    public class BowlingFramesQueueTests
    {
        [Fact]
        public void Dequeueing_AnEmptyQueue_ReuturnsFalse()
        {
            BowlingFramesQueue queue = new BowlingFramesQueue();
            Assert.False(queue.TryDequeue(out var frame));
        }

        [Fact]
        public void Dequeueing_AFullQueue_ReuturnsTrue()
        {
            BowlingFramesQueue queue = new BowlingFramesQueue(new []{new Mock<IBowlingFrame>().Object});
            Assert.True(queue.TryDequeue(out var frame));
        }
    }
}