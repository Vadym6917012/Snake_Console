
namespace Snake
{
    public class Fruit
    {
        public Position Position { get; set; }

        public Fruit() 
        {
            GenerateNewPosition();
        }

        public void GenerateNewPosition()
        {
            Random r = new Random();
            Position = new Position(r.Next(1, Program.width - 2), r.Next(1, Program.height - 2));
        }
    }
}
