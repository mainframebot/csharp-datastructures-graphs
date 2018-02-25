using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndirectedGraph
{
    public class UndirectedGraph
    {
        public int Vertices { get; set; }

        public int Edges { get; set; }

        public Dictionary<int, List<int>> AdjacencyVertices { get; set; }

        public UndirectedGraph(int vertices)
        {
            Vertices = vertices;
            Edges = 0;
            AdjacencyVertices = new Dictionary<int, List<int>>(vertices);
        }

        public void InsertEdge(int source, int destination)
        {
            AdjacencyVertices[source].Add(destination);
            AdjacencyVertices[destination].Add(source);

            Edges++;
        }

        public List<int> Adjacency(int source)
        {
            return AdjacencyVertices[source];
        }
    }
}
