namespace _004_InheritanceFinalizer
{
	class First
	{
		~First()
		{
			Console.WriteLine("First's finalizer is called.");
		}
	}

	class Second : First
	{
		~Second()
		{
			Console.WriteLine("Second's finalizer is called.");
		}
	}

	class Third : Second
	{
		~Third()
		{
			Console.WriteLine("Third's finalizer is called.");
		}
	}
	abstract class A : IDisposable
	{
		//public void Dispose()
		//{
		//	Console.WriteLine("Dispose A");
		//}
		public abstract void Dispose();
	}

	class B :A 
	{
		public override void Dispose()
		{
			Console.WriteLine("Dispose B");
		}
	}

	class C:B
	{
		public override void Dispose()
		{
			base.Dispose();
			Console.WriteLine("Dispose C");
		}
	}
	internal class Program
	{
		static void Create()
		{
			Third third = new Third();
		}

		static void Main(string[] args)
		{
			using(C a = new C())
			{ }
			C b = new C();
			b.Dispose();

			Create();
			Console.WriteLine("Created");
			while (true)
			{
				List<int> list = new List<int>(1000);
			}
		}
	}
}
