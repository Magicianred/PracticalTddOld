using System;
using System.Collections.Generic;

namespace app {
    public class BowlingGame {
        private readonly List<IBowlingFrame> _frames;
        public BowlingGame (List<IBowlingFrame> frames) {
            _frames = frames;
        }

        public FrameScores CalculateFrameScores ()
        {
            FrameScores scores = new FrameScores();

            var framesQueue = new BowlingFramesQueue(_frames);

            while(framesQueue.TryDequeue(out var frame))
            {
                IFrameScore score = frame.GetScore(framesQueue);
                scores.Add(score);
            }

            return scores;
        }
    }
}