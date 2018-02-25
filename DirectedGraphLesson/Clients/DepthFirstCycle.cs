using System;
using System.Collections.Generic;

namespace DirectedGraphLesson.Clients
{
    public class DepthFirstCycle
    {
        private DirectedGraph _graph;

        private bool[] _marked;

        private int[] _edgeTo;

        private Stack<int> _cycle;

        private bool[] _onStack;

        public DepthFirstCycle(DirectedGraph graph)
        {
            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            _graph = graph;
            _marked = new bool[graph.Vertices];
            _edgeTo = new int[graph.Vertices];
            _onStack = new bool[graph.Vertices];

            for (var i = 0; i < graph.Vertices; i++)
            {
                if (!_marked[i] && _cycle == null)
                    Search(i);
            }
        }

        public bool HasCycle()
        {
            return _cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return _cycle;
        } 

        private void Search(int vertex)
        {
            _marked[vertex] = true;
            _onStack[vertex] = true;

            foreach (var adjVertex in _graph.VertexAdjacency(vertex))
            {
                if (_cycle != null)
                    return;

                if (!_marked[adjVertex])
                {
                    _edgeTo[adjVertex] = vertex;
                    Search(adjVertex);
                }
                else if (_onStack[adjVertex])
                {
                    _cycle = new Stack<int>();

                    for(int i = vertex; i != adjVertex; i = _edgeTo[i])
                        _cycle.Push(i);

                    _cycle.Push(adjVertex);
                    _cycle.Push(vertex);
                }
            }

            _onStack[vertex] = false;
        }
    }
}
