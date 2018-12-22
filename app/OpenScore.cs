namespace app
{
    public class OpenScore : IFrameScore
    {
        public int Value => 0;

        public bool IsOpen => true;

        public override string ToString() => "-";
    }
}