using System;
using System.Linq;

namespace app
{
    public class BowlingFrames
    {
        public static IBowlingFrame From(Roll[] rolls, int position = 0)
        {
            if(position == 10)
            {
                return new LastFrame(rolls);
            }

            int rollSum = rolls.Sum(roll => roll.RollValue);

            if(rollSum == 10 && rolls.Length == 1) return new StrikeFrame();
            if(rollSum == 10) return new SpareFrame(rolls[0]);

            return new OpenFrame(rolls[0], rolls[1]);
        }
    }
}
