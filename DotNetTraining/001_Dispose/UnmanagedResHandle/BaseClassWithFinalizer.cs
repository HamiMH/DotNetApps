using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Dispose.UnmanagedResHandle
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
    /// </summary>
    internal class BaseClassWithFinalizer
    {
        private bool _disposedValue;

        ~BaseClassWithFinalizer() => Dispose(false);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }
    }
}
