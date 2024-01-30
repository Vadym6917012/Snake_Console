namespace Snake
{
    public class Snake
    {
        public List<Position> Body { get; set; }
        public Directions CurrentDirection { get; private set; }
        public Snake(Position initialPosition)
        {
            Body = new List<Position> { initialPosition };
            CurrentDirection = Directions.Right;
        }

        public void Move()
        {
            Position newHead = Body[0];

            switch (CurrentDirection)
            {
                case Directions.Up:
                    {
                        newHead = new Position(Body[0].X, Body[0].Y - 1);
                        break;
                    }
                case Directions.Down:
                    {
                        newHead = new Position(Body[0].X, Body[0].Y + 1);
                        break;
                    }
                case Directions.Left:
                    {
                        newHead = new Position(Body[0].X - 1, Body[0].Y);
                        break;
                    }
                case Directions.Right:
                    {
                        newHead = new Position(Body[0].X + 1, Body[0].Y);
                        break;
                    }
            }

            Body.Insert(0, newHead);

            Body.RemoveAt(Body.Count - 1);
        }

        public void Grow()
        {
            Body.Add(new Position(0, 0));
        }

        public void ChangeDirection(Directions newDirection)
        {
            if (IsOppositeDirection(newDirection))
            {
                return;
            }
           
            CurrentDirection = newDirection;
        }

        private bool IsOppositeDirection(Directions newDirection)
        {
            return (CurrentDirection == Directions.Up && newDirection == Directions.Down) ||
                   (CurrentDirection == Directions.Down && newDirection == Directions.Up) ||
                   (CurrentDirection == Directions.Left && newDirection == Directions.Right) ||
                   (CurrentDirection == Directions.Right && newDirection == Directions.Left);
        }
    }
}
