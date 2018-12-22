using System.Collections.Generic;
using app;
using Xunit;

namespace tests.unit
{
    public class OpenScoresTests
    {
        [Fact]
        public void AnOpenScore_IsAlways_Valued_ToZero()
        {
            var openScore = new OpenScore();
            Assert.Equal(0, openScore.Value);
        }


        [Fact]
        public void ToString_IsAlways_hyphen()
        {
            OpenScore frameScore = new OpenScore();
            Assert.Equal(@"-", frameScore.ToString());
        }
    }
}