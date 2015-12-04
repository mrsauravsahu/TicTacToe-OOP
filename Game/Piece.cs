namespace TicTacToe
{
    class Piece
    {
        public Piece(string symbol)
        {
            this.symbol = symbol;
        }

        private string symbol;

		//Properties
		public string Symbol
		{
			get { return symbol; }
		}

		public override string ToString()
        {
            return string.Format(" {0} ", symbol);
        }
    }    
}
