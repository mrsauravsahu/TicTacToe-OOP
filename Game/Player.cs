using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Player: Input
    {
        public Player(List<Player> players)
        {
            Console.Clear();

            Console.Write("Enter the name of the player: ");
            this.name = Console.ReadLine().Trim();

            Console.Write("Enter the piece you want to use: ");
            this.piece = new Piece(Console.ReadLine().Trim());
            while (players.Select(p => p).Where(x => string.Compare(x.Piece.Symbol, this.piece.Symbol) == 0).Count() >= 1)
            {
                Console.Write("That piece has already been taken.\nChoose a different piece: ");
                this.piece = new Piece(Console.ReadLine().Trim());
            }

            Console.Write("Is this player HUMAN or AI: ");
            do
            {
                var playerType = Console.ReadLine().Trim();
                GameEnums.PlayerType humanOrNot;
                if (Enum.TryParse<GameEnums.PlayerType>(playerType.ToUpper(), out humanOrNot))
                {
                    this.playerType = humanOrNot;
                    break;
                }
                Console.Write("Enter a valid Player Type: [human] or [AI]: ");
                continue;
            } while (true);

            this.order = -1;
        }

        private Piece piece;
        public Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private GameEnums.PlayerType playerType;
        public GameEnums.PlayerType PlayerType
        {
            get { return playerType; }
            set { playerType = value; }
        }

        private int order;
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        public override string ToString()
        {
            return string.Format("\nPlayer Name: {0}\nPlayer Type: {1}\nAssigned Piece: {2}\nPlayer Turn: {3}",
                this.name,
                this.playerType,
                this.piece,
                this.order);
        }

        public int Input()
        {
            Console.WriteLine("It is {0}'s turn.", this.name);
            if(this.playerType == GameEnums.PlayerType.HUMAN)
            {
                Console.Write("Enter position to draw {0}: ", this.piece.ToString());
				return (new Human().Input());
            }
            else if(this.playerType == GameEnums.PlayerType.AI)
            {
				return (new AI().Input());
            }
            else
			{
				//Never going to happen
				return -1;
			}
        }
    }
}
