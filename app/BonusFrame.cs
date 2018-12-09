using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class BonusFrame : IBowlingFrame
    {
        private readonly Roll[] _rolls;
        private readonly int _sum;

        public BonusFrame(Roll roll)
        {
            _rolls = new []{roll};
            _sum = roll.RollValue;
        }

        public BonusFrame(Roll roll1, Roll roll2)
        {
            _rolls = new []{roll1, roll2};
            _sum = _rolls.Sum(roll => roll.RollValue);
        }

        public int Consumes => 1;

        public int OpenValue => _sum;

        public int GetScore(BowlingFramesQueue frames)
        {
            return _sum;
        }

        public List<IBowlingFrame> GetInternalFrames()
        {
            return new List<IBowlingFrame>(){this};
        }
    }
}