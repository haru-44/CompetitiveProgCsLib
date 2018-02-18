using System;
using System.Collections.Generic;

namespace CompetitiveProgCsLib.Utilities
{
	/// <summary>
	/// メモ化を提供する
	/// Usage：
	/// public static int GetFibonacci(int n,Func<int,int> rec)
	/// {
	///		if (n &lt;= 1) return n;
	///		else return rec.Invoke(n - 1) + rec.Invoke(n - 2);
	///	}
	///	var memo = new Memorizer(GetFibonacci);
	///	var output = memo.GetValue(5); //output = 5
	/// </summary>
	/// <typeparam name="T">入力の型</typeparam>
	/// <typeparam name="V">出力の型</typeparam>
	public class Memorizer<T, V>
	{
		/// <summary>
		/// 再帰を行う関数
		/// </summary>
		private Func<T, Func<T, V>, V> function;
		private Dictionary<T, V> memo;

		/// <summary>
		/// 再帰を行う関数をメモ化する。
		/// T : 入力の型
		/// V : 出力の型
		/// Func : 再帰を行うときはこの関数を使う
		/// </summary>
		/// <param name="f"></param>
		public Memorizer(Func<T, Func<T, V>, V> f)
		{
			function = f;
			memo = new Dictionary<T, V>();
		}

		/// <summary>
		/// 出力を得る
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public V GetValue(T input)
		{
			if (memo.ContainsKey(input)) return memo[input];
			else
			{
				var ret = function(input, GetValue);
				memo.Add(input, ret);
				return ret;
			}
		}
	}
}
