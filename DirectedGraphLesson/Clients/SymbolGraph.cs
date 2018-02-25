using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectedGraphLesson.Clients
{
    public class SymbolGraph
    {
        private List<string[]> _graphData;

        private DirectedGraph _graph;

        private Dictionary<string, int> _index;

        public SymbolGraph()
        {
            _graphData = new List<string[]>();
        }

        public void Insert(string[] vertices)
        {
            if (vertices == null || vertices.Length == 0)
                throw new ArgumentNullException();

            _graphData.Add(vertices);
        }

        public void Build()
        {
            if (_graphData.Count == 0)
                throw new InvalidOperationException();

            BuildIndex();
            BuildGraph();
        }

        public bool Contains(string vertex)
        {
            if (string.IsNullOrWhiteSpace(vertex))
                throw new ArgumentNullException();

            return _index.ContainsKey(vertex);
        }

        public int Index(string vertex)
        {
            if (string.IsNullOrWhiteSpace(vertex))
                throw new ArgumentNullException();

            return _index[vertex];
        }

        public string Name(int vertex)
        {
            var result = _index.FirstOrDefault(x => x.Value == vertex).Key;

            if (string.IsNullOrWhiteSpace(result))
                throw new InvalidOperationException();

            return result;
        }

        public DirectedGraph Graph()
        {
            return _graph;
        }

        private void BuildIndex()
        {
            _index = new Dictionary<string, int>();

            foreach (var row in _graphData)
            {
                for (var i = 0; i < row.Length; i++)
                {
                    if (!_index.ContainsKey(row[i]))
                        _index.Add(row[i], _index.Count);
                }
            }
        }

        private void BuildGraph()
        {
            _graph = new DirectedGraph(_index.Count);

            foreach (var row in _graphData)
            {
                var source = _index[row[0]];

                for (var i = 1; i < row.Length; i++)
                {
                    var destination = _index[row[i]];
                    _graph.InsertEdge(source, destination);
                }
            }
        }
    }
}