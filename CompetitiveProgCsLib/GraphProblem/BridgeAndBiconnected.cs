using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitiveProgCsLib.GraphProblem.Basic;

namespace CompetitiveProgCsLib.GraphProblem
{
	public class BridgeAndBiconnected
	{
		/// <summary>
		/// 橋の辺リスト
		/// </summary>
		public List<Edge> BridgeEdges
		{
			private set;
			get;
		}

		/// <summary>
		/// 二重辺連結成分に分けた頂点リスト
		/// </summary>
		public List<List<int>> BiconnectedComponent
		{
			private set;
			get;
		}

		private Stack<int> roots;
		private Stack<int> S;
		private bool[] inS;
		private int[] num;
		private int time;
		private Graph g;

		private void visit(int v, int u)
		{
			num[v] = ++time;
			S.Push(v);
			inS[v] = true;
			roots.Push(v);
			foreach (var w in g.ConnectedVertexes(v))
			{
				if (num[w] == 0) visit(w, v);
				else if (u != w && inS[w]) while (num[roots.Peek()] > num[w]) roots.Pop();
			}
			if (v == roots.Peek())
			{
				BridgeEdges.Add(new Edge(u, v));
				var comp = new List<int>();
				while (true)
				{
					int w = S.Pop();
					inS[w] = false;
					comp.Add(w);
					if (v == w) break;
				}
				BiconnectedComponent.Add(comp);
				roots.Pop();
			}
		}
		
		public BridgeAndBiconnected(Graph graph)
		{
			int n = graph.VertexCount;
			g = graph;
			BridgeEdges = new List<Edge>();
			BiconnectedComponent = new List<List<int>>();
			roots = new Stack<int>();
			S = new Stack<int>();
			inS = new bool[n];
			num = new int[n];
			time = 0;
			for (int u = 0; u < n; u++)
			{
				if (num[u] == 0)
				{
					visit(u, n);
					BridgeEdges.RemoveAt(BridgeEdges.Count - 1);
				}
			}
		}
	}
}
