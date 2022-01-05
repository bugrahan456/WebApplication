using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
	class Kruskal
	{
		public int e = 0;
		public struct Subset
		{
			public int Parent;
			public int Rank;
		}
		public static Graph CreateGraph(List<Edge> rt, int verticesCount, int edgesCoun)
		{
			Graph graph = new Graph();
			graph.VerticesCount = verticesCount;
			graph.EdgesCount = edgesCoun;
			graph.Edge = new Edge[graph.EdgesCount];
			graph.Edge = rt.ToArray();
			return graph;
		}
		public int deger()
		{
			return e;
		}

		private int Find(Subset[] subsets, int i)
		{
			if (subsets[i].Parent != i)
				subsets[i].Parent = Find(subsets, subsets[i].Parent);

			return subsets[i].Parent;
		}

		private void Union(Subset[] subsets, int x, int y)
		{
			int xroot = Find(subsets, x);
			int yroot = Find(subsets, y);

			if (subsets[xroot].Rank < subsets[yroot].Rank)
				subsets[xroot].Parent = yroot;
			else if (subsets[xroot].Rank > subsets[yroot].Rank)
				subsets[yroot].Parent = xroot;
			else
			{
				subsets[yroot].Parent = xroot;
				++subsets[xroot].Rank;
			}
		}

		private void Print(Edge[] result, int e)
		{
			for (int i = 0; i < e; ++i)
				Console.WriteLine("{0} -- {1} == {2}", result[i].Source, result[i].Destination, result[i].Weight);
		}

		public Edge[] Kruskal2(Graph graph)
		{
			int verticesCount = graph.VerticesCount;
			Edge[] result = new Edge[verticesCount];
			int i = 0;

			Array.Sort(graph.Edge, delegate (Edge a, Edge b)
			{
				return a.Weight.CompareTo(b.Weight);
			});

			Subset[] subsets = new Subset[verticesCount];

			for (int v = 0; v < verticesCount; ++v)
			{
				subsets[v].Parent = v;
				subsets[v].Rank = 0;
			}

			while (e < verticesCount - 1)
			{
				Edge nextEdge = graph.Edge[i++];
				int x = Find(subsets, nextEdge.Source);
				int y = Find(subsets, nextEdge.Destination);

				if (x != y)
				{
					result[e++] = nextEdge;
					Union(subsets, x, y);
				}
			}

			Print(result, e);
			return result;

		}

		public List<Edge> Calistir(List<Edge> a, int vverticesCount, int eedgecont)
		{
			Graph graph = CreateGraph(a, vverticesCount, eedgecont);

			for (int i = 0; i < eedgecont; i++)
			{
				graph.Edge[i].Source = a[i].Source;
				graph.Edge[i].Destination = a[i].Destination;
				graph.Edge[i].Weight = a[i].Weight;
			}

			//graph.Edge = a.ToArray();
			List<Edge> result = Kruskal2(graph).ToList();
			return result;
		}
	}
}
