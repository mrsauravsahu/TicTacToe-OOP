using System;

namespace TicTacToe
{
	class Output
	{
		private OutputType outputType;

		public OutputType OutputType
		{
			get { return this.outputType; }
		}
		public Output(OutputType outputType)
		{
			this.outputType = outputType;
		}
		public virtual string ReadLine()
		{
			switch (this.outputType)
			{
				case OutputType.Console:
					return ConsoleWriter.ReadLine();
				case OutputType.File:
					return FileWriter.ReadLine();
				default:
					return String.Empty;
			}
		}
		public virtual void Write<T>(T value)
		{
			switch (this.outputType)
			{
				case OutputType.Console:
					ConsoleWriter.Write<T>(value);
					return;
				case OutputType.File:
					FileWriter.Write<T>(value);
					return;
				default:
					return;
			}
		}
		public virtual void WriteLine<T>(T value)
		{
			switch (this.outputType)
			{
				case OutputType.Console:
					ConsoleWriter.WriteLine<T>(value);
					return;
				case OutputType.File:
					FileWriter.WriteLine<T>(value);
					return;
				default:
					return;
			}
		}
	}
}