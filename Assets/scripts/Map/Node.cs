using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Button nodeButton;

        bool completed;

        public Node()
        {
            nodeType = NodeType.Blank;
            prevNodes = new List<Node>();
            nextNodes = new List<Node>();
            completed = false;
        }

        public Node(NodeType type, List<Node> prev, List<Node> next)
        {
            nodeType = type;
            prevNodes = prev;
            nextNodes = next;
            completed = false;
        }

        public void SetRandomType()
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

        public NodeType GetNodeType()
        {
            return nodeType;
        }

        public void SetNodeType(NodeType type)
        {
            nodeType = type;
        }

        public List<Node> GetNextNodes()
        {
            return nextNodes;
        }

        public void AddNextNode(Node n)
        {
            if(!nextNodes.Contains(n))
            {
                nextNodes.Add(n);
            }  
        }

        public void RemoveNextNode(Node n)
        {
            nextNodes.Remove(n);
        }

        public void SetNextNodes(List<Node> nodes)
        {
            nextNodes = nodes;
        }

        public List<Node> GetPrevNodes()
        {
            return prevNodes;
        }

        public void AddPrevNode(Node p)
        {
            if (!prevNodes.Contains(p))
            {
                prevNodes.Add(p);
            }
        }

        public void RemovePrevNode(Node p)
        {
            prevNodes.Remove(p);
        }

        public void SetPrevNodes(List<Node> nodes)
        {
            prevNodes = nodes;
        }

        public GameObject GetGameNode()
        {
            return gameNode;
        }

        public void SetGameNode(GameObject n)
        {
            gameNode = n;
            nodeButton = gameNode.GetComponentInChildren<Button>();
        }

        public Button GetNodeButton()
        {
            return nodeButton;
        }

        public bool IsCompleted()
        {
            return completed;
        }

        public void Complete()
        {
            if (!completed)
            {
                completed = true;

                nodeButton.enabled = false;

                foreach (Node n in nextNodes)
                {
                    n.Activate();
                }
            }
        }

        public void Activate()
        {
            if (nodeButton != null)
            {
                nodeButton.interactable = true;
                if(nodeType != NodeType.Boss)
                {
                    gameNode.GetComponentInChildren<NodeButtonFunction>().StartPulse();
                }
            }
        }

        public void Deactivate()
        {
            nodeButton.interactable = false;
        }

        public void Delete()
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


