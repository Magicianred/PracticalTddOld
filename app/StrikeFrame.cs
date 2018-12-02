namespace app
{
    public class StrikeFrame : IBowlingFrame
    {
        private readonly Roll[] _rolls;

        public StrikeFrame(Roll[] rolls)
        {
            _rolls = rolls;
        }
    }
}