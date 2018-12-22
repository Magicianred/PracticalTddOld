using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class LastFrame : IBowlingFrame
    {
        private Roll[] _rolls;
        private readonly List<IBowlingFrame> _internalFrames;

        public LastFrame(Roll[] rolls)
        {
            _rolls = rolls;
            _internalFrames = new List<IBowlingFrame>();

                if(rolls[0].RollValue == 10)
                {
                    _internalFrames.Add(new StrikeFrame());
                    _internalFrames.Add(new BonusFrame(rolls[1]));
                    _internalFrames.Add(new BonusFrame(rolls[2]));
                }
                else
                {
                    if(rolls[0].RollValue  + rolls[1].RollValue == 10)
                    {
                        _internalFrames.Add(new SpareFrame(rolls[0]));
                        _internalFrames.Add(new BonusFrame(rolls[2]));
                    }
                    else
                    {
                        _internalFrames.Add(new OpenFrame(rolls[0], rolls[1]));
                    }
                }

        }

        public List<IBowlingFrame> GetInternalFrames()
        {
            return _internalFrames;
        }

        public int OpenValue => _internalFrames.Sum(frame => frame.OpenValue);

        public int ConsumesRolls => 2;

        public IFrameScore GetScore(BowlingFramesQueue frames)
        {
            return new FrameScore(OpenValue);
        }
    }
}