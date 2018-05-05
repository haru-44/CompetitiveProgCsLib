using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitiveProgCsLib.GraphProblem.Basic;

namespace CompetitiveProgCsLib.GraphProblem
{
	public class BipartiteGraphMatching
	{
		Graph g;
		int N;
		int M;

		public BipartiteGraphMatching(int n,int m)
		{
			N = n;
			M = m;
			g = new MatrixGraph(n + m + 2);
			for (int i = 1; i <= n; i++) g.AddEdge(new Edge(0, i), 1);
			for (int i = n + 1; i <= n + m; i++) g.AddEdge(new Edge(i, n + m + 1), 1);
		}

		public void AddEdge(int s,int t)
		{
			g.AddEdge(new Edge(s + 1, N + 1 + t), 1);
		}

		public int Solve()
		{
			return MaximumFlow.MaximumFlow_EdmondsKarp(g, 0, N + M + 1);
		}
	}
}
