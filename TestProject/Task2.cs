using System;
using System.Linq;

namespace TestProject
{
	public static class Task2
	{
		public static void Run()
		{
			var min = 0;
			var count = 10;
			var rnd = new Random();
			var data = Enumerable.Range(min, count).OrderBy(i => rnd.Next(i)).ToList();

			Console.WriteLine("List:                " + string.Join(", ", data));

			data.RemoveAt(rnd.Next(data.Count));
			data.RemoveAt(rnd.Next(data.Count));

			Console.WriteLine("List (after remove): " + string.Join(", ", data));


			var sum = data.Sum();
			var max = min + count - 1;
			// s = (min + max) / 2 * n
			var expectedSum = (min + max) * count / 2;
			Console.WriteLine("Missing sum: " + (expectedSum - sum));

			var middle = (expectedSum - sum) / 2;

			var data1 = data.Where(i => i <= middle);
			var sum1 = data1.Sum();
			var min1 = min;
			var max1 = middle;
			var count1 = max1 - min1 + 1;
			var expectedSum1 = (min1 + max1) * count1 / 2;
			Console.WriteLine("N1: " + (expectedSum1 - sum1));

			var data2 = data.Where(i => i > middle);
			var sum2 = data2.Sum();
			var min2 = middle+1;
			var max2 = max;
			var count2 = max2 - min2 + 1;
			var expectedSum2 = (min2 + max2) * count2 / 2;
			Console.WriteLine("N2: " + (expectedSum2 - sum2));

		}
	}
}