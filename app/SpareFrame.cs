namespace app
{
    public class SpareFrame : IBowlingFrame
    {
        private readonly Roll[] _rolls;

        public SpareFrame(Roll[] rolls)
        {
            _rolls = rolls;
        }
    }
}