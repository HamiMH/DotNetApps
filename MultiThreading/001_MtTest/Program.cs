
namespace _001_MtTest
{
	internal class Program
	{
		private static object _lock = new object();
		static void Main(string[] args)
		{
			for (int i = 0; i < 5; i++)
			{
				new Thread(ParalelMonitor).Start();
			}

			Console.ReadKey();
		}

		private static void ParalelLock()
		{
			lock (_lock)
			{
				try
				{
					Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": First text!");
					Thread.Sleep(1000);
					Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": Second text!");
					throw new Exception();
				}
				catch
				{
					Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": In catch!");

				}

			}
		}
		private static void ParalelMonitor()
		{
			Monitor.Enter(_lock);

			try
			{
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": First text!");
				Thread.Sleep(1000);
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": Second text!");
				throw new Exception();
			}
			catch
			{

				Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": In catch!");
				return;
			}
			finally { Monitor.Exit(_lock); }
		}
	}
}
