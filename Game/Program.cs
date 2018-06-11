using System;

namespace Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            var isContinuing = false;
            do
            {
                game.Run();
                Console.WriteLine();
                Console.WriteLine("Play again? y/n");
                var pressedKey = Console.ReadKey().Key;
                switch (pressedKey)
                {
                    case ConsoleKey.Y:
                        isContinuing = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.N:
                        isContinuing = false;
                        Console.WriteLine();
                        break;
                }
            } while (isContinuing);
        }
    }
}