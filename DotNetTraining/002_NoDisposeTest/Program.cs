using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

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
			int iter = 0;
			while (true)
			{
				stopwatch.Restart();
				for (int i = 0; i < 1000000; i++)
				{
					using var fileStream = new FileStream("file"+iter+","+i, FileMode.Create);
					var bytes = Encoding.UTF8.GetBytes( "fileinput") ;
					fileStream.Write(bytes, 0, bytes.Length);
				}
				stopwatch.Stop();
				Console.WriteLine("Time elapsed: " + stopwatch.ToString());
				Console.WriteLine("Waiting for key press");
				Console.ReadKey();
				Console.WriteLine("Processing");
				iter++;
			}
		}
		static void Main2(string[] args)
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
					using (StreamReader streamReader = new StreamReader("..\\..\\..\\TestFile.txt"))
					{ }
				}
				stopwatch.Stop();
				Console.WriteLine("Time elapsed: " + stopwatch.ToString());
				Console.WriteLine("Waiting for key press");
				Console.ReadKey();
				Console.WriteLine("Processing");
			}
		}
	}
}
