using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgCsLib.GraphProblem.Basic
{
	/// <summary>
	/// グラフを提供する
	/// </summary>
	public abstract class Graph
	{
		/// <summary>
		/// 頂点数を取得する。
		/// </summary>
		abstract public int VertexCount
		{
			get;
		}

		/// <summary>
		/// 指定する頂点と隣接する頂点を返す
		/// </summary>
		/// <param name="vertex"></param>
		/// <returns></returns>
		abstract public IEnumerable<int> ConnectedVertexes(int vertex);

		/// <summary>
		/// 辺の重みを取得する
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		abstract public int EdgeWeight(Edge e);

		/// <summary>
		/// 辺を追加する
		/// </summary>
		/// <param name="e"></param>
		/// <param name="weight"></param>
		/// <returns></returns>
		abstract public void AddEdge(Edge e, int weight);
	}

}
