using System.Collections.Generic;

namespace app
{
    public interface IBowlingFrame
    {
        int GetScore(BowlingFramesQueue framesQueue);
        int OpenValue { get; }

        int Consumes { get; }

        List<IBowlingFrame> GetInternalFrames();
    }
}
