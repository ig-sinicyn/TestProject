using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestProject.Tests
{
	class TestTasks
	{
		[Test]
		public static void TestTask1()
		{
			var list = Enumerable.Range(1, 12).ToArray();
			var myList = new LinkedList<int>(list);

			myList.ReverseInplace();

			Assert.AreEqual(list.Reverse().ToArray(), myList);
		}

		[Test]
		public static void TestTask2()
		{
			var data = new[] { 0, 3 };
			int x1, x2;
			Task2.GetTwoMissing(data, 0, 4, out x1, out x2);

			Assert.AreEqual(x1, 1);
			Assert.AreEqual(x2, 2);

			data = new[] { 1, 2 };
			Task2.GetTwoMissing(data, 0, 4, out x1, out x2);
			Assert.AreEqual(x1, 0);
			Assert.AreEqual(x2, 3);
		}
	}
}
