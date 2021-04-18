using System;

namespace Everlight.DataStructures
{
	public class TreeNode
	{
		public TreeNode(int depth)
		{
			Value = new NodeValue();
			Depth = depth;
		}

		public NodeValue Value { get; set; }

		public TreeNode Left { get; set; }
		public TreeNode Right { get; set; }

		public int Depth { get; }

		public bool IsLeave()
		{
			return (Left == null) && (Right == null);
		}

		public void FlipGate()
		{
			Value.LeftOpen = !Value.LeftOpen;
		}
	}

	public class NodeValue
	{
		public NodeValue()
		{
			LeftOpen = new Random().Next(2) == 0;
		}

		public bool LeftOpen { get; set; } // For non-leave nodes

		public long Index { get; set; } // To distinguish leave nodes
		public bool Filled { get; set; } // For leave nodes
	}
}
