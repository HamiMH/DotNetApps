namespace _001_Dispose
{
	/// <summary>
	/// https://www.bytehide.com/blog/idisposable-method-csharp
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			WriteText();
			Console.WriteLine("Read key 2");
			Console.ReadKey();
			GC.Collect();
			Console.WriteLine("Read key 3");
			Console.ReadKey();


		}

		static void WriteTextUsing()
		{
			using (TextFileWriter writer = new TextFileWriter())
			{
				writer.WriteTextToFile("First text\n");
				writer.WriteTextToFile("Second text\n");
				Console.WriteLine("Read key 1");
				Console.ReadKey();
				writer.SaveAndReopenStreamWriter();
				writer.WriteTextToFile("Third text\n");
				Console.WriteLine("End of WriteText");
				Console.ReadKey();
			}
		}
		static void WriteText()
		{
			TextFileWriter writer = new TextFileWriter();
			writer.WriteTextToFile("First text\n");
			writer.WriteTextToFile("Second text\n");
			Console.WriteLine("Read key 1");
			Console.ReadKey();
			writer.SaveAndReopenStreamWriter();
			writer.WriteTextToFile("Third text\n");
			Console.WriteLine("End of WriteText");
			Console.ReadKey();
			//writer.Dispose();
			//writer.WriteTextToFile("Fourth text\n"); Cause error
		}
	}
}
