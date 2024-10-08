using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public enum NodeType
    {
        Mystery,
        Blank,
        Combat,
        Negotiation,
        Event,
        Shop,
        Pitstop,
        Miniboss,
        Boss
    }

    public class Node
    {
        NodeType nodeType;
        List<Node> prevNodes;
        List<Node> nextNodes;
        GameObject gameNode;

        public Node()
        {
            nodeType = NodeType.Blank;
            prevNodes = new List<Node>();
            nextNodes = new List<Node>();
        }

        public Node(NodeType type, List<Node> prev, List<Node> next)
        {
            nodeType = type;
            prevNodes = prev;
            nextNodes = next;
        }

        public void setRandomType()
        {
            int type = Random.Range(1, 7);

            switch (type)
            {
                case 1 : nodeType = NodeType.Blank;

                    break;
                
                case 2:
                    nodeType = NodeType.Combat;

                    break;

                case 3:
                    nodeType = NodeType.Negotiation;

                    break;

                case 4:
                    nodeType = NodeType.Event;

                    break;

                case 5:
                    nodeType = NodeType.Shop;

                    break;

                case 6:
                    nodeType = NodeType.Pitstop;

                    break;
            }
        }

        public NodeType getNodeType()
        {
            return nodeType;
        }

        public void setNodeType(NodeType type)
        {
            nodeType = type;
        }

        public List<Node> getNextNodes()
        {
            return nextNodes;
        }

        public void addNextNode(Node n)
        {
            if(!nextNodes.Contains(n))
            {
                nextNodes.Add(n);
            }  
        }

        public void removeNextNode(Node n)
        {
            nextNodes.Remove(n);
        }

        public void setNextNodes(List<Node> nodes)
        {
            nextNodes = nodes;
        }

        public List<Node> getPrevNodes()
        {
            return prevNodes;
        }

        public void addPrevNode(Node p)
        {
            if (!prevNodes.Contains(p))
            {
                prevNodes.Add(p);
            }
        }

        public void removePrevNode(Node p)
        {
            prevNodes.Remove(p);
        }

        public void setPrevNodes(List<Node> nodes)
        {
            prevNodes = nodes;
        }

        public GameObject getGameNode()
        {
            return gameNode;
        }

        public void setGameNode(GameObject n)
        {
            gameNode = n;
        }

        public void delete()
        {
            if(gameNode != null)
            {
                Object.Destroy(gameNode);
            }

            prevNodes.Clear();
            nextNodes.Clear();
        }
    }
}


