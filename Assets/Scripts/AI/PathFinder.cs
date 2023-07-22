using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    MapGenerator MapGen;

    // Start is called before the first frame update
    void Start()
    {
        MapGen = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>();
    }

    //A* Pathfinding
    public void AStar(Node start, Node goal)
    {
        //Initialize Open/Closed Lists
        List<Node> open = new List<Node>();
        HashSet<Node> closed = new HashSet<Node>();

        //Add start node to open list
        open.Add(start);

        //Loop through every neighbors to find the goal
        while (open.Count > 0)
        {
            Node currentNode = open[0];

            //Find node with lowest fCost in the open list
            for (int i=1; i<open.Count; i++)
            {
                if (open[i].FCost < currentNode.FCost || (open[i].FCost == currentNode.FCost && open[i].hCost < currentNode.hCost))
                {
                    currentNode = open[i];
                }
            }

            //Remove current node from open list and add it to closed list
            open.Remove(currentNode);
            closed.Add(currentNode);

            //Check if goal node is reached
            if (currentNode == goal)
            {
                RetracePath(start, goal);
                return;//Goal found
            }

            //Get neighbours of current node and add them to open list
            foreach (Node neighbour in currentNode.Neighbors)
            {
                //Skip neighbour if already in closed list
                if (closed.Contains(neighbour)) continue;

                //Calculate cost of neighbours
                float newGCost = currentNode.gCost + cost(currentNode.Position, neighbour.Position);

                //If new cost to node is lower or node is not in open list, add it, plus instantiate new costs
                if (newGCost < neighbour.gCost || !open.Contains(neighbour))
                {
                    neighbour.gCost = newGCost;
                    neighbour.hCost = cost(neighbour.Position, goal.Position);
                    neighbour.parent = currentNode;

                    if (!open.Contains(neighbour))
                        open.Add(neighbour);
                }
            }    
        }
    }

    //Cost Calculation (Weights/Heuristics)
    public float cost(Vector3 a, Vector3 b)
    {
        return Mathf.Abs((a.x - b.x)*(a.x - b.x)) + Mathf.Abs((a.z - b.z)*(a.z - b.z));
    }

    //Get path from end node to root node
    public void RetracePath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        Node currentNode = end;

        //Add all nodes to a list
        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(start);

        //Reverse list to get path from start to end node
        path.Reverse();
        MapGen.path = path;
    }
}