using System.Collections.Generic;
using System.Linq;

namespace CompetitiveProgCsLib.Mathematics
{
	/// <summary>
	/// 数論に関する処理を提供する。
	/// </summary>
	public static class NumberTheory
	{
		/// <summary>
		/// 最大公約数を返す
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static long GetGcd(long a, long b)
		{
			if (b == 0) return a;
			else return GetGcd(b, a % b);
		}

		/// <summary>
		/// 拡張ユークリッドの互除法を解く。
		/// ax + by = gcd(a,b)を満たす(x,y)を返す
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static long GetExtendedGcd(long a, long b, ref long x, ref long y)
		{
			var g = a;
			x = 1;
			y = 0;
			if (b != 0)
			{
				g = GetExtendedGcd(b, a % b, ref y, ref x);
				y -= (a / b) * x;
			}
			return g;
		}

		/// <summary>
		/// 最小公倍数を返す
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static long GetLcm(long a, long b)
		{
			return a / GetGcd(a, b) * b;
		}

		/// <summary>
		/// 素数判定（素朴）
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static bool IsPrime(int n)
		{
			if (n == 2) return true;
			if (n < 2 || n % 2 == 0) return false;
			for (int v = 3; v * v <= n; v += 2) if (n % v == 0) return false;
			return true;
		}

		/// <summary>
		/// エラトステネスのふるい。nまでの素数リストを返す。
		/// 配列の要素が0でなければ素数
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static int[] SieveOfEratosthenes(int n)
		{
			var primes = Enumerable.Range(0, n + 1).Select(i => i).ToArray();
			primes[1] = 0;
			for (int i = 2; i * i <= n; i++)
			{
				if (primes[i] != 0)
				{
					for (int j = i * i; j <= n; j += i) primes[j] = 0;
				}
			}
			return primes;
		}

		/// <summary>
		/// nまでの素数リストを作成する
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static IEnumerable<int> GetPrimeList(int n)
		{
			return SieveOfEratosthenes(n).Where(x => x != 0);
		}

		/// <summary>
		/// オイラーのφ関数
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static int GetEulerPhi(int n)
		{
			if (n == 0) return 0;
			var ans = n;
			for (var x = 2; x * x <= n; x++)
			{
				if (n % x == 0)
				{
					ans -= ans / x;
					while (n % x == 0) n /= x;
				}
			}
			if (n > 1) ans -= ans / n;
			return ans;
		}
	}
}
