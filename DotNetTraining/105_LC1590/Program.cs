﻿namespace _105_LC1590
{

	//public class Solution
	//{
	//	public int MinSubarray(int[] nums, int p)
	//	{
	//		long pp = p;
	//		long len = nums.Length;
	//		List<long> list = new List<long>();
	//		long sum = 0;

	//		list.Add(0);
	//		foreach (long i in nums)
	//		{
	//			sum += (i % pp);
	//			list.Add(sum);
	//		}

	//		long targetDiff = sum % pp;
	//		if (targetDiff == 0)
	//			return 0;
	//		for (int diff = 1; diff < len; diff++)
	//		{
	//			for (int i = diff; i < len+1; i++)
	//			{
	//				long difVal = list[i] - list[i - diff];
	//				if (difVal % pp == targetDiff)
	//					return diff;
	//			}
	//		}


	//		return -1;

	//	}
	//} 
	public class Solution
	{
		public int MinSubarray(int[] nums, int p)
		{
			long pp = p;
			long len = nums.Length;
			long sum = 0;
			int index = 0;
			int minLen = int.MaxValue;
			Dictionary<long, int> dict = new Dictionary<long, int>();
			dict[0] = -1;

			foreach (long i in nums)
			{
				sum += (i % pp);
			}

			long targetDiff = sum % pp;
			if (targetDiff == 0)
				return 0;

			sum = 0;
			foreach (int i in nums)
			{
				long lon = (long)i;
				sum = (lon + sum) % pp;

				if (dict.ContainsKey((pp + sum - targetDiff) % pp))
				{
					minLen = Math.Min(minLen, index - dict[(pp + sum - targetDiff) % pp]);
				}
				dict[sum] = index;

				index++;
			}

			if (minLen == int.MaxValue || minLen == len)
				return -1;
			return minLen;

		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Solution sol = new Solution();
			int p = 949467102;
			//nums = new int[] { 6, 3, 5, 2 };
			//p = 9; 
			nums = new int[] { 3, 1, 4, 2 };
			p =6 ;
			Console.WriteLine(sol.MinSubarray(nums, p));

			Console.WriteLine("Hello, World!");
		}
	}
}