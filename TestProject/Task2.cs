using System;
using System.Linq;
using System.Net.NetworkInformation;

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

			int x1, x2;
			GetTwoMissing(data.ToArray(), min, count, out x1, out x2);

			Console.WriteLine("N1: " + x1);
			Console.WriteLine("N2: " + x2);
		}

		public static void GetTwoMissing(int[] data, int min, int count, out int x1, out int x2)
		{
			var sum = data.Sum();
			var max = min + count - 1;
			// s = (min + max) / 2 * n
			var expectedSum = (min + max) * count / 2;

			var middle = (expectedSum - sum) / 2;

			var data1 = data.Where(i => i <= middle);
			var sum1 = data1.Sum();
			var min1 = min;
			var max1 = middle;
			var count1 = max1 - min1 + 1;
			var expectedSum1 = (min1 + max1) * count1 / 2;

			x1 = expectedSum1 - sum1;
			x2 = (expectedSum - sum) - x1;
		}
	}
}