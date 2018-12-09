using System.Collections.Generic;
using System.Linq;

namespace app {
    public class OpenFrame : IBowlingFrame {
        private readonly Roll[] _rolls;
        private readonly int _rollSum;

        public OpenFrame (Roll roll1, Roll roll2) {
            _rolls = new Roll[]{roll1, roll2};
            _rollSum = _rolls.Sum(roll => roll.RollValue);
        }

        public int OpenValue => _rollSum;

        public int Consumes => 1;

        public List<IBowlingFrame> GetInternalFrames()
        {
            return new List<IBowlingFrame>(){this};
        }

        public int GetScore(BowlingFramesQueue frames)
        {
            return _rollSum;
        }
    }
}