namespace _106_CelScratch
{

	internal class Program
	{
		Dictionary<int, int> _dict = new Dictionary<int, int>()
		{
			{ 6, 1680 }, { 7, 84 }, { 8, 630 }, { 9, 280 },
			{ 10, 42 }, { 11, 34 }, { 12, 180 }, { 13, 120 },
			{ 14, 53 }, { 15, 105 }, { 16, 53 }, { 17, 144 },
			{ 18, 48 }, { 19, 202 }, { 20, 105 }, { 21, 51 },
			{ 22, 420 }, { 23, 840 }, { 24, 1008 }
		};

		int TeoVal(int currVal,int remainNum,	List<int> remain)
		{
			if (remainNum == 0)
			{
				return _dict[currVal];
			}

			return 0;
		}
		static void Main(string[] args)
		{
			string line=Console.ReadLine();
			string[] arr = line.Split(' ');
			List<int> list = new List<int>();
			foreach(string s in arr)
			{
				list.Add(int.Parse(s));
			}
			List<int> remain= new List<int>();
			for(int i = 1;i<9; i++)
			{
				if (!list.Contains(i))
				{
					remain.Add(i);
				}
			}


		}
	}
}
