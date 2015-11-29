namespace TicTacToe
{
    class Cell
    {
        public Cell(int position)
        {
            this.isOccupied = false;
            this.position = position;
            character = new Piece(string.Empty);
        }

        private bool isOccupied;
        public bool IsOccupied
        {
            get { return isOccupied; }
            set { isOccupied = value; }
        }

        private int position;
        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        private Piece character;
        public Piece Character
        {
            get { return character; }
            set { character = value; }
        }

        public override string ToString()
        {
            return character.ToString();
        }
    }
}
