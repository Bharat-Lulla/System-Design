using TicTacToe.Enums;

namespace TicTacToe.Models
{
    public class Board
    {
        public int Size {get;}

        public PlayingPiece[,]? Grid {get;}

        public Board(int size)
        {
            Size = size;
            Grid = new PlayingPiece[size,size];
        }

        public bool AddPiece(int row, int col, PlayingPiece piece)
        {
            if(Grid == null) return false;
            if(Grid[row, col] != null)
            {
                return false;
            }
            Grid[row,col] = piece;
            return true;
        }

        public List<(int row, int col)> GetFreeCell()
        {
            var freeCell = new List<(int row, int col)>();

            if(Grid == null)
            {
                return freeCell;
            }

            for(int i=0; i<Size; i++)
            {
                for(int j=0; j<Size; j++)
                {
                    if(Grid[i,j] == null)
                    {
                        freeCell.Add((i,j));
                    }
                }
            }
            return freeCell;
        }

        public void PrintBoard()
        {
            if(Grid == null)
            {
                return;
            }

            for(int i=0; i<Size; i++)
            {
                for(int j=0; j<Size; j++)
                {
                    if(Grid[i,j] != null)
                    {
                        Console.Write($" {Grid[i,j]._pieceType} ");
                    }
                    else
                    {
                        Console.Write($"   ");
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}