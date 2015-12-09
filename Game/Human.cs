using System;

namespace TicTacToe
{
	class Human : Input
	{
		Output writer;
		public Human(OutputType outputType)
		{
			writer = new Output(outputType);
		}
		public int Input()
		{
			int position;
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out position))
				{
					return position;
				}
				writer.Write("Please enter a valid input. Try again: ");
			}
		}
	}
}
