using System;

namespace DirectedGraphLesson.Clients
{
    public class DepthFirstComponents
    {
        private DirectedGraph _graph;

        private bool[] _marked;

        private int[] _id;

        private int[] _size;

        private int _count;

        public DepthFirstComponents(DirectedGraph graph)
        {
            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            _graph = graph;
            _marked = new bool[graph.Vertices];
            _id = new int[graph.Vertices];
            _size = new int[graph.Vertices];
            _count = 0;

            IdentifyConnectedComponents();
        }

        public int Count()
        {
            return _count;
        }

        public int Id(int vertex)
        {
            _graph.ValidateVertex(vertex);

            return _id[vertex];
        }

        public int Size(int vertex)
        {
            _graph.ValidateVertex(vertex);

            return _size[_id[vertex]];
        }

        public bool IsStronglyConnected(int source, int destination)
        {
            return _id[source] == _id[destination];
        }

        private void IdentifyConnectedComponents()
        {
            var order = new DepthFirstOrder(_graph.Reverse());

            foreach (var vertex in order.ReversePostOrder())
            {
                if (!_marked[vertex])
                {
                    Search(vertex);
                    _count++;
                }
            }
        }

        private void Search(int vertex)
        {
            var currentComponent = _count;

            _marked[vertex] = true;
            _id[vertex] = currentComponent;

            _size[currentComponent]++;

            foreach (var adjVertex in _graph.VertexAdjacency(vertex))
            {
                if (!_marked[adjVertex])
                    Search(adjVertex);
            }
        }
    }
}
