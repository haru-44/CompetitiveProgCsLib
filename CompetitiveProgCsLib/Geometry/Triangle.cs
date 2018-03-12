using System;
using System.Linq;
using System.Diagnostics;

namespace CompetitiveProgCsLib.Geometry
{
	/// <summary>
	/// 三角形を表す
	/// </summary>
	public class Triangle
	{
		/// <summary>
		/// 三角形の頂点。反時計回りにある。
		/// </summary>
		private Point[] apexes;

		public Triangle(params Point[] p)
		{
			Debug.Assert(p.Length == 3);
			apexes = new Point[3];
			for (int i = 0; i < apexes.Length; i++) apexes[i] = p[i].Clone();
			if (GetSign(apexes[0], apexes[1], apexes[2]) < 0)
			{
				var tmp = apexes[1];
				apexes[1] = apexes[2];
				apexes[2] = tmp;
			}
		}

		/// <summary>
		/// 符号付き面積を取得する
		/// </summary>
		/// <returns></returns>
		public double GetSignedArea()
		{
			return GetSign(apexes[0], apexes[1], apexes[2]) / 2;
		}

		/// <summary>
		/// 与えられた点が三角形の内部に存在するかを判定する（辺上はfalse）
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public bool IsInnerPoint(Point p)
		{
			for (int i = 0; i < apexes.Length; i++)
				if (GetSign(apexes[i], apexes[(i + 1) % apexes.Length], p) <= 0) return false;
			return true;
		}

		/// <summary>
		/// 符号付き面積の符号を取得する
		/// </summary>
		/// <returns></returns>
		internal static double GetSign(Point a, Point b, Point c)
		{
			return (b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y);
		}

		/// <summary>
		/// ヘロンの公式を使い、3辺の長さから三角形の面積を求める
		/// </summary>
		/// <param name="sides"></param>
		/// <param name="b"></param>
		/// <param name="c"></param>
		/// <returns></returns>
		public static double HeronsFormula(params double[] sides)
		{
			Debug.Assert(sides.Length == 3);
			var s = sides.Sum() / 2;
			return sides.Select(x => Math.Sqrt(s - x)).Aggregate(Math.Sqrt(s),(x, y) => x * y);
		}

		/// <summary>
		/// 3辺の長さを与えて、三角形を作れるかを判定する
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="c"></param>
		/// <returns></returns>
		public static bool IsTriangle(int a, int b, int c)
		{
			return a + b > c && a + c > b && b + c > a;
		}
	}
}