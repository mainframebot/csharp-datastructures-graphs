using System;

namespace UndirectedGraphLesson.Clients
{
    public class DepthFirstCycle
    {
        private UndirectedGraph _graph;

        private bool[] _marked;

        private bool _hasCycle;

        public DepthFirstCycle(UndirectedGraph graph)
        {
            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            _graph = graph;
            _marked = new bool[graph.Vertices];
            _hasCycle = false;

            for (var i = 0; i < graph.Vertices; i++)
            {
                if(!_marked[i])
                    Search(i, i);
            }
        }

        public bool HasCycle()
        {
            return _hasCycle;
        }

        private void Search(int vertex, int previous)
        {
            _marked[vertex] = true;

            foreach (var adjVertex in _graph.VertexAdjacency(vertex))
            {
                if (!_marked[adjVertex])
                {
                    Search(adjVertex, vertex);
                }
                else if (adjVertex != previous)
                {
                    _hasCycle = true;
                }
            }
        }
    }
}
