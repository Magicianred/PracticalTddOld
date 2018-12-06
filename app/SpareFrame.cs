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

        public int GetScore(Queue<IBowlingFrame> framesStack)
        {
            if(framesStack.Count < 1) return -1;

            return OpenValue + framesStack.First().OpenValue;
        }
    }
}