using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Player: Input
    {
        public Player(List<Player> players, OutputType outputType)
        {
			writer = new Output(outputType);
            writer.Write("Enter the name of the player: ");
            this.name = Console.ReadLine().Trim();

            writer.Write("Enter the piece you want to use: ");
            this.piece = new Piece(Console.ReadLine().Trim());
            while (players.Select(p => p).Where(x => string.Compare(x.Piece.Symbol, this.piece.Symbol) == 0).Count() >= 1)
            {
                writer.Write("That piece has already been taken.\nChoose a different piece: ");
                this.piece = new Piece(Console.ReadLine().Trim());
            }

            writer.Write("Is this player HUMAN or AI: ");
            do
            {
                var playerType = Console.ReadLine().Trim();
                PlayerType humanOrNot;
                if (Enum.TryParse<PlayerType>(playerType.ToUpper(), out humanOrNot))
                {
                    this.playerType = humanOrNot;
                    break;
                }
                writer.Write("Enter a valid Player Type: [human] or [AI]: ");
                continue;
            } while (true);

            this.order = -1;
        }

        private Piece piece;
        private string name;
        private PlayerType playerType;
        private int order;
		private Output writer;

		//Properties
		public string Name
		{
			get { return name; }
		}
		public Piece Piece
		{
			get { return piece; }
		}
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
			writer.WriteLine(string.Format("It is {0}'s turn.", this.name));
            if(this.playerType == PlayerType.HUMAN)
            {
				writer.Write(string.Format("Enter position to draw {0}: ", this.piece.ToString()));
				return (new Human(writer.OutputType).Input());
            }
            else if(this.playerType == PlayerType.AI)
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
