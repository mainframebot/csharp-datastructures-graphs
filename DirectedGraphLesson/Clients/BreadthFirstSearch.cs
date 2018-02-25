using System;
using System.Collections.Generic;

namespace DirectedGraphLesson.Clients
{
    public class BreadthFirstSearch
    {
        private DirectedGraph _graph;

        private bool[] _marked;

        private int _count;

        public BreadthFirstSearch(DirectedGraph graph, int source)
        {

            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            graph.ValidateVertex(source);

            _graph = graph;
            _marked = new bool[graph.Vertices];
            _count = 0;

            Search(source);
        }

        public bool Marked(int vertex)
        {
            _graph.ValidateVertex(vertex);

            return _marked[vertex];
        }

        public int Count()
        {
            return _count;
        }

        private void Search(int vertex)
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
                        _marked[adjVertex] = true;
                        queue.Enqueue(adjVertex);
                    }
                }
            }
        }
    }
}
