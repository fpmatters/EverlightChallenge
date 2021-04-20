using System;

namespace Everlight.DataStructures
{
	public class BinaryTree
	{
		private long _leafNodeIndex = 1;
		private int _maxDepth;

		private TreeNode _rootNode;

		public BinaryTree(int maxDepth)
		{
			if (maxDepth <= 0)
				throw new Exception("Max depth of a binary tree must be greater than 0");

			Initialize(maxDepth);
		}

		public TreeNode GetRoot()
		{
			return _rootNode;
		}

		/// <summary>
		/// Predict the index of unfilled node
		/// </summary>
		public long PredictUnfilled()
		{
			var unfilledNode = PredictUnfilled(_rootNode);
			return unfilledNode.Value.Index;
		}

		public long RunThrough()
		{
			var leafCount = (int)Math.Pow(2, _maxDepth);

			for (var index = 0; index < leafCount - 1; index++)
			{
				RunThrough(_rootNode);
			}

			return FindUnfilled(_rootNode);
		}

		private void RunThrough(TreeNode node)
		{
			if (node.IsLeaf())
			{
				node.Value.Filled = true;
				return;
			}

			// For non-leaf nodes
			if (node.Value.LeftOpen)
			{
				node.FlipGate();
				RunThrough(node.Left);
			}
			else
			{
				node.FlipGate();
				RunThrough(node.Right);
			}
		}

		private long FindUnfilled(TreeNode node)
		{
			var index = -1L;

			// Stop searching further if current node is at leaf level
			if (node.IsLeaf())
			{
				if (!node.Value.Filled)
				{
					index = node.Value.Index;
				}

				return index;
			}

			// Search the left child of current node recursively for unfilled node
			index = FindUnfilled(node.Left);
			if (index > 0)
			{
				return index;
			}

			// Search the right child of current node recursively
			return FindUnfilled(node.Right);
		}

		/// <summary>
		/// Predict unfilled node
		/// </summary>
		private TreeNode PredictUnfilled(TreeNode node)
		{
			if (node.IsLeaf())
			{
				return node;
			}

			if (node.Value.LeftOpen)
			{
				// There will be one moe ball going left, hence unfilled node will be in right branch
				return PredictUnfilled(node.Right);
			}

			return PredictUnfilled(node.Left);
		}

		/// <summary>
		/// Create a full binary tree recursively
		/// </summary>
		private void Initialize(int maxDepth)
		{
			_maxDepth = maxDepth;
			_rootNode = new TreeNode(0);

			Add(_rootNode);
		}

		private void Add(TreeNode node)
		{
			if (node.Depth < _maxDepth) // For non-leaf nodes
			{
				if (node.Left == null)
				{
					node.Left = new TreeNode(node.Depth + 1);
				}

				if (node.Right == null)
				{
					node.Right = new TreeNode(node.Depth + 1);
				}

				Add(node.Left);
				Add(node.Right);
			}
			else // For leaf nodes
			{
				node.Value.Index = _leafNodeIndex++;
			}
		}
	}
}
