using System;
using System.Linq;

namespace CompetitiveProgCsLib.Utilities.DataStructure
{
	/// <summary>
	/// セグメント木を提供する
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SegmentTree<T>
	{
		#region member
		/// <summary>
		/// 評価する演算子
		/// </summary>
		private Func<T, T, T> associativeOperation;
		/// <summary>
		/// データを保存する木構造
		/// </summary>
		private T[] tree;
		/// <summary>
		/// 単位元
		/// </summary>
		private T identityElement;
		/// <summary>
		/// tree[origin]に元の数列の先頭がある
		/// </summary>
		private int origin;
		#endregion

		#region property
		/// <summary>
		/// 配列の長さ
		/// </summary>
		public int Length
		{
			get;
			private set;
		}
		/// <summary>
		/// 現在の配列を返す
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public T this[int index]
		{
			get
			{
				return tree[origin + index];
			}
			private set
			{
				tree[origin + index] = value;
			}
		}
		#endregion

		#region private method
		private T evaluate(int a, int b, int k, int l, int r)
		{
			if (r <= a || b <= l) return identityElement;
			if (a <= l && r <= b) return tree[k];
			else
			{
				T val_l = this.evaluate(a, b, k * 2 + 1, l, (l + r) / 2);
				T val_r = this.evaluate(a, b, k * 2 + 2, (l + r) / 2, r);
				return associativeOperation.Invoke(val_l, val_r);
			}
		}
		#endregion

		#region constructor
		public SegmentTree(int n, Func<T, T, T> operation, T identity = default(T)) : this((new T[n]).Select(x => x = identity).ToArray(), operation, identity)
		{
		}

		public SegmentTree(T[] array, Func<T, T, T> operation, T identity = default(T))
		{
			Length = array.Length;
			associativeOperation = operation;
			int size = 1 << (int)Math.Ceiling(Math.Log(Length, 2));
			identityElement = identity;
			tree = (new T[size * 2 - 1]).Select(x => x = identityElement).ToArray();
			origin = tree.Length - size;
			for (int i = 0; i < array.Length; i++)
			{
				this[i] = array[i];
			}
			for (int i = origin - 1; i >= 0; i--)
			{
				tree[i] = associativeOperation.Invoke(tree[i * 2 + 1], tree[i * 2 + 2]);
			}
		}
		#endregion

		#region public method
		/// <summary>
		/// indexの位置の値をvalueに更新する
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Update(int index, T value)
		{
			this[index] = value;
			int position = origin + index;
			while (position > 0)
			{
				position = (position - 1) / 2;
				tree[position] = associativeOperation.Invoke(tree[position * 2 + 1], tree[position * 2 + 2]);
			}
		}

		/// <summary>
		/// a &lt;= x &lt; b の区間において評価を行う
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public T Evaluate(int a, int b)
		{
			var ret = evaluate(a, b, 0, 0, (tree.Length + 1) / 2);
			return ret;
		}
		#endregion
	}
}
