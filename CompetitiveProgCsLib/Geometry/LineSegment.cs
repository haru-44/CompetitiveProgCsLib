using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgCsLib.Geometry
{
	/// <summary>
	/// 線分を表す
	/// </summary>
	public class LineSegment
	{
		private Point s, t;

		public LineSegment(Point p1, Point p2)
		{
			s = p1.Clone();
			t = p2.Clone();
		}

		/// <summary>
		/// 二つの線分が交差しているかを判定する
		/// </summary>
		/// <param name="ls1"></param>
		/// <param name="ls2"></param>
		/// <returns></returns>
		public static bool IsCross(LineSegment ls1, LineSegment ls2)
		{
			return IsCrossSubModule(ls1, ls2) && IsCrossSubModule(ls2, ls1);
		}

		private static bool IsCrossSubModule(LineSegment ls1, LineSegment ls2)
		{
			return Triangle.GetSign(ls1.s, ls1.t, ls2.s) * Triangle.GetSign(ls1.s, ls1.t, ls2.t) < 0;
		}
	}
}
