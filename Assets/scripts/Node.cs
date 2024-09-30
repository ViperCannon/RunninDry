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
        private NodeType nodeType;
        private List<Node> prevNodes;
        private List<Node> nextNodes;
        private int height;

        public Node()
        {
            height = -1;
            nodeType = NodeType.Blank;
            prevNodes = new List<Node>();
            nextNodes = new List<Node>();

        }

        public Node(int h)
        {
            height = h;
            nodeType = NodeType.Blank;
            prevNodes = new List<Node>();
            nextNodes = new List<Node>();
        }

        public Node(NodeType type, List<Node> prev, List<Node> next, int h)
        {
            nodeType = type;
            prevNodes = prev;
            nextNodes = next;
            height = h;
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

        public int getHeight()
        {
            return height;
        }

        public void setHeight(int h)
        {
            height = h;
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
            nextNodes.Add(n);
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
            prevNodes.Add(p);
        }

        public void removePrevNode(Node p)
        {
            prevNodes.Remove(p);
        }

        public void setPrevNodes(List<Node> nodes)
        {
            prevNodes = nodes;
        }
    }
}


