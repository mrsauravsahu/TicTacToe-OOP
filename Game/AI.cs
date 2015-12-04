using System;

namespace TicTacToe
{
	class AI : Input
	{
		public int Input()
		{
			Random random = new Random();
			return random.Next(0, 9);
		}
	}
}
