using System.Diagnostics;

namespace _002_NoDisposeTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine("Waiting for key press");
			Console.ReadKey();
			Console.WriteLine("Processing");
			while (true)
			{
				stopwatch.Restart();
				for (int i = 0; i < 1000000; i++)
				{
					using(StreamReader streamReader = new StreamReader("..\\..\\..\\TestFile.txt"))
					{ }
				}
				stopwatch.Stop();
				Console.WriteLine("Time elapsed: "+ stopwatch.ToString());
				Console.WriteLine("Waiting for key press");
				Console.ReadKey();
				Console.WriteLine("Processing");
			}
		}
	}
}
