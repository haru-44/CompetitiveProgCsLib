using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitiveProgCsLib.GraphProblem.Basic;

namespace CompetitiveProgCsLib.GraphProblem
{
	public class MaximumFlow
	{
		public static int MaximumFlow_EdmondsKarp(Graph g, int source, int sink)
		{
			const int UNVISITED = -1;
			var n = g.VertexCount;
			var flow = (new int[n][]).Select(x => x = new int[n]).ToArray();
			var queue = new Queue<int>();
			var total = 0;
			while (true)
			{
				queue.Clear();
				//幅優先探索を行い、増加道を求める
				var prev = (new int[n]).Select(x => x = UNVISITED).ToArray();
				prev[source] = source;
				queue.Enqueue(source);
				while (queue.Count() != 0 && prev[sink] == UNVISITED)
				{
					var u = queue.Dequeue();
					for (int e = 0; e < n; e++)
					{
						if (prev[e] == UNVISITED && flow[u][e] < g.EdgeWeight(new Edge(u,e)))
						{
							prev[e] = u;
							queue.Enqueue(e);
						}
					}
				}
				//増加道が存在しない場合は、現在値を返す
				if (prev[sink] == UNVISITED) return total;
				var inc = int.MaxValue;
				for (int i = sink; i != source; i = prev[i])
				{
					inc = Math.Min(inc, g.EdgeWeight(new Edge(prev[i],i)) - flow[prev[i]][i]);
				}
				for (int i = sink; i != source; i = prev[i])
				{
					flow[prev[i]][i] += inc;
					flow[i][prev[i]] -= inc;
				}
				total += inc;
			}
		}
	}
}
