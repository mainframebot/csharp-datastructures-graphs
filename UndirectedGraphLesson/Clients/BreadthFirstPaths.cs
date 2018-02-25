using System;
using System.Collections.Generic;

namespace UndirectedGraphLesson.Clients
{
    public class BreadthFirstPaths
    {
        private UndirectedGraph _graph;

        private bool[] _marked;

        private int[] _edgeTo;

        private int _source;

        public BreadthFirstPaths(UndirectedGraph graph, int source)
        {
            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            graph.ValidateVertex(source);

            _graph = graph;
            _marked = new bool[graph.Vertices];
            _edgeTo = new int[graph.Vertices];
            _source = source;

            Search(source);
        }

        public bool HasPathTo(int vertex)
        {
            _graph.ValidateVertex(vertex);

            return _marked[vertex];
        }

        public Stack<int> PathTo(int vertex)
        {
            if (!HasPathTo(vertex))
                return null;

            var path = new Stack<int>();

            for (var x = vertex; x != _source; x = _edgeTo[x])
                path.Push(x);

            path.Push(_source);

            return path;
        }

        private void Search( int vertex)
        {
            var queue = new Queue<int>();

            queue.Enqueue(vertex);
            _marked[vertex] = true;

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                foreach (var adjVertex in _graph.VertexAdjacency(current))
                {
                    if (!_marked[adjVertex])
                    {
                        _edgeTo[adjVertex] = current;
                        _marked[adjVertex] = true;
                        queue.Enqueue(adjVertex);
                    }
                }
            }
        }
    }
}
