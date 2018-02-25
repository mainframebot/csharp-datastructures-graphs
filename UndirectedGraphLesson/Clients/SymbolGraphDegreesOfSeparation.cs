using System;
using System.Collections.Generic;

namespace UndirectedGraphLesson.Clients
{
    public class SymbolGraphDegreesOfSeparation
    {
        private SymbolGraph _symbolGraph;

        public SymbolGraphDegreesOfSeparation()
        {
            _symbolGraph = new SymbolGraph();
        }

        public void Insert(string[] vertices)
        {
            _symbolGraph.Insert(vertices);
        }

        public void Build()
        {
            _symbolGraph.Build();
        }

        public Result IsConnected(string source, string destination)
        {
            if(string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination))
                throw new ArgumentNullException();

            if(!_symbolGraph.Contains(source) || !_symbolGraph.Contains(destination))
                throw new InvalidOperationException();

            var result = new Result();

            var vertexSource = _symbolGraph.Index(source);
            var vertexDestination = _symbolGraph.Index(destination);

            var search = new BreadthFirstPaths(_symbolGraph.Graph(), vertexSource);

            if (search.HasPathTo(vertexDestination))
            {
                result.IsConnected = true;
                result.Connected = new List<string>();

                foreach (var path in search.PathTo(vertexDestination))
                {
                    result.Connected.Add(_symbolGraph.Name(path));
                }
            }

            return result;
        }
    }

    public class Result
    {
        public bool IsConnected { get; set; }

        public List<string> Connected { get; set; } 
    }
}
