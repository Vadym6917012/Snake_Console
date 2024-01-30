namespace Snake
{
    class Program
    {
        public static int width = Console.WindowWidth;
        public static int height = Console.WindowHeight;
        private static int _score = 0;

        private static bool gameOver;

        private static Snake? snake;
        private static Fruit? fruit;

        public static void Main(string[] args)
        {
            Console.BufferWidth = Console.WindowWidth = 80;
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.SetWindowSize(80, 25);

            InitializeGame();

            while (!gameOver)
            {
                DrawGame();
                Input();
                snake.Move();

                if (SnakeHasEatenFruit())
                {
                    snake.Grow();
                    fruit.GenerateNewPosition();
                    _score += 300;
                }
                if (SnakeHasEatenItSelf() || SnakeCollidesWithWalls())
                {
                    gameOver = true;
                }

                Thread.Sleep(100);
            }

            Console.Clear();
            Console.SetCursorPosition(width / 2, height / 2);
            Console.WriteLine("Game Over!");
            Console.ReadLine();
        }

        private static bool SnakeHasEatenFruit()
        {
            return snake.Body.Any(segment => segment.X == fruit.Position.X && segment.Y == fruit.Position.Y);
        }

        private static bool SnakeHasEatenItSelf()
        {
            Position head = snake.Body[0];

            return snake.Body.Skip(1).Any(segment => segment.X == head.X && segment.Y == head.Y);
        }

        private static bool SnakeCollidesWithWalls()
        {
            Position head = snake.Body[0];

            if (head.X >= width || head.X < 0 || head.Y >= width || head.Y < 0)
            {
                return true;
            }

            return false;
        }


        public static void InitializeGame()
        {
            gameOver = false;

            snake = new Snake(new Position(width / 2, height / 2));

            fruit = new Fruit();
        }

        public static void DrawBorder()
        {
            Console.Clear();

            Console.WriteLine($"Score: {_score}");
        }

        public static void DrawGame()
        {
            Console.Clear();
            DrawBorder();  

            foreach (var position in snake.Body)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write("*");
            }

            Console.SetCursorPosition(fruit.Position.X, fruit.Position.Y);
            Console.Write("F");
        }

        public static void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.ChangeDirection(Directions.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.ChangeDirection(Directions.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.ChangeDirection(Directions.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.ChangeDirection(Directions.Right);
                        break;
                    case ConsoleKey.Escape:
                        gameOver = true;
                        break;
                }
            }
        }
    }
}
