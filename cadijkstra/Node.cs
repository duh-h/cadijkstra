using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    public string Label { get; }
    public Node(string label)
    {
        Label = label;
    }

    readonly List<Edge> _edges = new List<Edge>();
    public IEnumerable<Edge> Edges => _edges;

    public IEnumerable<NeighborhoodInfo> Neighbors =>
        from edge in Edges
        select new NeighborhoodInfo(
            edge.Node1 == this ? edge.Node2 : edge.Node1,
            edge.Value
        );

    private void Assign(Edge edge)
    {
        _edges.Add(edge);
    }

    public void ConnectTo(Node other, int connectionValue)
    {
        var edge = Edge.Create(connectionValue, this, other);
        Assign(edge);
    }

    public class NeighborhoodInfo
    {
        public Node Node { get; }
        public int WeightToNode { get; }

        public NeighborhoodInfo(Node node, int weightToNode)
        {
            Node = node;
            WeightToNode = weightToNode;
        }
    }

    public class Edge
    {
        public int Value { get; }
        public Node Node1 { get; }
        public Node Node2 { get; }

        private Edge(int value, Node node1, Node node2)
        {
            if (value <= 0 || node1 == node2)
            {
                throw new ArgumentException("Edge value needs to be positive and connect different nodes.");
            }
            Value = value;
            Node1 = node1;
            Node2 = node2;
        }

        public static Edge Create(int value, Node node1, Node node2)
        {
            return new Edge(value, node1, node2);
        }
    }
}