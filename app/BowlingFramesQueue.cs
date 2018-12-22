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

        public IFrameScore GetCurrentScore(IBowlingFrame currentFrame, int howManyRolls)
        {
            if(_framesQueue.Sum(frame => frame.ConsumesRolls) < howManyRolls) return new OpenScore();

            return new FrameScore(currentFrame.OpenValue + _framesQueue
                .SelectMany(frame => frame.GetInternalFrames())
                .Take(howManyRolls)
                .Sum(frame => frame.OpenValue));
        }
    }
}