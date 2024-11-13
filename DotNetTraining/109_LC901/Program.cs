namespace _109_LC901
{
	public class StockItem
	{
		public int Index;
		public int Price;
	}

	public class StockSpanner
	{

		private Stack<StockItem> _stack;
		private int _index;
		public StockSpanner()
		{
			_stack = new Stack<StockItem>();
			_index = 0;
		}

		public int Next(int price)
		{
			_index++;
			int tmpIndex = _index;
			int retVal = 1;
			while (true)
			{

				if (_stack.Count == 0)
				{
					_stack.Push(new StockItem() { Index = tmpIndex, Price = price });
					return retVal;
				}

				StockItem top = _stack.Peek();
				if (top.Price > price)
				{
					_stack.Push(new StockItem() { Index = tmpIndex, Price = price });
					return retVal;
				}
				else if (top.Price == price)
				{
					retVal = 1 + _index - top.Index;
					return retVal;
				}
				else 
				{
					retVal = 1 + _index - top.Index;
					tmpIndex = top.Index;
					_stack.Pop();
				}
			}
		}
	}

	/**
	 * Your StockSpanner object will be instantiated and called as such:
	 * StockSpanner obj = new StockSpanner();
	 * int param_1 = obj.Next(price);
	 */
	internal class Program
	{
		static void Main(string[] args)
		{
			StockSpanner stockSpanner = new StockSpanner();
			Console.WriteLine(	stockSpanner.Next(100)); // return 1
			Console.WriteLine(stockSpanner.Next(80));  // return 1
			Console.WriteLine(stockSpanner.Next(60));  // return 1
			Console.WriteLine(stockSpanner.Next(70));  // return 2
			Console.WriteLine(stockSpanner.Next(60));  // return 1
			Console.WriteLine(stockSpanner.Next(75));  // return 4, because the last 4 prices (including today's price of 75) were less than or equal to today's price.
			Console.WriteLine(stockSpanner.Next(85));  // return 6
		}
	}
}
