using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgCsLib.GraphProblem.Basic
{
	/// <summary>
	/// 隣接行列によるグラフの表現
	/// </summary>
	public class MatrixGraph : Graph
	{
		int[][] matrix;

		/// <summary>
		/// 頂点数nのグラフを生成する
		/// </summary>
		/// <param name="n"></param>
		public MatrixGraph(int n)
		{
			matrix = (new int[n][]).Select(x => x = new int[n]).ToArray();
		}

		/// <summary>
		/// 頂点数を取得する
		/// </summary>
		public override int VertexCount
		{
			get
			{
				return matrix.Count();
			}
		}

		/// <summary>
		/// 辺を追加する
		/// </summary>
		/// <param name="e"></param>
		/// <param name="weight"></param>
		/// <returns></returns>
		public override void AddEdge(Edge e, int weight)
		{
			matrix[e.Src][e.Dest] = weight;
		}

		/// <summary>
		/// 指定する頂点と隣接する頂点を返す
		/// </summary>
		/// <param name="vertex"></param>
		/// <returns></returns>
		public override IEnumerable<int> ConnectedVertexes(int vertex)
		{
			for (int i = 0; i < VertexCount; i++)
			{
				if (matrix[vertex][i] != 0) yield return i;
			}
		}
		/// <summary>
		/// 辺の重みを取得する
		/// </summary>
		public override int EdgeWeight(Edge e)
		{
			return matrix[e.Src][e.Dest];
		}
	}
}
