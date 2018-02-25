using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraphLesson
{
    public class DirectedGraph
    {
        public int Vertices { get; set; }

        public int Edges { get; set; }

        public Stack<int>[] VerticesAdjacency { get; set; }

        public int[] VerticesInDegree { get; set;  }

        public DirectedGraph(int vertices)
        {
            if(vertices <= 0)
                throw new ArgumentException();

            Vertices = vertices;
            Edges = 0;
            VerticesAdjacency = new Stack<int>[vertices];
            VerticesInDegree = new int[vertices];

            for (var i = 0; i < vertices; i++)
                VerticesAdjacency[i] = new Stack<int>();
        }

        public void InsertEdge(int source, int destination)
        {
            ValidateVertex(source);
            ValidateVertex(destination);

            VerticesAdjacency[source].Push(destination);
            VerticesInDegree[destination]++;

            Edges++;
        }

        public Stack<int> VertexAdjacency(int vertex)
        {
            ValidateVertex(vertex);

            return VerticesAdjacency[vertex];
        }

        public int VertexOutDegree(int vertex)
        {
            ValidateVertex(vertex);

            return VerticesAdjacency[vertex].Count;
        }

        public int VertexInDegree(int vertex)
        {
            ValidateVertex(vertex);

            return VerticesInDegree[vertex];
        }

        public void ValidateVertex(int vertex)
        {
            if (vertex < 0 || vertex >= Vertices)
                throw new IndexOutOfRangeException();
        }

        public DirectedGraph Reverse()
        {
            var graph = new DirectedGraph(Vertices);

            for (var i = 0; i < Vertices; i++)
            {
                foreach(var adjVertex in VerticesAdjacency[i])
                    graph.InsertEdge(adjVertex, i);
            }

            return graph;
        }
    }
}
