using System.Collections.Generic;

namespace app
{
    public interface IBowlingFrame
    {
        IFrameScore GetScore(BowlingFramesQueue framesQueue);
        int OpenValue { get; }

        int ConsumesRolls { get; }

        List<IBowlingFrame> GetInternalFrames();
    }
}
