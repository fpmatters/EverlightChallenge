using System;
using Everlight.DataStructures;

namespace EverlightChallenge
{
	class Program
	{
		const int MaxDepth = 8;
		static void Main(string[] args)
		{
			var tree = new BinaryTree(MaxDepth);

			var predictedIndex = tree.PredictUnfilled();

			
			var actualIndex = tree.RunThrough();

			Console.WriteLine($"Predicted index {predictedIndex} and actual index {actualIndex} should be same.");
		}
	}
}
