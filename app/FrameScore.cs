namespace app
{
    public class FrameScore : IFrameScore
    {
        public FrameScore(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public bool IsOpen => false;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}