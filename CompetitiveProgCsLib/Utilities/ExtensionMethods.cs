using System;
using System.Collections.Generic;
using System.Linq;

namespace CompetitiveProgCsLib.Utilities
{
	/// <summary>
	/// 拡張メソッドを提供する
	/// </summary>
	public static class ExtensionMethods
	{
		/// <summary>
		/// Itemの数を集計する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <returns></returns>
		public static Dictionary<T, int> NumberCount<T>(this IEnumerable<T> items)
		{
			return items.GroupBy(s => s).Select(s => new { Item = s.Key, Count = s.Count() }).ToDictionary(g => g.Item, g => g.Count);
		}

		/// <summary>
		/// 順列を生成する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <returns></returns>
		public static IEnumerable<IEnumerable<T>> EnumeratedPermutation<T>(this IEnumerable<T> items)
		{
			if (items.Count() == 1)
			{
				yield return new T[] { items.First() };
				yield break;
			}
			foreach (var item in items)
			{
				var leftside = new T[] { item };
				foreach (var rightside in EnumeratedPermutation(items.Except(leftside)))
				{
					yield return leftside.Concat(rightside);
				}
			}
		}

		/// <summary>
		/// 組合せを生成する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <param name="comb"></param>
		/// <returns></returns>
		public static IEnumerable<IEnumerable<T>> EnumeratedCombination<T>(this IEnumerable<T> items, int comb)
		{
			if (comb == 0)
			{
				yield return new T[] { };
				yield break;
			}
			int pos = 1;
			foreach (var item in items)
			{
				if (items.Count() - pos < comb - 1) continue;
				var leftside = new T[] { item };
				foreach (var rightside in EnumeratedCombination(items.Skip(pos), comb - 1))
				{
					yield return leftside.Concat(rightside);
				}
				pos++;
			}
		}

		/// <summary>
		/// itemsの内、selector.Invoke(x)が最小の値となるxを返す
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		public static T MinST<T>(this IEnumerable<T> items, Func<T, T> selector)
		{
			var array = items.Select(x => new { Item = x, Val = selector.Invoke(x) });
			var min = array.Min(x => x.Val);
			return array.Where(x => x.Val.Equals(min)).FirstOrDefault().Item;
		}

		/// <summary>
		/// itemsの内、selector.Invoke(x)が最大の値となるxを返す
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		public static T MaxST<T>(this IEnumerable<T> items, Func<T, T> selector)
		{
			var array = items.Select(x => new { Item = x, Val = selector.Invoke(x) });
			var max = array.Max(x => x.Val);
			return array.Where(x => x.Val.Equals(max)).FirstOrDefault().Item;
		}
	}
}
