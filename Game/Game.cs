using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Game: Toss
    {
        List<Player> players;
        Board board; 

        public Game(int playersCount, int boardSize)
        {
            players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                players.Add(new Player(players));
            }
            board = new Board(boardSize);
            Toss();
        }

        public void Play()
        {
            Console.Clear();
            //Display player information
            foreach (var p in players)
            {
                Console.WriteLine("\n{0}\n", p.ToString());
            }
            for (int i = 0, j = 0; i < board.Size * board.Size; i++, j = (++j) % players.Count)
            {
             
                int position = 0;
                Player player = (from p in players
                                where p.Order == j
                                select p).First();
                Console.WriteLine(board.Display());
                position = player.Input();
                while (IsValid(board, position) == false)
                {
                    Console.WriteLine("Enter a valid position.");
                    position = player.Input();
                }
                WriteData(position, player);
                Console.WriteLine("{0} placed {1} at the position {2}.", player.Name, player.Piece.ToString(), position);
                Console.WriteLine(board.ToString());
                if (board.Count >= (2 * board.Size - 2))
                {
                    var winner = IsGameOver();
                    if (winner != null)
                    {
                        Console.WriteLine("\n{0} IS THE WINNER!!!", winner.Name.ToUpper());
                        return;
                    }
                }
                if (board.Count == board.Size * board.Size -1)
                {
                    Console.WriteLine("IT'S A DRAW. WELL PLAYED!");
                }
                ++board.Count;
            }

        }

        public bool IsValid(Board board, int position)
        {

            int row, column, size;
            size = board.Size;
            if (position <= 0 || position > size * size) return false;
            row = (position - 1) / size;
            column = (position - 1) % size;
            if (board.Cell[row][column].IsOccupied == true) return false;
            return true;
        }

        public void WriteData(int pos, Player player)
        {
            int size = this.board.Size;
            this.board.Cell[(pos - 1) / size][(pos - 1) % size].IsOccupied = true;
            this.board.Cell[(pos - 1) / size][(pos - 1) % size].Character = player.Piece;
        }

        public void Toss()
        {
            var randomArray = new List<int>();
            for (int i = 0; i < players.Count; i++)
            {
                randomArray.Add(i);
            }
            Random random = new Random();
            randomArray = randomArray.OrderBy(p => random.Next()).ToList();
            
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Order = randomArray[i];
            }
        }

        public Player IsGameOver()
        {
            int i, size = board.Size;
            var grid = board.Cell;


            for (i = 0; i < size; ++i)
            {
                if (AreAllSame(grid[i]))
                {
                    return players.Where(p => p.Piece == grid[i][0].Character).First();
                }
            }
            for (i = 0; i < size; i++)
            {
                List<Cell> cells = new List<Cell>();
                cells.AddRange(from cell in grid select cell.ElementAt(i));
                if (AreAllSame(cells))
                {
                    return players.Where(p => p.Piece == cells[0].Character).First();
                }
            }

            List<Cell> mainDiag, secDiag;
            mainDiag = new List<Cell>();
            secDiag = new List<Cell>();
            for (i = 0; i < size; i++)
            {
                mainDiag.Add(grid[i][i]);
                secDiag.Add(grid[i][size - i - 1]);
            }
            if (AreAllSame(mainDiag))
            {
                return players.Where(p => p.Piece == mainDiag[0].Character).First();
            }
            if (AreAllSame(secDiag))
            {
                return players.Where(p => p.Piece == secDiag[0].Character).First();
            }
            return null;

        }

		public bool AreAllSame(List<Cell> cells)
		{
			if (cells.All(p => p.IsOccupied == true && p.Character == cells[0].Character))
				return true;
			return false;
		}
    }
}
