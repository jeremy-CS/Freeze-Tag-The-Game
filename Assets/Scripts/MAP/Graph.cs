using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    //List of nodes in the graph
    public List<Node> graphNodes;

    //Constructors for a graph
    public Graph() : this(null) { }
    public Graph(List<Node> NodeList)
    {
        if (NodeList == null)
            this.graphNodes = new List<Node>();
        else
            this.graphNodes = NodeList;
    }

    //Adding nodes to the graph
    public void AddNode(Vector3 aPos)
    {
        graphNodes.Add(new Node(aPos));
    }

    public void AddNode(Node node)
    {
        graphNodes.Add(node);
    }

    //Adding undirected edges to nodes
    public void AddUndirectedEdge(Node from, Node to)
    {
        from.Neighbors.Add(to);
        to.Neighbors.Add(from);
    }
}

public class Node
{
    //Member variables
    public Vector3 Position;
    public List<Node> Neighbors;
    public Node parent;

    //Node Cost variables
    public float gCost = 0; //Distance from current node to the goal node
    public float hCost = 0; //Heuristic value of a node
    public float FCost { get { return gCost + hCost; } } //Total cost of a node

    //Constructors for a base node
    public Node() { }
    public Node(Vector3 aPos) : this(aPos, null) { }
    public Node(Vector3 aPos, List<Node> neighbors)
    {
        if (neighbors == null)
            Neighbors = new List<Node>();
        else
            Neighbors = neighbors;

        this.Position = aPos;
    }
}
