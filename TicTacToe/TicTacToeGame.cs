using TicTacToe.Enums;
using TicTacToe.Models;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private LinkedList<Player> _players;
        private Board _gameBoard;
        public Player _winner;

        public void InitializeGame()
        {
            Player player1 = new Player("Bharat", new PlayingPieceO(PieceType.O));
            Player player2 = new Player("Anjali", new PlayingPieceX(PieceType.X));

            _players = new LinkedList<Player>();
            _players.AddLast(player1);
            _players.AddLast(player2);

            _gameBoard = new Board(3);
        }

        public bool CheckWinner(int row, int col, PieceType pieceType)
        {
            bool rowMatch = true;
            bool colMatch = true;
            bool diagonalMatch = true;
            bool antiDiagonalMatch = true;

            for(int i=0; i<_gameBoard.Size; i++)
            {
                if(_gameBoard.Grid[row, i] == null || _gameBoard.Grid[row, i]._pieceType != pieceType)
                {
                    rowMatch = false;
                    break;
                }
            }
            for(int i=0; i<_gameBoard.Size; i++)
            {
                if(_gameBoard.Grid[i,col] == null || _gameBoard.Grid[i,col]._pieceType != pieceType)
                {
                    colMatch = false;
                    break;
                }
            }

            for(int i=0, j=0; i<_gameBoard.Size; i++, j++)
            {
                if(_gameBoard.Grid[i,j] == null || _gameBoard.Grid[i,j]._pieceType != pieceType)
                {
                    diagonalMatch = false;
                    break;
                }
            }
            for(int i=0, j=_gameBoard.Size - 1 ; i<_gameBoard.Size; i++, j--)
            {
                if(_gameBoard.Grid[i,j] == null || _gameBoard.Grid[i,j]._pieceType != pieceType)
                {
                    antiDiagonalMatch = false;
                    break;
                }
            }
            
            return rowMatch || colMatch || diagonalMatch || antiDiagonalMatch;
        }

        public GameStatus StartGame()
        {
            bool noWinner = true;
            while (noWinner)
            {
                Player currentPlayer = _players.First.Value;
                _players.RemoveFirst();

                _gameBoard.PrintBoard();

                var freeSpace = _gameBoard.GetFreeCell();
                if(freeSpace.Count == 0)
                {
                    noWinner = false;
                    continue;
                }

                Console.Write($"Player: {currentPlayer.Name} - Please enter [row, col]: ");

                string input = Console.ReadLine();
                string[] values = input.Split(",");

                int rowValue = int.Parse(values[0]);
                int colValue = int.Parse(values[1]);

                bool checkValid = _gameBoard.AddPiece(rowValue, colValue, currentPlayer.PlayingPiece);

                if (!checkValid)
                {
                    _players.AddFirst(currentPlayer);
                    Console.WriteLine("Incorrect Position Chose, Try Again!");
                    continue;
                }

                _players.AddLast(currentPlayer);

                bool isWinner = CheckWinner(rowValue, colValue, currentPlayer.PlayingPiece._pieceType);

                if (isWinner)
                {
                    noWinner = false;
                    _winner = currentPlayer;
                    return GameStatus.WIN;
                }
            }
            return GameStatus.DRAW;
        }

    }
}