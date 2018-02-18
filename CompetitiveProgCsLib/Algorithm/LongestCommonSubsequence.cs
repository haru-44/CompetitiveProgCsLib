using System;
using System.Collections.Generic;
using System.Linq;

namespace CompetitiveProgCsLib.Algorithm
{
	/// <summary>
	/// 最長共通部分列問題を解く
	/// </summary>
	/// <typeparam name="T">要素の型</typeparam>
	public class LongestCommonSubsequence<T>
	{
		#region member
		private T[] array1, array2;
		private int[][] dp;
		#endregion

		#region constructor
		public LongestCommonSubsequence(T[] a1, T[] a2)
		{
			array1 = a1.ToArray();
			array2 = a2.ToArray();
			dp = new int[array1.Length + 1][];
			for (int i = 0; i < dp.Length; i++) dp[i] = new int[array2.Length + 1];
			for (int i = 1; i <= array1.Length; i++)
			{
				for (int j = 1; j <= array2.Length; j++)
				{
					if (array1[i - 1].Equals(array2[j - 1])) dp[i][j] = dp[i - 1][j - 1] + 1;
					else dp[i][j] = Math.Max(dp[i][j - 1], dp[i - 1][j]);
				}
			}
		}
		#endregion

		#region public method
		/// <summary>
		/// 最長共通部分列の長さを取得する
		/// </summary>
		/// <returns></returns>
		public int GetLength()
		{
			return dp[array1.Length][array2.Length];
		}

		/// <summary>
		/// 最長共通部分列を取得する
		/// </summary>
		/// <returns></returns>
		public T[] GetArray()
		{
			var lcs = new LinkedList<T>();
			var len1 = array1.Length;
			var len2 = array2.Length;
			while (len1 > 0 && len2 > 0)
			{
				if (array1[len1 - 1].Equals(array2[len2 - 1]))
				{
					lcs.AddFirst(array1[len1 - 1]);
					len1--;
					len2--;
				}
				else
				{
					if (dp[len1][len2] == dp[len1 - 1][len2]) len1--;
					else len2--;
				}
			}
			return lcs.ToArray();
		}
		#endregion
	}
}
