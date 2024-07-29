using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Dispose
{
	internal class DisposablePattern : IDisposable
	{
		private List<int> _managedResource;
		private StreamReader _unmanagedResource;
		private bool _disposed = false;

		public DisposablePattern()
		{
			_managedResource = new List<int>();
			_unmanagedResource = new StreamReader("file name");

		}

		public void Dispose()
		{
			Dispose(true);
		}

		~DisposablePattern() { Dispose(false); }

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed) return;

			if (disposing)
			{
				_managedResource = null;
			}
			_unmanagedResource.Dispose();

			_disposed = true;
		}

	}
}
