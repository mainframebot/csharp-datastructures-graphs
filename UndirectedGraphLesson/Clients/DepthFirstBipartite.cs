using System;

namespace UndirectedGraphLesson.Clients
{
    public class DepthFirstBipartite
    {
        private UndirectedGraph _graph;

        private bool[] _marked;

        private bool[] _color;

        private bool _isTwoColorable;

        public DepthFirstBipartite(UndirectedGraph graph)
        {
            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            _graph = graph;
            _marked = new bool[graph.Vertices];
            _color = new bool[graph.Vertices];
            _isTwoColorable = true;

            for (int i = 0; i < graph.Vertices; i++)
            {
                if (!_marked[i])
                    Search(i);
            }
        }

        public bool IsBipartite()
        {
            return _isTwoColorable;
        }

        private void Search(int vertex)
        {
            _marked[vertex] = true;

            foreach (var adjVertex in _graph.VertexAdjacency(vertex))
            {
                if (!_marked[adjVertex])
                {
                    _color[adjVertex] = !_color[vertex];
                    Search(adjVertex);
                }
                else if(_color[adjVertex] == _color[vertex])
                {
                    _isTwoColorable = false;
                }
                    
            }
        }
    }
}
