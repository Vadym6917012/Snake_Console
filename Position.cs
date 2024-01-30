namespace Snake
{
    public struct Position
    {
        public int X {  get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            Y = y;
            X = x;
        }
    }
}
