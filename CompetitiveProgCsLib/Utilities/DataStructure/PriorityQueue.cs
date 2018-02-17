using System;
using System.Collections.Generic;

namespace CompetitiveProgCsLib.Utilities.DataStructure
{
	/// <summary>
	/// 優先度付きキューを提供する
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PriorityQueue<T> where T : IComparable
	{
		#region member
		private List<T> list;
		private bool reverse;
		#endregion

		#region constructor
		/// <summary>
		/// 
		/// </summary>
		/// <param name="isReverse">定義された順序の逆で評価する</param>
		public PriorityQueue(bool isReverse = false)
		{
			list = new List<T>();
			reverse = isReverse;
		}
		#endregion

		#region private method
		private bool compare(T a, T b)
		{
			return reverse ^ a.CompareTo(b) > 0;
		}

		private void swap(int a, int b)
		{
			T tmp = list[a];
			list[a] = list[b];
			list[b] = tmp;
		}
		#endregion

		#region public method
		/// <summary>
		/// 要素を追加する
		/// </summary>
		/// <param name="item">追加する要素</param>
		public void Push(T item)
		{
			if (Length < list.Count) list[Length] = item;
			else list.Add(item);
			var pos = Length++;
			while (pos != 0)
			{
				var parent = (pos + 1) / 2 - 1;
				if (compare(list[pos], list[parent])) break;
				swap(pos, parent);
				pos = parent;
			}
		}

		/// <summary>
		/// 要素を追加する
		/// </summary>
		/// <param name="items">追加する要素の列</param>
		public void Push(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				Push(item);
			}
		}

		/// <summary>
		/// 値を確認する
		/// </summary>
		/// <returns></returns>
		public T Peek()
		{
			return list[0];
		}

		/// <summary>
		/// 値を取り出す
		/// </summary>
		/// <returns></returns>
		public T Pop()
		{
			var ret = Peek();
			var pos = 0;
			list[0] = list[--Length];
			while (2 * pos + 1 < Length)
			{
				var child = 2 * pos + 1;
				var child_other = 2 * pos + 2;
				if (child_other < Length && compare(list[child], list[child_other]))
				{
					child = child_other;
				}
				if (compare(list[child], list[pos])) break;
				swap(pos, child);
				pos = child;
			}
			return ret;
		}

		/// <summary>
		/// クリアする
		/// </summary>
		public void Clear()
		{
			list.Clear();
		}
		#endregion

		#region property
		/// <summary>
		/// 要素の長さを取得する
		/// </summary>
		public int Length
		{
			get;
			private set;
		}
		#endregion
	}
}
