using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Dispose.DisposePatterTest
{
	internal class DisPatt01 : IDisposable
	{
		private bool _isDisposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (_isDisposed)
				return;

			if(disposing)
			{
				// Dispose managed resources
			}

			// Dispose unmanaged resources


			_isDisposed = true;

		}

		public void Dispose()
		{
			Dispose(true);
		}

		~DisPatt01()
		{
			Dispose(false);
			GC.SuppressFinalize(this);
		}
	}
}
