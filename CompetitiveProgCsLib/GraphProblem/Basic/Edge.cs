using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgCsLib.GraphProblem.Basic
{
	/// <summary>
	/// グラフにおける辺を提供する
	/// </summary>
	public class Edge
	{
		public int Src
		{
			get;
			private set;
		}
		public int Dest
		{
			get;
			private set;
		}
		public Edge(int src, int dest)
		{
			Src = src;
			Dest = dest;
		}
	}
}
