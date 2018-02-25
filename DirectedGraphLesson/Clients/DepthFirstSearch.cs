using System;

namespace DirectedGraphLesson.Clients
{
    public class DepthFirstSearch
    {
        private DirectedGraph _graph;

        private bool[] _marked;

        private int _count;

        public DepthFirstSearch(DirectedGraph graph, int source)
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
            _count++;
            _marked[vertex] = true;

            foreach (var adjVertex in _graph.VertexAdjacency(vertex))
            {
                if (!_marked[adjVertex])
                    Search(adjVertex);
            }
        }
    }
}
