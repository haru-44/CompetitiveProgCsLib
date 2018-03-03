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
	}
}
