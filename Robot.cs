namespace Events {
    public enum Direction { Forward, Backward, Left, Rigth }

    class Robot {
        private event EventHandler BackwardEvent;
        public Robot() {
            Random random = new Random();
            BackwardEvent += HandleBackwardEvent;
            var timer = new Timer(RandomMoveLog, random, 500, 500);
        }

        private void RandomMoveLog(object state) {
            var values = typeof(Direction).GetEnumValues();
            var direction = (Direction)values.GetValue(((Random)state).Next(values.Length));
            Console.WriteLine(direction);
            if (direction == Direction.Backward) {
                BackwardEvent.Invoke(null, EventArgs.Empty);
            }
        }

        private void HandleBackwardEvent(object sender, EventArgs e) {
            using (StreamWriter sw = new StreamWriter("test.txt", true, System.Text.Encoding.Default)) {
                sw.WriteLine("Backward event happened");
                }
        }
    }
}