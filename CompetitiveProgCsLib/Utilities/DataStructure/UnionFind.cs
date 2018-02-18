using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgCsLib.Utilities.DataStructure
{
	/// <summary>
	/// union findを提供する
	/// 入力は0-origin
	/// </summary>
	public class UnionFind
	{
		#region member
		private List<int> data;
		#endregion

		#region constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="size">初期サイズ</param>
		public UnionFind(int size) : this()
		{
			addSize(size - 1);
		}

		public UnionFind()
		{
			data = new List<int>();
			data.Add(0);
		}
		#endregion

		#region public method
		/// <summary>
		/// xの集合とyの集合を併合する
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public void UnionSet(int x, int y)
		{
			x = getRoot(x);
			y = getRoot(y);
			if (x != y) data[x] = y;
		}

		/// <summary>
		/// xとyが同じ集合に入っているかを判定する
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool FindSet(int x, int y)
		{
			return getRoot(x) == getRoot(y);
		}
		#endregion

		#region private method
		/// <summary>
		/// 頂点を増やす
		/// </summary>
		/// <param name="size">増やす数</param>
		private void addSize(int size)
		{
			int dataSize = data.Count;
			data.AddRange((new int[size]).Select((value, index) => value = index + dataSize));
		}

		/// <summary>
		/// ルートを取得する
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		private int getRoot(int x)
		{
			if (x >= size) addSize(x - size + 1);
			if (data[x] == x) return x;
			else return data[x] = this.getRoot(data[x]);
		}
		#endregion

		#region property
		private int size
		{
			get
			{
				return data.Count;
			}
		}
		#endregion
	}
}
