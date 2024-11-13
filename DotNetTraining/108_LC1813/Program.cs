namespace _108_LC1813
{
	public class Solution
	{
		private bool IsSimilar(string[] fir, string[] sec)
		{
			int i = 0;
			int j = 0;
			bool found;
			bool match = true;
			int swit = 0;
			for (; i < fir.Length; i++)
			{
				found = false;
				for (; j < sec.Length; j++)
				{
					if (fir[i] == sec[j])
					{
						if (!match)
						{
							match = true;
							swit++;
						}
						found = true;
						j++;
						break;
					}
					else
					{
						if (match)
						{
							match = false;
							swit++;
						}
					}
				}
				if (!found)
				{
					return false;
				}
			}

			if (fir.Last() != sec.Last())
			{
				swit++;
			}
			if (swit > 2)
			{
				return false;
			}
			return true;
			}

			public bool AreSentencesSimilar(string sentence1, string sentence2)
			{
				string[] arr1 = sentence1.Split(' ');
				string[] arr2 = sentence2.Split(' ');


				return IsSimilar(arr1, arr2) || IsSimilar(arr2, arr1);
			}
		}
		internal class Program
		{
			static void Main(string[] args)
			{
			string sentence1 = "Ogn WtWj HneS";
			string sentence2 = "Ogn WtWj HneS";
			Solution sol = new Solution();
			Console.WriteLine(sol.AreSentencesSimilar(sentence1, sentence2));
			Console.WriteLine("Hello, World!");
			}
		}
	}
