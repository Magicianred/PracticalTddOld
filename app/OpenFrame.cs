namespace app {
    public class OpenFrame : IBowlingFrame {
        private readonly Roll[] _roll;
        public OpenFrame (Roll[] roll) {
            _roll = roll;
        }
    }
}