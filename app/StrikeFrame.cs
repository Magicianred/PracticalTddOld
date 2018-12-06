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

        public int GetScore(Queue<IBowlingFrame> framesQueue)
        {
            if(framesQueue.Count < 2) return -1;
            return _roll.RollValue + framesQueue.Take(2).Sum(frame => frame.OpenValue);
        }
    }
}