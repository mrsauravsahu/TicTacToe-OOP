using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
	class Human : Input
	{
		public int Input()
		{
			int position;
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out position))
				{
					return position;
				}
				Console.Write("Please enter a valid input. Try again: ");
			}
		}
	}
}
