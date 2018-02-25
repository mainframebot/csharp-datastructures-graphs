using NUnit.Framework;
using UndirectedGraphLesson;
using UndirectedGraphLesson.Clients;

namespace UndirectedGraphTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Testing()
        {
            var graph = new UndirectedGraph(13);

            graph.InsertEdge(0, 5);
            graph.InsertEdge(4, 3);
            graph.InsertEdge(0, 1);
            graph.InsertEdge(9, 12);
            graph.InsertEdge(6, 4);
            graph.InsertEdge(5, 4);
            graph.InsertEdge(0, 2);
            graph.InsertEdge(11, 12);
            graph.InsertEdge(9, 10);
            graph.InsertEdge(0, 6);
            graph.InsertEdge(7, 8);
            graph.InsertEdge(9, 11);
            graph.InsertEdge(5, 3);

            var degree = graph.VertexDegree(5);
            var maxDegree = graph.GraphMaxVertexDegree();
            var avgDegree = graph.GraphAverageVertexDegree();
            var selfLoops = graph.GraphNumberOfSelfLoops();

            var graph2 = new UndirectedGraph(6);

            graph2.InsertEdge(0, 5);
            graph2.InsertEdge(2, 4);
            graph2.InsertEdge(2, 3);
            graph2.InsertEdge(1, 2);
            graph2.InsertEdge(0, 1);
            graph2.InsertEdge(3, 4);
            graph2.InsertEdge(3, 5);
            graph2.InsertEdge(0, 2);

            var depthFirstSearch = new DepthFirstSearch(graph2, 0);
            var depthFirstSearchCount = depthFirstSearch.Count();

            var depthFirstSearchTest0 = depthFirstSearch.Marked(0);
            var depthFirstSearchTest1 = depthFirstSearch.Marked(1);
            var depthFirstSearchTest2 = depthFirstSearch.Marked(2);
            var depthFirstSearchTest3 = depthFirstSearch.Marked(3);
            var depthFirstSearchTest4 = depthFirstSearch.Marked(4);
            var depthFirstSearchTest5 = depthFirstSearch.Marked(5);

            var depthFirstSearchNonRecursive = new DepthFirstSearchNonRecursive(graph2, 0);
            var depthFirstSearchNonRecursiveCount = depthFirstSearchNonRecursive.Count();

            var depthFirstSearchNonRecursiveTest0 = depthFirstSearchNonRecursive.Marked(0);
            var depthFirstSearchNonRecursiveTest1 = depthFirstSearchNonRecursive.Marked(1);
            var depthFirstSearchNonRecursiveTest2 = depthFirstSearchNonRecursive.Marked(2);
            var depthFirstSearchNonRecursiveTest3 = depthFirstSearchNonRecursive.Marked(3);
            var depthFirstSearchNonRecursiveTest4 = depthFirstSearchNonRecursive.Marked(4);
            var depthFirstSearchNonRecursiveTest5 = depthFirstSearchNonRecursive.Marked(5);

            var depthFirstSearchTestConnected = depthFirstSearchCount == graph2.Vertices ? "Connected" : "NOT Connected";

            var depthFirstPath = new DepthFirstPaths(graph2, 0);
            var depthFirstPathTest = depthFirstPath.PathTo(4);

            var breadthFirstSearch = new BreadthFirstSearch(graph2, 0);
            var breadthFirstSearchCount = breadthFirstSearch.Count();

            var breadthFirstSearchTest0 = breadthFirstSearch.Marked(0);
            var breadthFirstSearchTest1 = breadthFirstSearch.Marked(1);
            var breadthFirstSearchTest2 = breadthFirstSearch.Marked(2);
            var breadthFirstSearchTest3 = breadthFirstSearch.Marked(3);
            var breadthFirstSearchTest4 = breadthFirstSearch.Marked(4);
            var breadthFirstSearchTest5 = breadthFirstSearch.Marked(5);

            var breadthFirstSearchTestConnected = breadthFirstSearchCount == graph2.Vertices ? "Connected" : "NOT Connected";

            var breadthFirstPath = new BreadthFirstPaths(graph2, 0);
            var breadthFirstPathTest = breadthFirstPath.PathTo(4);

            var depthFirstComponents = new DepthFirstComponents(graph);

            var depthFirstComponentsTest0 = depthFirstComponents.IsConnected(0, 7);
            var depthFirstComponentsTest1 = depthFirstComponents.IsConnected(0, 6);
            var depthFirstComponentsTest2 = depthFirstComponents.IsConnected(7, 9);
            var depthFirstComponentsTest3 = depthFirstComponents.IsConnected(7, 8);
            var depthFirstComponentsTest4 = depthFirstComponents.IsConnected(9, 0);
            var depthFirstComponentsTest5 = depthFirstComponents.IsConnected(9, 12);

            var depthFirstCycle = new DepthFirstCycle(graph);
            var depthFirstCycleTest = depthFirstCycle.HasCycle();

            var depthFirstBipartite = new DepthFirstBipartite(graph);
            var depthFirstBipartiteTest = depthFirstBipartite.IsBipartite();

            var symbolGraph = new SymbolGraph();
            symbolGraph.Insert(new []{ "JFK", "MCO"});
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

            var symbolGraph2 = new SymbolGraphDegreesOfSeparation();
            symbolGraph2.Insert(new[] { "JFK", "MCO" });
            symbolGraph2.Insert(new[] { "ORD", "DEN" });
            symbolGraph2.Insert(new[] { "ORD", "HOU" });
            symbolGraph2.Insert(new[] { "DFW", "PHX" });
            symbolGraph2.Insert(new[] { "JFK", "ATL" });
            symbolGraph2.Insert(new[] { "ORD", "DFW" });
            symbolGraph2.Insert(new[] { "ORD", "PHX" });
            symbolGraph2.Insert(new[] { "ATL", "HOU" });
            symbolGraph2.Insert(new[] { "DEN", "PHX" });
            symbolGraph2.Insert(new[] { "PHX", "LAX" });
            symbolGraph2.Insert(new[] { "JFK", "ORD" });
            symbolGraph2.Insert(new[] { "DEN", "LAS" });
            symbolGraph2.Insert(new[] { "DFW", "HOU" });
            symbolGraph2.Insert(new[] { "ORD", "ATL" });
            symbolGraph2.Insert(new[] { "LAS", "LAX" });
            symbolGraph2.Insert(new[] { "ATL", "MCO" });
            symbolGraph2.Insert(new[] { "HOU", "MCO" });
            symbolGraph2.Insert(new[] { "LAS", "PHX" });
            symbolGraph2.Insert(new[] { "ZZZ", "YYY" });

            symbolGraph2.Build();

            var symbolGraph2Test0 = symbolGraph2.IsConnected("JFK", "LAS");
            var symbolGraph2Test1 = symbolGraph2.IsConnected("JFK", "DFW");
            var symbolGraph2Test2 = symbolGraph2.IsConnected("HOU", "YYY");
        }
    }
}
