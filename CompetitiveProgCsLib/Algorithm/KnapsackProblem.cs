using System;
using System.Collections.Generic;
using System.Linq;

namespace CompetitiveProgCsLib.Algorithm
{
	public class KnapsackProblem
	{
		/// <summary>
		/// 0-1ナップサック問題を解く。計算量：O(nV) where n=品物の個数、V=品物の価値合計
		/// 引数としてV未指定の場合は、capacity + 1。指定する場合はその値をVとする。
		/// </summary>
		/// <param name="goods"></param>
		public static IEnumerable<Item> Solve01nV(Item[] goods, int capacity)
		{
			int inf = capacity + 1;
			int maxValue = goods.Sum(item => item.Value);
			int[][] dp = new int[goods.Length + 1][];
			for (int i = 0; i < dp.Length; i++) dp[i] = new int[maxValue + 1];
			for (int i = 1; i < dp[0].Length; i++) dp[0][i] = inf;
			for (int i = 1; i < dp.Length; i++)
			{
				var item = goods[i - 1];
				for (int j = 0; j < item.Value && j <= maxValue; j++) dp[i][j] = dp[i - 1][j];
				for (int j = item.Value; j <= maxValue; j++)
				{
					var newWeight = dp[i - 1][j - item.Value] + item.Weight;
					dp[i][j] = Math.Min(dp[i - 1][j], newWeight);
				}
			}
			int currentGoods = goods.Length;
			int pos = 0;
			for (int i = maxValue; i > 0; i--)
			{
				if (dp[currentGoods][i] != inf)
				{
					pos = i;
					break;
				}
			}
			for (; currentGoods > 0; currentGoods--)
			{
				if (dp[currentGoods][pos] != dp[currentGoods - 1][pos])
				{
					yield return goods[currentGoods - 1];
					pos -= goods[currentGoods - 1].Value;
				}
			}
		}

		/// <summary>
		/// 0-1ナップサック問題を解く。計算量：O(nW) where n=品物の個数、W=capacity
		/// </summary>
		/// <param name="goods"></param>
		public static IEnumerable<Item> Solve01nW(Item[] goods, int capacity)
		{
			int[][] dp = new int[goods.Length + 1][];
			for (int i = 0; i <= goods.Length; i++) dp[i] = new int[capacity + 1];
			for (int i = 0; i <= capacity; i++) dp[0][i] = 0;
			for (int i = 1; i <= goods.Length; i++)
			{
				var item = goods[i - 1];
				for (int j = 0; j < item.Weight && j <= capacity; j++) dp[i][j] = dp[i - 1][j];
				for (int j = item.Weight; j <= capacity; j++)
				{
					var newValue = dp[i - 1][j - item.Weight] + item.Value;
					dp[i][j] = Math.Max(dp[i - 1][j], newValue);
				}
			}
			int currentGoods = goods.Length;
			int pos = capacity;
			for (; currentGoods > 0; currentGoods--)
			{
				if (dp[currentGoods][pos] != dp[currentGoods - 1][pos])
				{
					yield return goods[currentGoods - 1];
					pos -= goods[currentGoods - 1].Weight;
				}
			}
		}

		/// <summary>
		/// 品物を表すクラス
		/// </summary>
		public class Item : IComparable
		{
			/// <summary>
			/// 品物の価値
			/// </summary>
			public int Value
			{
				get;
				private set;
			}
			/// <summary>
			/// 品物の重さ
			/// </summary>
			public int Weight
			{
				get;
				private set;
			}
			public Item(int value, int weight)
			{
				Value = value;
				Weight = weight;
			}

			internal double Efficiency
			{
				get
				{
					return (double)Value / Weight;
				}
			}

			public int CompareTo(object obj) => Efficiency.CompareTo(((Item)obj).Efficiency);
		}
	}
}
