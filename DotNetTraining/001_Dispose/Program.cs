using static _001_Dispose.UnmanagedFileHandle.SafeHandleDemo;

namespace _001_Dispose
{
	/// <summary>
	/// https://www.bytehide.com/blog/idisposable-method-csharp
	/// </summary>
	internal class Program
	{

		private static bool _printToConsole = false;
		private static bool _workerStarted = false;

		private static void Usage()
		{
			Console.WriteLine("Usage:");
			// Assumes that application is named HexViewer"
			Console.WriteLine("HexViewer <fileName> [-fault]");
			Console.WriteLine(" -fault Runs hex viewer repeatedly, injecting faults.");
		}

		private static void ViewInHex(Object fileName)
		{
			_workerStarted = true;
			byte[] bytes;
			using (MyFileReader reader = new MyFileReader((String)fileName))
			{
				bytes = reader.ReadContents(20);
			}  // Using block calls Dispose() for us here.

			if (_printToConsole)
			{
				// Print up to 20 bytes.
				int printNBytes = Math.Min(20, bytes.Length);
				Console.WriteLine("First {0} bytes of {1} in hex", printNBytes, fileName);
				for (int i = 0; i < printNBytes; i++)
					Console.Write("{0:x} ", bytes[i]);
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
		
			String fileName = "textfile.txt";
			bool injectFaultMode = args.Length > 1;
			if (!injectFaultMode)
			{
				_printToConsole = true;
				ViewInHex(fileName);
			}
			else
			{
				Console.WriteLine("Injecting faults - watch handle count in perfmon (press Ctrl-C when done)");
				int numIterations = 0;
				while (true)
				{
					_workerStarted = false;
					Thread t = new Thread(new ParameterizedThreadStart(ViewInHex));
					t.Start(fileName);
					Thread.Sleep(1);
					while (!_workerStarted)
					{
						Thread.Sleep(0);
					}
					t.Abort();  // Normal applications should not do this.
					numIterations++;
					if (numIterations % 10 == 0)
						GC.Collect();
					if (numIterations % 10000 == 0)
						Console.WriteLine(numIterations);
				}
			}
		}


		static void Main2(string[] args)
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
