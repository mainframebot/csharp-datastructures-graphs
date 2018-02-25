using System;
using System.Collections.Generic;

namespace UndirectedGraphLesson.Clients
{
    public class DepthFirstSearchNonRecursive
    {
        private UndirectedGraph _graph;

        private bool[] _marked;

        private int _count;

        public DepthFirstSearchNonRecursive(UndirectedGraph graph, int source)
        {
            if(graph == null || graph.Vertices == 0)
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
            var adj = new IEnumerator<int>[_graph.Vertices];
            for (var i = 0; i < _graph.Vertices; i++)
                adj[i] = _graph.VertexAdjacency(i).GetEnumerator();

            var stack = new Stack<int>();

            stack.Push(vertex);
            _marked[vertex] = true;

            while (stack.Count != 0)
            {
                var next = stack.Peek();

                if (adj[next].MoveNext())
                {
                    var current = adj[next].Current;

                    if(!_marked[current])
                    {
                        stack.Push(current);
                        _marked[current] = true;
                    }
                }
                else
                {
                    stack.Pop();
                }
            }
        }
    }
}
