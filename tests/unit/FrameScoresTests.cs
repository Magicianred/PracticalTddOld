using Xunit;
using app;
using Moq;

namespace tests.unit
{
    public class FrameScoresTests
    {
        [Fact]
        public void TotalSum_Of_EmptyFrameScores()
        {
            app.FrameScores scores = new app.FrameScores();
            Assert.Equal(0, scores.TotalScore);
        }

        [Fact]
        public void TotalSum_Of_FrameScores()
        {
            app.FrameScores scores = new app.FrameScores();
            Mock<IFrameScore> scoreMock = new Mock<IFrameScore>();
            scoreMock
                .Setup( score => score.Value )
                .Returns(1);

            scores.Add(scoreMock.Object);
            scores.Add(scoreMock.Object);
            scores.Add(scoreMock.Object);
            Assert.Equal(3, scores.TotalScore);
        }

        [Fact]
        public void TotalSum_Of_FrameScores_AtFirstOpenScore_IsZero()
        {
            app.FrameScores scores = new app.FrameScores();
            Mock<IFrameScore> scoreMock = new Mock<IFrameScore>();
            scoreMock
                .Setup( score => score.Value )
                .Returns(1);
            Mock<IFrameScore> openScoreMock = new Mock<IFrameScore>();
            openScoreMock
                .Setup( score => score.Value )
                .Returns(0);
            openScoreMock
                .Setup( score => score.IsOpen )
                .Returns(true);

            scores.Add(openScoreMock.Object);
            scores.Add(scoreMock.Object);
            Assert.Equal(0, scores.TotalScore);
        }
    }
}