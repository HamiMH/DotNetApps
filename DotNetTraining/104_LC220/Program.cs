namespace _104_LC220
{
	public class AVLTreeNode<T> where T : IComparable<T>
	{
		public T Value { get; set; }
		public AVLTreeNode<T> Left { get; set; }
		public AVLTreeNode<T> Right { get; set; }
		public int Height { get; set; }

		public AVLTreeNode(T value)
		{
			Value = value;
			Height = 1;
		}
	}

	public class AVLTree<T> where T : struct, IComparable<T>
	{
		private AVLTreeNode<T> _root;

		public void Insert(T value)
		{
			_root = Insert(_root, value);
		}

		private AVLTreeNode<T> Insert(AVLTreeNode<T> node, T value)
		{
			if (node == null)
				return new AVLTreeNode<T>(value);

			int compare = value.CompareTo(node.Value);
			if (compare < 0)
				node.Left = Insert(node.Left, value);
			else if (compare > 0)
				node.Right = Insert(node.Right, value);
			else
				return node; // Duplicate values are not allowed

			node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

			int balance = GetBalance(node);

			// Left Left Case
			if (balance > 1 && value.CompareTo(node.Left.Value) < 0)
				return RightRotate(node);

			// Right Right Case
			if (balance < -1 && value.CompareTo(node.Right.Value) > 0)
				return LeftRotate(node);

			// Left Right Case
			if (balance > 1 && value.CompareTo(node.Left.Value) > 0)
			{
				node.Left = LeftRotate(node.Left);
				return RightRotate(node);
			}

			// Right Left Case
			if (balance < -1 && value.CompareTo(node.Right.Value) < 0)
			{
				node.Right = RightRotate(node.Right);
				return LeftRotate(node);
			}

			return node;
		}

		public void Remove(T value)
		{
			_root = Remove(_root, value);
		}

		private AVLTreeNode<T> Remove(AVLTreeNode<T> node, T value)
		{
			if (node == null)
				return node;

			int compare = value.CompareTo(node.Value);
			if (compare < 0)
				node.Left = Remove(node.Left, value);
			else if (compare > 0)
				node.Right = Remove(node.Right, value);
			else
			{
				if ((node.Left == null) || (node.Right == null))
				{
					AVLTreeNode<T> temp = node.Left ?? node.Right;

					if (temp == null)
					{
						temp = node;
						node = null;
					}
					else
						node = temp;
				}
				else
				{
					AVLTreeNode<T> temp = GetMinValueNode(node.Right);
					node.Value = temp.Value;
					node.Right = Remove(node.Right, temp.Value);
				}
			}

			if (node == null)
				return node;

			node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

			int balance = GetBalance(node);

			// Left Left Case
			if (balance > 1 && GetBalance(node.Left) >= 0)
				return RightRotate(node);

			// Left Right Case
			if (balance > 1 && GetBalance(node.Left) < 0)
			{
				node.Left = LeftRotate(node.Left);
				return RightRotate(node);
			}

			// Right Right Case
			if (balance < -1 && GetBalance(node.Right) <= 0)
				return LeftRotate(node);

			// Right Left Case
			if (balance < -1 && GetBalance(node.Right) > 0)
			{
				node.Right = RightRotate(node.Right);
				return LeftRotate(node);
			}

			return node;
		}
		private AVLTreeNode<T> GetMinValueNode(AVLTreeNode<T> node)
		{
			AVLTreeNode<T> current = node;
			while (current.Left != null)
				current = current.Left;

			return current;
		}
		private int GetHeight(AVLTreeNode<T> node)
		{
			return node?.Height ?? 0;
		}

		private int GetBalance(AVLTreeNode<T> node)
		{
			return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
		}

		private AVLTreeNode<T> RightRotate(AVLTreeNode<T> y)
		{
			AVLTreeNode<T> x = y.Left;
			AVLTreeNode<T> T2 = x.Right;

			x.Right = y;
			y.Left = T2;

			y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
			x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

			return x;
		}

		private AVLTreeNode<T> LeftRotate(AVLTreeNode<T> x)
		{
			AVLTreeNode<T> y = x.Right;
			AVLTreeNode<T> T2 = y.Left;

			y.Left = x;
			x.Right = T2;

			x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
			y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

			return y;
		}

		public void InOrderTraversal()
		{
			InOrderTraversal(_root);
		}

		private void InOrderTraversal(AVLTreeNode<T> node)
		{
			if (node != null)
			{
				InOrderTraversal(node.Left);
				Console.WriteLine(node.Value);
				InOrderTraversal(node.Right);
			}
		}

		// Contains method to check if a value exists in the tree
		public bool Contains(T value)
		{
			return Contains(_root, value);
		}

		private bool Contains(AVLTreeNode<T> node, T value)
		{
			if (node == null)
				return false;

			int compare = value.CompareTo(node.Value);
			if (compare < 0)
				return Contains(node.Left, value);
			else if (compare > 0)
				return Contains(node.Right, value);
			else
				return true; // Found the value
		}

		// GetClosestLower method to find the closest lower value to the given value
		public T? GetClosestLower(T value)
		{
			if (_root == null)
				return null;

			return GetClosestLower(_root, value, null, false);
		}

		private T? GetClosestLower(AVLTreeNode<T> node, T value, T? closest, bool found)
		{
			if (node == null)
				return closest;

			int compare = value.CompareTo(node.Value);
			if (compare > 0)
			{
				closest = node.Value;
				found = true;
				return GetClosestLower(node.Right, value, closest, found);
			}
			else
			{
				return GetClosestLower(node.Left, value, closest, found);
			}
		}

		// GetClosestHigher method to find the closest higher value to the given value
		public T? GetClosestHigher(T value)
		{
			if (_root == null)
				return null;

			return GetClosestHigher(_root, value, null, false);
		}

		private T? GetClosestHigher(AVLTreeNode<T> node, T value, T? closest, bool found)
		{
			if (node == null)
				return closest;

			int compare = value.CompareTo(node.Value);
			if (compare < 0)
			{
				closest = node.Value;
				found = true;
				return GetClosestHigher(node.Left, value, closest, found);
			}
			else
			{
				return GetClosestHigher(node.Right, value, closest, found);
			}
		}
	}



	public class NumberOfItem<T>
	{
		private Dictionary<T, int> _dict = new Dictionary<T, int>();

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


	public class Solution
	{
		public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
		{
			NumberOfItem<int> numDict = new NumberOfItem<int>();
			Queue<int> numQueue = new Queue<int>();
			AVLTree<int> avlTree = new AVLTree<int>();


			int iter = 1;
			foreach (int i in nums)
			{
				if (avlTree.Contains(i))
					return true;
				int? closestLower = avlTree.GetClosestLower(i);
				if (closestLower != null)
					if (Math.Abs((int)closestLower - i) <= valueDiff)
						return true;
				int? closestHigher = avlTree.GetClosestHigher(i);
				if (closestHigher != null)
					if (Math.Abs((int)closestHigher - i) <= valueDiff)
						return true;


				if (numDict.Count(i) == 0)
					avlTree.Insert(i);
				numDict.Add(i);
				numQueue.Enqueue(i);
				if (iter >  indexDiff)
				{
					int itemToRemove = numQueue.Dequeue();
					numDict.Remove(itemToRemove);

					if (numDict.Count(itemToRemove) == 0)
						avlTree.Remove(itemToRemove);
				}
				iter++;
			}

			return false;
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Solution s = new Solution();

			int[] nums = new int[] { 1, 2, 3, 1 };
			int k = 3;
			int t = 0;
			Console.WriteLine(s.ContainsNearbyAlmostDuplicate(nums, k, t)); // Output: true

			nums = new int[] { 1, 0, 1, 1 };
			k = 1;
			t = 2;
			Console.WriteLine(s.ContainsNearbyAlmostDuplicate(nums, k, t)); // Output: true

			nums = new int[] { 1, 5, 9, 1, 5, 9 };
			k = 2;
			t = 3;
			Console.WriteLine(s.ContainsNearbyAlmostDuplicate(nums, k, t)); // Output: false





			AVLTree<int> avlTree = new AVLTree<int>();
			avlTree.Insert(10);
			avlTree.Insert(20);
			avlTree.Insert(30);
			avlTree.Insert(40);
			avlTree.Insert(50);
			avlTree.Insert(25);

			Console.WriteLine("In-order traversal of the constructed AVL tree is:");
			avlTree.InOrderTraversal();

			// Check if elements are in the tree
			Console.WriteLine("Contains 20: " + avlTree.Contains(20)); // Output: True
			Console.WriteLine("Contains 15: " + avlTree.Contains(15)); // Output: False

			// Get closest lower and higher elements
			Console.WriteLine("Closest lower to 20: " + avlTree.GetClosestLower(20));
			Console.WriteLine("Closest lower to 22: " + avlTree.GetClosestLower(22)); // Output: 20
			Console.WriteLine("Closest higher to 22: " + avlTree.GetClosestHigher(22)); // Output: 25
			Console.WriteLine("Closest lower to 35: " + avlTree.GetClosestLower(35)); // Output: 30
			Console.WriteLine("Closest higher to 35: " + avlTree.GetClosestHigher(35)); // Output: 40

			avlTree.Remove(20);
			Console.WriteLine("Closest lower to 22: " + avlTree.GetClosestLower(22)); // Output: 20

		}
	}
}
