using System;

namespace CompetitiveProgCsLib.Geometry
{
	public class Point : IComparable, ICloneable
	{
		#region member
		public double X
		{
			get;
			private set;
		}
		public double Y
		{
			get;
			private set;
		}
		#endregion

		#region constructor
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public Point()
		{
			X = 0;
			Y = 0;
		}
		#endregion

		#region operator
		public static Point operator +(Point a, Point b)
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		public static Point operator -(Point a, Point b)
		{
			return new Point(a.X - b.X, a.Y - b.Y);
		}
		public static bool operator >(Point a, Point b)
		{
			if (a.X != b.X) return a.X > b.Y;
			else return a.Y > b.Y;
		}
		public static bool operator >=(Point a, Point b)
		{
			return a == b || (a > b);
		}
		public static bool operator <(Point a, Point b)
		{
			return !(a >= b);
		}
		public static bool operator <=(Point a, Point b)
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
		public static double GetManhattanDistance(Point a, Point b)
		{
			return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
		}

		/// <summary>
		/// ユークリッド距離を取得する
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double GetEuclideanDistance(Point a, Point b)
		{
			var tmp = a - b;
			return Math.Sqrt(tmp.X * tmp.X + tmp.Y * tmp.Y);
		}
		#endregion

		#region override or implementation
		public int CompareTo(object obj)
		{
			if (X != ((Point)obj).X) return X.CompareTo(((Point)obj).X);
			else return Y.CompareTo(((Point)obj).Y);
		}

		public override bool Equals(object obj)
		{
			return this.X == ((Point)obj).X && this.Y == ((Point)obj).Y;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() + (Y.GetHashCode() << 1);
		}
		
		public Point Clone()
		{
			return (Point)MemberwiseClone();
		}
		
		object ICloneable.Clone()
		{
			return Clone();
		}
		#endregion
	}
}
