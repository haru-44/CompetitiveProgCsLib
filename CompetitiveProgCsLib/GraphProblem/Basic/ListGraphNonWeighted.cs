using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgCsLib.GraphProblem.Basic
{
	/// <summary>
	/// 隣接リストによる重みなしグラフの表現を提供する
	/// </summary>
	public class ListGraphNonWeighted : Graph
	{
		List<List<int>> edges;

		/// <summary>
		/// 頂点数nのグラフを生成する
		/// </summary>
		/// <param name="n"></param>
		public ListGraphNonWeighted(int n)
		{
			edges = new List<List<int>>();
			for (int i = 0; i < n; i++)
			{
				edges.Add(new List<int>());
			}
		}

		/// <summary>
		/// 頂点数を取得する
		/// </summary>
		public override int VertexCount
		{
			get
			{
				return edges.Count;
			}
		}

		/// <summary>
		/// 辺を追加する
		/// </summary>
		/// <param name="e"></param>
		/// <param name="weight"></param>
		public override void AddEdge(Edge e, int weight = 0)
		{
			edges[e.Src].Add(e.Dest);
		}

		public override IEnumerable<int> ConnectedVertexes(int vertex)
		{
			return edges[vertex];
		}

		public override int EdgeWeight(Edge e)
		{
			throw new NotImplementedException();
		}
	}
}
