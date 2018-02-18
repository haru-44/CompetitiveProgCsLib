using System;

namespace CompetitiveProgCsLib.Utilities
{
	/// <summary>
	/// 整数で表される座標について提供する
	/// </summary>
	public class IntPoint : IComparable, ICloneable
	{
		#region member
		public int X
		{
			get;
			private set;
		}
		public int Y
		{
			get;
			private set;
		}
		#endregion

		#region constructor
		public IntPoint(int x, int y)
		{
			X = x;
			Y = y;
		}

		public IntPoint()
		{
			X = 0;
			Y = 0;
		}
		#endregion

		#region operator
		public static IntPoint operator +(IntPoint a, IntPoint b)
		{
			return new IntPoint(a.X + b.X, a.Y + b.Y);
		}

		public static IntPoint operator -(IntPoint a, IntPoint b)
		{
			return new IntPoint(a.X - b.X, a.Y - b.Y);
		}
		public static bool operator ==(IntPoint a, IntPoint b)
		{
			return a.X == b.X && a.Y == b.Y;
		}
		public static bool operator !=(IntPoint a, IntPoint b)
		{
			return !(a == b);
		}
		public static bool operator >(IntPoint a, IntPoint b)
		{
			if (a.X != b.X) return a.X > b.Y;
			else return a.Y > b.Y;
		}
		public static bool operator >=(IntPoint a, IntPoint b)
		{
			return a == b || (a > b);
		}
		public static bool operator <(IntPoint a, IntPoint b)
		{
			return !(a >= b);
		}
		public static bool operator <=(IntPoint a, IntPoint b)
		{
			return !(a > b);
		}
		#endregion

		#region public method
		/// <summary>
		/// マンハッタン距離を取得する
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int GetManhattanDistance(IntPoint a, IntPoint b)
		{
			return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
		}

		/// <summary>
		/// ユークリッド距離を取得する
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double GetEuclideanDistance(IntPoint a, IntPoint b)
		{
			var tmp = a - b;
			return Math.Sqrt(tmp.X * tmp.X + tmp.Y * tmp.Y);
		}
		#endregion

		#region override or implementation
		public int CompareTo(object obj)
		{
			if (X != ((IntPoint)obj).X) return X.CompareTo(((IntPoint)obj).X);
			else return Y.CompareTo(((IntPoint)obj).Y);
		}

		public override bool Equals(object obj)
		{
			return this.X == ((IntPoint)obj).X && this.Y == ((IntPoint)obj).Y;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() + (Y.GetHashCode() << 1);
		}

		public object Clone()
		{
			return new IntPoint(X, Y);
		}
		#endregion
	}
}
