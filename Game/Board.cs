using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        public Board(int size)
        {
            this.count = 0;
            this.size = size;
            cell = new List<List<Cell>>(size);
            for (int i = 0; i < size; i++)
            {
                cell.Add(new List<Cell>(size));
                for (int j = 0; j < size; j++)
                {
                    cell[i].Add(new Cell(i * size + j + 1));
                }
            }
        }

		
		private int size;
        private int count;
        private List<List<Cell>> cell;

		//Properties
		public int Size
		{
			get { return size; }
		}
		public int Count
		{
			get { return count; }
			set { count = value; }
		}
		public List<List<Cell>> Cell
		{
			get { return cell; }
		}

		public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                s.Append("\n");
                for (int j = 0; j < size; j++)
                {
                    s.Append(string.Format("\t{0}\t", (cell[i][j]).ToString()));
                }
            }
            return s.ToString();
        }
        public string Display()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                s.Append("\n");
                for (int j = 0; j < size; j++)
                {
                    if (cell[i][j].IsOccupied == false)
                        s.Append(string.Format("\t{0}\t", (cell[i][j]).Position));
                    else
                        s.Append(string.Format("\t{0}\t", (cell[i][j]).Character));
                }
            }
            return s.ToString();
        }
    }
}
