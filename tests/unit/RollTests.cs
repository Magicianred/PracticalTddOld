using app;
using Xunit;

namespace tests.unit
{
    public class RollTests
    {
        [Fact]
        public void ARoll_Assigned_WithAValue_More_Than10_Throws()
        {
            Assert.Throws<RollException>(() => new Roll(11));
        }
    }
}