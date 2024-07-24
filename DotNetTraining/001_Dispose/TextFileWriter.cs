using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Dispose
{
	public class TextFileWriter : IDisposable
	{
		private bool _disposed = false;
		private StreamWriter _streamWriter;
		private string _filePath = "textfile.txt";

		public TextFileWriter()
		{
			// Open StreamWriter when the object is initiated.
			_streamWriter = new StreamWriter(_filePath, true);
		}

		public void WriteTextToFile(string text)
		{
			_streamWriter.WriteLine(text);
		}

		public void SaveAndReopenStreamWriter()
		{
			// Close and dispose of the existing StreamWriter
			_streamWriter.Close();
			_streamWriter.Dispose();

			// Reopen StreamWriter
			_streamWriter = new StreamWriter(_filePath, true);
		}

		private void Dispose(bool disposing)
		{
			if (_disposed) 
				return;

			Console.WriteLine("Dispose() was called with param: "+disposing);
			// Close and dispose StreamWriter when the object is disposed
			_streamWriter.Close();
			_streamWriter.Dispose();

			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		~TextFileWriter()
		{
			Dispose(false);
		}
	}
}
