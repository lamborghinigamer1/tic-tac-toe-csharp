namespace TicTacToe
{
    public class Player
    {
        public string Name
        {
            get;
        }
        public char Icon
        {
            get;
        }
        public Player(string name, char icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}