using System.Collections.Generic;

namespace app
{
    public interface IBowlingFrame
    {
        int GetScore(Queue<IBowlingFrame> framesStack);
        int OpenValue { get; }
    }
}
