using System;

namespace EverlightChallenge
{
	class Program
	{
		const int MaxDepth = 8;
		static void Main(string[] args)
		{
			var tree = new BinaryTree(MaxDepth);

			var predictedIndex = tree.PredictUnfilled();

			var leaveCount = (int)Math.Pow(2, MaxDepth);
			var actualIndex = tree.RunThrough(leaveCount - 1);

			Console.WriteLine($"Predicted index {predictedIndex} and actual index {actualIndex}");
		}
	}
}
