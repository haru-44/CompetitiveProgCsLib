using System;
using System.Collections.Generic;
using System.Linq;

namespace CompetitiveProgCsLib.Utilities
{
	/// <summary>
	/// マス目マップに対する基本的な操作を提供する
	/// </summary>
	public class SquaresMap
	{
		#region member
		/// <summary>
		/// 移動不可能マスを表す文字
		/// </summary>
		private const char ObstacleChar = '#';
		private static IntPoint[] near4 = new IntPoint[] { new IntPoint(-1, 0), new IntPoint(1, 0), new IntPoint(0, -1), new IntPoint(0, 1) };
		private static IntPoint[] nearSlan = new IntPoint[] { new IntPoint(-1, -1), new IntPoint(-1, 1), new IntPoint(1, -1), new IntPoint(1, 1) };
		/// <summary>
		/// マップ情報
		/// </summary>
		private string[] _map;
		#endregion

		#region constructor
		/// <summary>
		/// 
		/// </summary>
		/// <param name="map">対象となるマップ</param>
		public SquaresMap(string[] map)
		{
			_map = new string[map.Length];
			for (int i = 0; i < map.Length; i++) _map[i] = (string)map[i].Clone();
		}
		#endregion

		#region private method
		/// <summary>
		/// 点がマップの範囲内か判定する
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private bool IsIn(IntPoint p)
		{
			return IsIn(p.X, p.Y);
		}

		/// <summary>
		/// 点がマップの範囲内か判定する
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		private bool IsIn(int x, int y)
		{
			return 0 <= x && x < Width && 0 <= y && y < Height;
		}

		/// <summary>
		/// 点がマップの範囲内で、障害物でないか判定する
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private bool IsRegular(IntPoint p)
		{
			return IsIn(p) && _map[p.Y][p.X] != ObstacleChar;
		}

		private IEnumerable<IntPoint> GetNear4(IntPoint point)
		{
			foreach (var near in near4)
			{
				var n = point + near;
				if (IsRegular(n)) yield return n;
			}
		}

		private IEnumerable<IntPoint> GetNear8(IntPoint point)
		{
			foreach (var near in GetNear4(point)) yield return near;
			foreach (var near in nearSlan)
			{
				var n = point + near;
				if (IsRegular(n)) yield return n;
			}
		}
		#endregion

		#region public method
		/// <summary>
		/// sからtまでの最短経路を返す
		/// </summary>
		/// <param name="s"></param>
		/// <param name="t"></param>
		/// <returns>sからtへの移動列</returns>
		public IntPoint[] GetShortestPath(IntPoint s, IntPoint t)
		{
			if (!IsRegular(s) || !IsRegular(t)) return null;
			IntPoint Unreached = new IntPoint(-1, -1);
			IntPoint[][] previousPoint = new IntPoint[Height][];
			for (int i = 0; i < Height; i++)
			{
				previousPoint[i] = new IntPoint[Width];
				for (int j = 0; j < Width; j++) previousPoint[i][j] = Unreached;
			}
			var queue = new Queue<IntPoint>();
			queue.Enqueue(s);
			previousPoint[s.Y][s.X] = new IntPoint();

			while (queue.Count != 0)
			{
				var item = queue.Dequeue();
				if (item == t) break;
				foreach (var next in GetNear4(item))
				{
					if (previousPoint[next.Y][next.X] == Unreached)
					{
						previousPoint[next.Y][next.X] = item;
						queue.Enqueue(next);
					}
				}
			}
			if (previousPoint[t.Y][t.X] == Unreached) return null;
			var list = new LinkedList<IntPoint>();
			list.AddFirst(t);
			IntPoint currentPoint = t;
			while (true)
			{
				var pre = previousPoint[currentPoint.Y][currentPoint.X];
				list.AddFirst(pre);
				if (pre == s) break;
				currentPoint = pre;
			}
			return list.ToArray();
		}
		#endregion

		#region property
		/// <summary>
		/// マップの幅
		/// </summary>
		public int Width
		{
			get
			{
				return _map[0].Length;
			}
		}

		/// <summary>
		/// マップの高さ
		/// </summary>
		public int Height
		{
			get
			{
				return _map.Length;
			}
		}
		#endregion
	}
}
