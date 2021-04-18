using Everlight.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Everlight.UnitTests
{
	[TestClass]
	public class BinaryTreeTests
	{
		[TestMethod]
		public void Should_be_able_to_predict_unfilled_node()
		{
			// Arrange
			var tree = new BinaryTree(3);
			var root = tree.GetRoot();

			root.Value.LeftOpen = false;
			root.Left.Value.LeftOpen = false;
			root.Left.Left.Value.LeftOpen = true;

			// Act
			var index = tree.PredictUnfilled();

			// Assert
			Assert.AreEqual(2, index);
		}

		[TestMethod]
		public void Should_be_able_to_return_unfilled_node_after_running_through_binary_tree()
		{
			// Arrange
			var tree = new BinaryTree(3);
			var root = tree.GetRoot();

			root.Value.LeftOpen = true;
			root.Right.Value.LeftOpen = false;
			root.Right.Left.Value.LeftOpen = true;

			// Act
			var index = tree.PredictUnfilled();

			// Assert
			Assert.AreEqual(6, index);
		}

		[TestMethod]
		public void Prediction_and_running_through_should_return_the_same_result()
		{
			// Arrange
			var tree = new BinaryTree(3);
			var root = tree.GetRoot();

			root.Value.LeftOpen = true;
			root.Right.Value.LeftOpen = true;
			root.Right.Right.Value.LeftOpen = true;

			// Act
			var predicted = tree.PredictUnfilled();
			var runThrough = tree.RunThrough();

			// Assert
			Assert.AreEqual(predicted, runThrough);
		}
	}
}
