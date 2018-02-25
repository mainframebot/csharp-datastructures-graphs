using System;
using System.Collections.Generic;

namespace DirectedGraphLesson.Clients
{
    public class DepthFirstOrder
    {
        private DirectedGraph _graph;

        private bool[] _marked;

        private Queue<int> _preOrder;

        private Queue<int> _postOrder;

        private Stack<int> _reversePostOrder;

        public DepthFirstOrder(DirectedGraph graph)
        {
            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            _graph = graph;
            _marked = new bool[graph.Vertices];
            _preOrder = new Queue<int>();
            _postOrder = new Queue<int>();
            _reversePostOrder = new Stack<int>();

            for(var i = 0; i < graph.Vertices; i++)
            {
                if (!_marked[i])
                    Search(i);
            }
        }

        public IEnumerable<int> PreOrder()
        {
            return _preOrder;
        }

        public IEnumerable<int> PostOrder()
        {
            return _postOrder;
        }

        public IEnumerable<int> ReversePostOrder()
        {
            return _reversePostOrder;
        } 

        private void Search(int vertex)
        {
            _preOrder.Enqueue(vertex);

            _marked[vertex] = true;

            foreach (var adjVertex in _graph.VertexAdjacency(vertex))
            {
                if (!_marked[adjVertex])
                    Search(adjVertex);
            }

            _postOrder.Enqueue(vertex);
            _reversePostOrder.Push(vertex);
        }
    }
}
