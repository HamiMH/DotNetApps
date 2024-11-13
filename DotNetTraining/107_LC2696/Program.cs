using System.Runtime.Intrinsics.Arm;

namespace _107_LC2696
{
	internal class Program
	{
		public class Solution
		{

			public int MinLength(string s)
			{
				Stack<char> stack = new Stack<char>();
				char top;
				int rem = 0;
				foreach (char c in s)
				{
					if(stack.Count==0)
					{
						stack.Push(c);
					}
					else
					{
						top = stack.Peek();
						if ((top == 'A' && c=='B')|| (top == 'C' && c == 'D'))
						{
							stack.Pop();
							rem += 2;
						}
						else
						{
							stack.Push(c);
						}
					}
				}
				return s.Length-rem;
			}
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}
	}
}
