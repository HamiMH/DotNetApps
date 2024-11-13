namespace _102_LC219
{

	public class Solution
	{
		public bool ContainsNearbyDuplicate(int[] nums, int k)
		{
			NumberOfItem<int> numDict = new NumberOfItem<int>();
			Queue<int> numQueue = new Queue<int>();

			int iter = i;
			foreach (int i in nums)
			{
				if (numDict.Count(i) > 0)
					return true;

				numDict.Add(i);
				numQueue.Enqueue(i);
				iter++;
				if (iter > k)
				{
					numDict.Remove(numQueue.Dequeue());
				}
			}

			return false;
		}
	}


	public class NumberOfItem<T> 
	{
		private Dictionary<T, int> _dict=new Dictionary<T, int>();

		public void Add(T item)
		{
			if (_dict.ContainsKey(item))
			{
				_dict[item]++;
			}
			else
			{
				_dict[item] = 1;
			}
		}
		public void Remove(T item)
		{
			if (_dict.ContainsKey(item))
			{
				if (_dict[item] > 0)
					_dict[item]--;
			}
		}
		public int Count(T item)
		{
			if (_dict.ContainsKey(item))
			{
				return _dict[item];
			}
			return 0;
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			SortedSet<int> sortedSet = new SortedSet<int>();
		}
	}
}
