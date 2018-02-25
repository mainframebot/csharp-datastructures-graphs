using System;
using System.Collections.Generic;
using System.Linq;

namespace UndirectedGraphLesson
{
    public class UndirectedGraph
    {
        public int Vertices { get; set; }

        public int Edges { get; set; }

        public Stack<int>[] VerticesAdjacency { get; set; }

        public UndirectedGraph(int vertices)
        {
            if (vertices <= 0)
                throw new ArgumentException();

            Vertices = vertices;
            Edges = 0;
            VerticesAdjacency = new Stack<int>[vertices];

            for(var i = 0; i < vertices; i++)
                VerticesAdjacency[i] = new Stack<int>();
        }

        public void InsertEdge(int source, int destination)
        {
            ValidateVertex(source);
            ValidateVertex(destination);

            VerticesAdjacency[source].Push(destination);
            VerticesAdjacency[destination].Push(source);

            Edges++;
        }

        public Stack<int> VertexAdjacency(int vertex)
        {
            ValidateVertex(vertex);

            return VerticesAdjacency[vertex];
        }

        public int VertexDegree(int vertex)
        {
            ValidateVertex(vertex);

            return VerticesAdjacency[vertex].Count;
        }

        public int GraphMaxVertexDegree()
        {
            var max = 0;
            
            for(var i =0; i < Vertices; i++)
                max = (VertexDegree(i) > max) ? VertexDegree(i) : max;

            return max;
        }

        public int GraphAverageVertexDegree()
        {
            if (Vertices == 0)
                return 0;

            return 2*Edges/Vertices;
        }

        public int GraphNumberOfSelfLoops()
        {
            var count = 0;

            for (var i = 0; i < Vertices; i++)
            {
                count = VerticesAdjacency[i].Any(x => x == i) ? count + 1 : count;
            }

            return count;
        }

        public void ValidateVertex(int vertex)
        {
            if(vertex < 0 || vertex >= Vertices)
                throw new IndexOutOfRangeException();
        }
    }
}
