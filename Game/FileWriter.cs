using System.IO;

namespace TicTacToe
{
	class FileWriter
	{
		private const string filePath = "output.txt";
		
		public static void ClearFile()
		{
			if(File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}
		public static string ReadLine()
		{
			string value = System.Console.ReadLine();
			writeToFile(value);
			return value;
		}
		public static void Write<T>(T value)
		{
			System.Console.Write(value.ToString());
			writeToFile<T>(value);
		}
		public static void WriteLine<T>(T value)
		{
			System.Console.WriteLine(value.ToString());
			writeToFile<T>(value);
			writeToFile<string>("\n");
		}
		private static void writeToFile<T>(T value)
		{
			var writer = new StreamWriter(new FileStream(filePath, FileMode.Append, FileAccess.Write));
			writer.Write(value.ToString());
			writer.Close();
		}
	}
}
