using System;

namespace Everlight.DataStructures
{
	public class BinaryTree
	{
		private long leaveNodeIndex = 1;
		private int _maxDepth;

		private TreeNode _rootNode;

		public BinaryTree(int maxDepth)
		{
			if (maxDepth <= 0)
				throw new Exception("Max depth of binary tree must be greater than 0");

			Initialize(maxDepth);
		}

		/// <summary>
		/// Predict the index of unfilled node
		/// </summary>
		public long PredictUnfilled()
		{
			return PredictUnfilled(_rootNode).Value.Index;
		}

		public long RunThrough(int times)
		{
			for (var index = 0; index < times; index++)
			{
				RunThrough(_rootNode);
			}

			return FindUnfilled(_rootNode);
		}

		private void RunThrough(TreeNode node)
		{
			if (node.IsLeave())
			{
				node.Value.Filled = true;
				return;
			}

			// For non-leave nodes
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

			if (node.IsLeave())
			{
				if (!node.Value.Filled)
				{
					index = node.Value.Index;
				}

				return index;
			}

			if (index > 0)
			{
				return index;
			}

			index = FindUnfilled(node.Left);
			if (index > 0)
			{
				return index;
			}

			return FindUnfilled(node.Right);
		}

		/// <summary>
		/// Predict unfilled node
		/// </summary>
		private TreeNode PredictUnfilled(TreeNode node)
		{
			if (node.IsLeave())
			{
				return node;
			}

			if (node.Value.LeftOpen)
			{
				return PredictUnfilled(node.Right);
			}

			return PredictUnfilled(node.Left);
		}

		private void Initialize(int maxDepth)
		{
			_maxDepth = maxDepth;
			_rootNode = new TreeNode(0);

			Add(_rootNode);
		}

		private void Add(TreeNode node)
		{
			if (node.Depth < _maxDepth) // For non-leave nodes
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
			else // For leave nodes
			{
				node.Value.Index = leaveNodeIndex++;
			}
		}
	}
}
