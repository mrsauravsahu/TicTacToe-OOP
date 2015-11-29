namespace TicTacToe
{
    class Piece
    {
        public Piece(string symbol)
        {
            this.symbol = symbol;
        }

        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public override string ToString()
        {
            return string.Format(" {0} ", symbol);
        }
    }    
}
