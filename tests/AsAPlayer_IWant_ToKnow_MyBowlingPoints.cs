using System;
using Xunit;
using app;
using System.IO;

namespace tests
{
    public class AsAPlayer_IWant_ToKnow_MyBowlingPoints
    {
        [Theory]
        [InlineData("10,10,10,10,10,10,10,10,10,10-10-10", "30,30,30,30,30,30,30,30,30,30", "300")] // All strikes
        [InlineData("1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1-1", "2,2,2,2,2,2,2,2,2,3", "21")] // All open frames
        public void RunningTheProgram_WithGivenInputString_WillWriteTheOutput_InTheConsole(string rolls, string expectedScoreByFrame, string expectedTotalScore)
        {
            //Execute
            using(StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new[]{"-r", rolls});
                string consoleOut = sw.ToString();
                string[] lines = consoleOut.Split(Environment.NewLine);

                //Assert
                Assert.Equal(4, lines.Length);
                string outRolls = lines[0];
                string outScoreByFrame = lines[1];
                string outTotalScore = lines[2];

                Assert.Equal(rolls, outRolls);
                Assert.Equal(expectedScoreByFrame, outScoreByFrame);
                Assert.Equal(expectedTotalScore, outTotalScore);
            }
        }
    }
}
