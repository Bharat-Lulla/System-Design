namespace TicTacToe.Models
{
    public class Player
    {
        public string Name {get; set;}
        public PlayingPiece PlayingPiece {get; set;}

        public Player(string name, PlayingPiece playingPiece)
        {
            Name = name;
            PlayingPiece = playingPiece;
        }
    }
}