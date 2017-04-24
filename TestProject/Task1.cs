using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
	public class ListNode<T>
	{
		public ListNode(T value)
		{
			Value = value;
		}

		public ListNode<T> Next { get; internal set; }
		public T Value { get; set; }

		public override string ToString()
		{
			return Value?.ToString() ?? "";
		}
	}

	public class LinkedList<T> : IEnumerable<T>
	{
		public LinkedList(params T[] values)
		{
			foreach (var item in values)
			{
				Add(item);
			}
		}

		public ListNode<T> First { get; private set; }
		public ListNode<T> Last { get; private set; }

		public void Add(T item)
		{
			if (Last == null)
			{
				First = new ListNode<T>(item);
				Last = First;
			}
			else
			{
				var oldLast = Last;
				Last = new ListNode<T>(item);
				oldLast.Next = Last;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			var current = First;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void ReverseInplace()
		{
			if (First == null) return;

			var current = First;
			var prev = default(ListNode<T>);
			while (current != null)
			{
				var tmp = current.Next;

				current.Next = prev;
				prev = current;

				current = tmp;
			}

			Last = First;
			First = prev;
		}

		public void ReverseInplaceOptinizedNotReady()
		{
			if (First == null) return;

			var current = First;
			First = default(ListNode<T>); // current last item
			while (current.Next != null)
			{
				Last = current.Next;      // save ref to next
				current.Next = First;     // current.Next = prev last item
				First = current;          // update last item
				current = Last;           // restore ref to next
			}

			//Last = First;
		}
	}

	public static class Task1
	{
		public static void Run()
		{
			var list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
			Console.WriteLine(string.Join(";", list));

			list.ReverseInplace();
			Console.WriteLine(string.Join(";", list));
		}
	}
}