using System;
using Xunit;
using app;
using System.IO;

namespace tests
{
    public class AsAPlayer_IWant_ToKnow_MyBowlingPoints
    {
        [Fact]
        public void RunningTheProgram_WithGivenInputString_WillWriteTheOutput_InTheConsole()
        {
            //Arrange
            string rolls = "10,10,10,10,10,10,10,10,10,10-10-10";
            string expectedScoreByFrame = "30,30,30,30,30,30,30,30,30,30";
            string expectedTotalScore = "300";

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
