namespace app
{
    public class Roll
    {

        public Roll(int rollValue)
        {
            if(rollValue > 10){
                throw new RollException($"can't assign a value bigger than 10 to a Roll. You assigne {rollValue}");
            }
            RollValue = rollValue;
        }

        public int RollValue { get; }
    }
}
