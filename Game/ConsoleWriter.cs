using System;

namespace TicTacToe
{
	static class ConsoleWriter
	{
			public static string ReadLine()
			{
				return Console.ReadLine();
			}
			public static void Write<T>(T value)
			{
				Console.Write(value.ToString());
			}
			public static void WriteLine<T>(T value)
			{
				Console.WriteLine(value.ToString());
			}
		}
	}

