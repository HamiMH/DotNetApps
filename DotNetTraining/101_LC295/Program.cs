namespace _101_LC295
{
	public class MedianFinder
	{
		private PriorityQueue<int, int> _lowPq;
		private PriorityQueue<int, int> _highPq;

		public MedianFinder()
		{
			_lowPq = new PriorityQueue<int, int>();
			_highPq = new PriorityQueue<int, int>();
		}

		public void AddNum(int num)
		{
			if (_lowPq.Count == 0)
			{
				_lowPq.Enqueue(num, -num);
				return;
			}
			if (_highPq.Count == 0)
			{
				if (num <= _lowPq.Peek())
				{
					int temp = _lowPq.Dequeue();

					_highPq.Enqueue(temp, temp);
					_lowPq.Enqueue(num, -num);
				}
				else
				{
					_highPq.Enqueue(num, num);
				}
				return;
			}

			if (num <= _lowPq.Peek())
			{
				_lowPq.Enqueue(num, -num);
			}
			else
			{
				_highPq.Enqueue(num, num);
			}

			if (_lowPq.Count > _highPq.Count + 1)
			{
				int temp = _lowPq.Dequeue();
				_highPq.Enqueue(temp, temp);
			}
			else if (_highPq.Count > _lowPq.Count + 1)
			{
				int temp = _highPq.Dequeue();
				_lowPq.Enqueue(temp, -temp);
			}


		}

		public double FindMedian()
		{
			if (_lowPq.Count == _highPq.Count)
			{
				return (_lowPq.Peek() + _highPq.Peek()) / 2.0;
			}
			else if (_lowPq.Count > _highPq.Count)
			{
				return _lowPq.Peek();
			}
			else
			{
				return _highPq.Peek();
			}
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			MedianFinder medianFinder = new MedianFinder();
		medianFinder.AddNum(-1);    // arr = [1]
			medianFinder.AddNum(-2);    // arr = [1, 2]
			Console.WriteLine(medianFinder.FindMedian()); // return 1.5 (i.e., (1 + 2) / 2)
			medianFinder.AddNum(-3);    // arr[1, 2, 3]
			Console.WriteLine(medianFinder.FindMedian()); // return 2.0		}
		}
	}
}
