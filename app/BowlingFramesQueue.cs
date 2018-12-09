using System;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class BowlingFramesQueue
    {
        private Queue<IBowlingFrame> _framesQueue;

        public BowlingFramesQueue()
        {
            _framesQueue = new Queue<IBowlingFrame>();
        }

        public BowlingFramesQueue(IEnumerable<IBowlingFrame> frames)
        {
            _framesQueue = new Queue<IBowlingFrame>(frames);
        }

        public bool TryDequeue(out IBowlingFrame frame)
        {
            return _framesQueue.TryDequeue(out frame);
        }

        public int GetCurrentScore(IBowlingFrame currentFrame, int howManyScores)
        {
            if(_framesQueue.Sum(frame => frame.Consumes) < howManyScores) return -1;

            return currentFrame.OpenValue+ _framesQueue
                .SelectMany(frame => frame.GetInternalFrames())
                .Take(howManyScores)
                .Sum(frame => frame.OpenValue);
        }
    }
}