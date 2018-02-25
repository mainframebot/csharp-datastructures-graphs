using System;
using System.Collections.Generic;

namespace DirectedGraphLesson.Clients
{
    public class TopologicalSort
    {
        public IEnumerable<int> Order { get; }

        public bool IsDirectedAcyclicGraph
        {
            get { return Order == null; }
        }

        public TopologicalSort(DirectedGraph graph)
        {
            if (graph == null || graph.Vertices == 0)
                throw new ArgumentException();

            var graphCycle = new DepthFirstCycle(graph);

            if (graphCycle.HasCycle())
                throw new InvalidOperationException();

            var graphOrder = new DepthFirstOrder(graph);
            Order = graphOrder.ReversePostOrder();
        }
    }
}
