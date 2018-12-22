using System;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class FrameScores
    {
        private List<IFrameScore> _scores;

        public FrameScores()
        {
            _scores = new List<IFrameScore>();
        }

        public int TotalScore => _scores
            .TakeWhile(score => !score.IsOpen)
            .Sum(score => score.Value);

        public void Add(IFrameScore score)
        {
            _scores.Add(score);
        }

        public override string ToString()
        {
            return _scores
                .Select(score => score.ToString())
                .Take(_scores.TakeWhile(score => score.ToString() != "-").Count() + 1)
                .Aggregate("", (acc, rollScoreStr) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{rollScoreStr}");
        }
    }
}