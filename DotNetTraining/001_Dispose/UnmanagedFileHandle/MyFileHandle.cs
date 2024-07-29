using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _001_Dispose.UnmanagedFileHandle
{
	//internal class MyFileHandle : SafeHandleZeroOrMinusOneIsInvalid
	//{
	//	public MyFileHandle() : base(true)
	//	{
	//	}

	//	protected override bool ReleaseHandle()
	//	{
	//		throw new NotImplementedException();
	//	}

	//	internal const int GENERIC_READ = unchecked((int)0x80000000);

	//	// Allocate a file object in the kernel, then return a handle to it.
	//	[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
	//	internal extern static MySafeFileHandle CreateFile(String fileName,
	//	   int dwDesiredAccess, System.IO.FileShare dwShareMode,
	//	   IntPtr securityAttrs_MustBeZero, System.IO.FileMode dwCreationDisposition,
	//	   int dwFlagsAndAttributes, IntPtr hTemplateFile_MustBeZero);

	//	// Use the file handle.
	//	[DllImport("kernel32", SetLastError = true)]
	//	internal extern static int ReadFile(MySafeFileHandle handle, byte[] bytes,
	//	   int numBytesToRead, out int numBytesRead, IntPtr overlapped_MustBeZero);

	//	// Free the kernel's file object (close the file).
	//	[DllImport("kernel32", SetLastError = true)]
	//	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	//	internal extern static bool CloseHandle(IntPtr handle);
	//}
}
