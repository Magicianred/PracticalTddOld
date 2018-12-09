using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class SpareFrame : IBowlingFrame
    {
        private readonly Roll[] _rolls;

        public SpareFrame(Roll roll1)
        {
            _rolls = new Roll[]{roll1, new Roll(10 - roll1.RollValue)};
        }

        public int OpenValue => 10;

        public int Consumes => 1;

        public int GetScore(BowlingFramesQueue frames)
        {
            return frames.GetCurrentScore(this, 1);
        }

        public List<IBowlingFrame> GetInternalFrames()
        {
            return new List<IBowlingFrame>(){this};
        }
    }
}