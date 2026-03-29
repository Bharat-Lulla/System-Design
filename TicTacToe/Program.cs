using TicTacToe.Enums;
using TicTacToe.Models;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n===>>> TicTacToe Game\n");
            
            TicTacToeGame game = new TicTacToeGame();
            game.InitializeGame();
            
            GameStatus status = game.StartGame();
            
            Console.Write("\n===>>> GAME OVER: ");

            // Modern C# 8+ Switch Expression replaces the bulky switch statement
            string resultMessage = status switch
            {
                // Notice: no 'case', no 'break', just a clean arrow (=>)
                GameStatus.WIN => $"{game._winner.Name} won the game",
                GameStatus.DRAW => "It's a Draw!",
                _ => "Game Ends" // The underscore (_) replaces 'default'
            };

            Console.WriteLine(resultMessage);
        }
    }
}