namespace _100_LC703
{

	//public class KthLargest
	//{
	//	private List<int> _list;
	//	private int _k;

	//	Comparer<int> _comparer = Comparer<int>.Create((a, b) => b.CompareTo(a));	

	//	public KthLargest(int k, int[] nums)
	//	{
	//		_list=nums.ToList();
	//		_list.Sort(_comparer);
	//		_k=k;
	//	}

	//	public int Add(int val)
	//	{
	//		int index = _list.BinarySearch(val, _comparer);
	//		if (index < 0)
	//		{
	//			index = ~index;
	//		}
	//		_list.Insert(index, val);
	//		if (_list.Count > _k)
	//		{
	//			_list.RemoveAt(_list.Count - 1);
	//		}
	//		return _list[_k-1];
	//	}
	//} 
	public class KthLargest
	{
		private int[] _arr;
		private int _k;

		public KthLargest(int k, int[] nums)
		{
			_arr = new int[k];
			_k = k;
			Array.Sort(nums);
			int n = nums.Length;
			while (k > 0)
			{
				n--;
				k--;
				if (n < 0)
					_arr[k] = int.MinValue;
				else
					_arr[k] = nums[n];
			}
		}

		public int Add(int val)
		{
			if (val <= _arr.First())
			{
				return _arr.First();
			}
			int index = Array.BinarySearch(_arr, val);
			if (index < 0)
			{
				index = ~index;
			}
			index--;
			for (int i = 0; i < index; i++)
			{
				_arr[i] = _arr[i + 1];
			}
			_arr[index] = val; 
			return _arr.First();
		}
	} 
	public class KthLargestPq
	{
		private PriorityQueue<int,int> _pq;
		private int _k;

		private void AddElement(int val)
		{
			_pq.Enqueue(val,val);
			if(_pq.Count >_k)
				_pq.Dequeue();

		}
		public KthLargestPq(int k, int[] nums)
		{
			_pq = new PriorityQueue<int, int>();
			_k = k;
			foreach (var num in nums)
			{
				AddElement(num);
			}
		}

		public int Add(int val)
		{
			AddElement(val);
			return _pq.Peek();
		}
	}

	/**
	 * Your KthLargest object will be instantiated and called as such:
	 * KthLargest obj = new KthLargest(k, nums);
	 * int param_1 = obj.Add(val);
	 */

	internal class Program
	{
		static void Main(string[] args)
		{
			KthLargestPq kthLargest = new KthLargestPq(3, [4, 5, 8, 2]);
			Console.WriteLine(kthLargest.Add(3)); // return 4
			Console.WriteLine(kthLargest.Add(5)); // return 5
			Console.WriteLine(kthLargest.Add(10)); // return 5
			Console.WriteLine(kthLargest.Add(9)); // return 8
			Console.WriteLine(kthLargest.Add(4)); // return 8
			//Console.WriteLine("Hello, World!");
			////[[1, []],[-3],[-2],[-4],[0],[4]]
			//KthLargest kthLargest = new KthLargest(1, []);
			//Console.WriteLine(kthLargest.Add(-3)); // return 4
			//Console.WriteLine(kthLargest.Add(-2)); // return 5
			//Console.WriteLine(kthLargest.Add(-4)); // return 5
			//Console.WriteLine(kthLargest.Add(0)); // return 8
			//Console.WriteLine(kthLargest.Add(4)); // return 8
			//Console.WriteLine("Hello, World!");
		}
	}
}
