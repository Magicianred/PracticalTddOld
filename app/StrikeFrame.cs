using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class StrikeFrame : IBowlingFrame
    {
        private readonly Roll _roll;

        public StrikeFrame()
        {
            _roll = new Roll(10);
        }

        public int OpenValue => _roll.RollValue;

        public int Consumes => 1;

        public List<IBowlingFrame> GetInternalFrames()
        {
            return new List<IBowlingFrame>(){this};
        }

        public int GetScore(BowlingFramesQueue frames)
        {
            return frames.GetCurrentScore(this, 2);
        }
    }
}