using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
