using System.Linq;

namespace CompetitiveProgCsLib.Mathematics
{
	public static class ModuloOperation
	{
		/// <summary>
		/// 10^9+7
		/// </summary>
		public const int modPrime = 1000000007;

		/// <summary>
		/// べき乗を計算する。 (baseNum ^ expNum) % modNumer
		/// </summary>
		/// <param name="baseNum"></param>
		/// <param name="expNum"></param>
		/// <param name="modNumber"></param>
		/// <returns></returns>
		public static long Pow(long baseNum, long expNum, long modNumber = modPrime)
		{
			if (expNum == 0) return 1;
			if (expNum % 2 == 0)
			{
				return Pow(baseNum * baseNum % modNumber, expNum / 2, modNumber);
			}
			else
			{
				return baseNum * Pow(baseNum, expNum - 1, modNumber) % modNumber;
			}
		}

		/// <summary>
		/// xy = 1 % mod となるようなyを返す。存在しない場合は、0を返す。
		/// </summary>
		/// <param name="x"></param>
		/// <param name="mod"></param>
		/// <returns></returns>
		public static long Inverse(long x, long mod = modPrime)
		{
			long a = 0, b = 0;
			if (NumberTheory.GetExtendedGcd(x, mod, ref a, ref b) == 1) return (a + mod) % mod;
			else return 0;
		}

		/// <summary>
		/// 階乗を計算する。　n! % modNumber
		/// </summary>
		/// <param name="n"></param>
		/// <param name="modNumber"></param>
		/// <returns></returns>
		public static long Factorial(int n, int modNumber = modPrime) => Enumerable.Range(1, n).Aggregate((i, j) => (i * j) % modNumber);

		/// <summary>
		/// 組合せを計算する。　{n \choose k} % modNumber
		/// </summary>
		/// <param name="n"></param>
		/// <param name="k"></param>
		/// <param name="modNumber"></param>
		/// <returns></returns>
		public static long Combination(int n, int k, long modNumber = modPrime)
		{
			if (n == 0) return 0;
			if (n - k < k) k = n - k;
			var ret = 1L;
			for (int i = 1; i <= k; i++) ret = ((ret * (n - i + 1)) / i) % modNumber;
			return ret;
		}

		/// <summary>
		/// 順列を計算する。
		/// </summary>
		/// <param name="n"></param>
		/// <param name="k"></param>
		/// <param name="modNumber"></param>
		/// <returns></returns>
		public static long Permutation(int n, int k, long modNumber = modPrime)
		{
			var ret = 1L;
			for (int i = n - k + 1; i <= n; i++) ret = (ret * i) % modNumber;
			return ret;
		}
	}
}
