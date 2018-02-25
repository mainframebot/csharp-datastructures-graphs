using System.Collections.Generic;
using DirectedGraphLesson;
using DirectedGraphLesson.Clients;
using NUnit.Framework;

namespace DirectedGraphTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Testing()
        {
            var graph = new DirectedGraph(13);

            graph.InsertEdge(4, 2);
            graph.InsertEdge(2, 3);
            graph.InsertEdge(3, 2);
            graph.InsertEdge(6, 0);
            graph.InsertEdge(0, 1);
            graph.InsertEdge(2, 0);
            graph.InsertEdge(11, 12);
            graph.InsertEdge(12, 9);
            graph.InsertEdge(9, 10);
            graph.InsertEdge(9, 11);
            graph.InsertEdge(8, 9);
            graph.InsertEdge(10, 12);
            graph.InsertEdge(11, 4);
            graph.InsertEdge(4, 3);
            graph.InsertEdge(3, 5);
            graph.InsertEdge(7, 8);
            graph.InsertEdge(8, 7);
            graph.InsertEdge(5, 4);
            graph.InsertEdge(0, 5);
            graph.InsertEdge(6, 4);
            graph.InsertEdge(6, 9);
            graph.InsertEdge(7, 6);

            var vertexOutDegree = graph.VertexOutDegree(6);
            var vertexInDegre = graph.VertexInDegree(6);
            var graphReveresed = graph.Reverse();

            var depthFirstSearch = new DepthFirstSearch(graph, 0);
            var depthFirstSearchCount = depthFirstSearch.Count();

            var depthFirstSearchTest0 = depthFirstSearch.Marked(0);
            var depthFirstSearchTest1 = depthFirstSearch.Marked(1);
            var depthFirstSearchTest2 = depthFirstSearch.Marked(2);
            var depthFirstSearchTest3 = depthFirstSearch.Marked(3);
            var depthFirstSearchTest4 = depthFirstSearch.Marked(4);
            var depthFirstSearchTest5 = depthFirstSearch.Marked(5);
            var depthFirstSearchTest6 = depthFirstSearch.Marked(6);

            var depthFirstSearchTestConnected = depthFirstSearchCount == graph.Vertices ? "Connected" : "NOT Connected";

            var depthFirstPath = new DepthFirstPaths(graph, 0);
            var depthFirstPathTest = depthFirstPath.PathTo(2);

            var breadthFirstSearch = new BreadthFirstSearch(graph, 0);
            var breadthFirstSearchCount = breadthFirstSearch.Count();

            var breadthFirstSearchTest0 = breadthFirstSearch.Marked(0);
            var breadthFirstSearchTest1 = breadthFirstSearch.Marked(1);
            var breadthFirstSearchTest2 = breadthFirstSearch.Marked(2);
            var breadthFirstSearchTest3 = breadthFirstSearch.Marked(3);
            var breadthFirstSearchTest4 = breadthFirstSearch.Marked(4);
            var breadthFirstSearchTest5 = breadthFirstSearch.Marked(5);
            var breadthFirstSearchTest6 = breadthFirstSearch.Marked(6);

            var breadthFirstSearchTestConnected = breadthFirstSearchCount == graph.Vertices ? "Connected" : "NOT Connected";

            var breadthFirstPath = new BreadthFirstPaths(graph, 0);
            var breadthFirstPathTest = breadthFirstPath.PathTo(2);

            var depthFirstCycle = new DepthFirstCycle(graph);
            var depthFirstCycleTest0 = depthFirstCycle.HasCycle();
            var depthFirstCycleTest1 = depthFirstCycle.Cycle();

            var graph2 = new DirectedGraph(13);

            graph2.InsertEdge(2, 3);
            graph2.InsertEdge(0, 6);
            graph2.InsertEdge(0, 1);
            graph2.InsertEdge(2, 0);
            graph2.InsertEdge(11, 12);
            graph2.InsertEdge(9, 12);
            graph2.InsertEdge(9, 10);
            graph2.InsertEdge(9, 11);
            graph2.InsertEdge(3, 5);
            graph2.InsertEdge(8, 7);
            graph2.InsertEdge(5, 4);
            graph2.InsertEdge(0, 5);
            graph2.InsertEdge(6, 4);
            graph2.InsertEdge(6, 9);
            graph2.InsertEdge(7, 6);

            var depthFirstCycle2 = new DepthFirstCycle(graph2);
            var depthFirstCycle2Test0 = depthFirstCycle2.HasCycle();
            var depthFirstCycle2Test1 = depthFirstCycle2.Cycle();

            var depthFirstOrder = new DepthFirstOrder(graph2);

            var depthFirstOrderTest0 = depthFirstOrder.PreOrder();
            var depthFirstOrderTest1 = depthFirstOrder.PostOrder();
            var depthFirstOrderTest2 = depthFirstOrder.ReversePostOrder();

            var symbolGraph = new SymbolGraph();
            symbolGraph.Insert(new[] { "JFK", "MCO" });
            symbolGraph.Insert(new[] { "ORD", "DEN" });
            symbolGraph.Insert(new[] { "ORD", "HOU" });
            symbolGraph.Insert(new[] { "DFW", "PHX" });
            symbolGraph.Insert(new[] { "JFK", "ATL" });
            symbolGraph.Insert(new[] { "ORD", "DFW" });
            symbolGraph.Insert(new[] { "ORD", "PHX" });
            symbolGraph.Insert(new[] { "ATL", "HOU" });
            symbolGraph.Insert(new[] { "DEN", "PHX" });
            symbolGraph.Insert(new[] { "PHX", "LAX" });
            symbolGraph.Insert(new[] { "JFK", "ORD" });
            symbolGraph.Insert(new[] { "DEN", "LAS" });
            symbolGraph.Insert(new[] { "DFW", "HOU" });
            symbolGraph.Insert(new[] { "ORD", "ATL" });
            symbolGraph.Insert(new[] { "LAS", "LAX" });
            symbolGraph.Insert(new[] { "ATL", "MCO" });
            symbolGraph.Insert(new[] { "HOU", "MCO" });
            symbolGraph.Insert(new[] { "LAS", "PHX" });

            symbolGraph.Build();

            var symbolGraphTest0 = symbolGraph.Contains("LAS");
            var symbolGraphTest1 = symbolGraph.Contains("MOO");
            var symbolGraphTest2 = symbolGraph.Index("LAX");
            var symbolGraphTest3 = symbolGraph.Name(symbolGraphTest2);

            var symbolGraph2 = new SymbolGraph();
            symbolGraph2.Insert(new[] { "Algorithms", "Theoretical CS", "Databases", "Scientific Computing" });
            symbolGraph2.Insert(new[] { "Introduction to CS", "Advanced Programming", "Algorithms" });
            symbolGraph2.Insert(new[] { "Advanced Programming", "Scientific Computing" });
            symbolGraph2.Insert(new[] { "Scientific Computing", "Computational Biology" });
            symbolGraph2.Insert(new[] { "Theoretical CS", "Computational Biology", "Artificial Intelligence" });
            symbolGraph2.Insert(new[] { "Linear Algebra", "Theoretical CS" });
            symbolGraph2.Insert(new[] { "Calculus", "Linear Algebra" });
            symbolGraph2.Insert(new[] { "Artificial Intelligence", "Neural Networks", "Robotics", "Machine Learning" });
            symbolGraph2.Insert(new[] { "Machine Learning", "Neural Networks" });

            symbolGraph2.Build();

            var topologicalSort = new TopologicalSort(symbolGraph2.Graph());
            var topologicalSorted = new List<string>();

            foreach(var item in topologicalSort.Order)
                topologicalSorted.Add(symbolGraph2.Name(item));

            var depthFirstComponents = new DepthFirstComponents(graph);

            var depthFirstComponentsTest0 = depthFirstComponents.IsStronglyConnected(1, 7);
            var depthFirstComponentsTest1 = depthFirstComponents.IsStronglyConnected(0, 2);
            var depthFirstComponentsTest2 = depthFirstComponents.IsStronglyConnected(2, 7);
            var depthFirstComponentsTest3 = depthFirstComponents.IsStronglyConnected(9, 12);
            var depthFirstComponentsTest4 = depthFirstComponents.IsStronglyConnected(6, 8);
            var depthFirstComponentsTest5 = depthFirstComponents.IsStronglyConnected(7, 8);
        }
    }
}
