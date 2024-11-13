namespace _103_LC84
{
	//public class Solution
	//{
	//	private const uint MAXH = 10000;
	//	private uint[] _MEMO = new uint[MAXH + 1];

	//	public int LargestRectangleArea(int[] heights)
	//	{
	//		int maxArea = 0;
	//		foreach (uint i in _MEMO)
	//		{
	//			_MEMO[i] = 0;
	//		}

	//		foreach (int heiI in heights)
	//		{
	//			uint hei = (uint)heiI;
	//			for (uint i = 1; i <= hei; i++)
	//			{
	//				_MEMO[i]++;
	//				if (_MEMO[i] * i > maxArea)
	//					maxArea = (int)(_MEMO[i] * i);
	//			}
	//			for (uint i = hei + 1; i < MAXH; i++)
	//			{
	//				if (_MEMO[i] == 0)
	//					break;
	//				_MEMO[i] = 0;
	//			}
	//		}

	//		return maxArea;
	//	}
	//}

	public struct Bar
	{
		public Bar(uint h, uint i)
		{
			height = h;
			index = i;
		}
		public uint height;
		public uint index;
	}
	public class Solution
	{
		public int LargestRectangleArea(int[] heights)
		{
			uint maxArea = 0;
			Stack<Bar> barStack = new Stack<Bar>();
			uint index;
			for (index = 0; index < heights.Length; index++)
			{
				int height = heights[index];
				uint indexItem = index;
				while (barStack.Count > 0 && barStack.Peek().height > height)
				{
					Bar topBar = barStack.Pop();
					uint area = topBar.height * (index - topBar.index);
					if (topBar.index<indexItem)
						indexItem = topBar.index;
					if (area > maxArea)
						maxArea = area;
				}
				Bar bar = new Bar((uint)heights[index], indexItem);
					barStack.Push(bar);
			}
			while (barStack.Count > 0)
			{
				Bar topBar = barStack.Pop();
				uint area = topBar.height * (index - topBar.index);
				if (area > maxArea)
					maxArea = area;
			}

			return (int)maxArea;
		}
	}


	internal class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();
			//int[] heights = new int[] { 2, 1, 5, 6, 2, 3 };
			int[] heights = new int[] { 2, 1, 2 };
			int maxArea = solution.LargestRectangleArea(heights);
			Console.WriteLine("Hello, World!");
		}
	}
}
