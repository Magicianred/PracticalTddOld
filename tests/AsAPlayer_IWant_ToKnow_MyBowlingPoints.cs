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
        [InlineData("1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1", "2,2,2,2,2,2,2,2,2,2", "20")] // All open frames
        [InlineData("5-5,1-1", "12,2", "14")] // One closed Spare
        [InlineData("5-5,1-1,3-7,4-1", "12,2,15,5", "34")] // Two closed Spares
        [InlineData("5-5", "-", "-")] // One open Spare
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
