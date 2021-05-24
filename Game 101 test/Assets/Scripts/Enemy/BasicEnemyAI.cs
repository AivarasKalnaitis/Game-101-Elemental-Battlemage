using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    public List<Node> AllNodes = new List<Node>();
    public float minDistance;
    public float maxDistance;

    public Node ClosestNode;
    public Node TargetNode;

    public Transform Target;
    public GameObject PlayerGO;
    public List<Node> Path;
    public bool PleaseFindPath = false;
    public EnemyMovement movObject;

    void Awake()
    {
        movObject = new EnemyMovement();
        movObject = GetComponent<EnemyMovement>();
        AllNodes = FindObjectsOfType<Node>().ToList();
        Invoke("FindPathTimed", 0f);
    }


    void Update()
    {
        if (PleaseFindPath)
        {
            FindPath();
            PleaseFindPath = false;
        }
        //movObject.jumpPress = true;

        if (!GetClosestNodeTo(Target).Equals(TargetNode))
        {
            FindPath();
        }

        if (Path.Count > 0)
        {
            MoveTowardsPath();
        }

        if (Path.Count == 0)
        {
            Path.Add(PlayerGO.transform.GetComponent<Node>());
        }

//        void FindPathTimed()
//        {
//            //Invoke("FindPathTimed", 1f);
//            FindPath();
//
//        }

        Node GetClosestNodeTo(Transform t)
        {
            Node fNode = null;

            float minDistance = Mathf.Infinity;
            foreach (var node in AllNodes)
            {

                float distance = (node.transform.position - t.position).sqrMagnitude;
                if (distance < minDistance)
                {
                    float testDist = Mathf.Abs(node.transform.position.y - t.position.y);
                    //float  testDist = 0f;
                    if (testDist < 1)
                    {
                        minDistance = distance;
                        fNode = node;
                    }
                }
            }


            return fNode;
        }

        void FindPath()
        {
            Path.Clear();

            TargetNode = GetClosestNodeTo(Target);
            ClosestNode = GetClosestNodeTo(transform);

            if (TargetNode == null || ClosestNode == null)
            {
                return;
            }

            HashSet<Node> VisitedNodes = new HashSet<Node>();
            Queue<Node> Q = new Queue<Node>();
            Dictionary<Node, Node> nodeAndParent = new Dictionary<Node, Node>();

            Q.Enqueue(ClosestNode);

            while (Q.Count > 0)
            {
                Node n = Q.Dequeue();
                if (n.Equals(TargetNode))
                {
                    MakePath(nodeAndParent);
                    return;
                }

                foreach (var node in n.connectedTo)
                {
                    if (!VisitedNodes.Contains(node))
                    {
                        VisitedNodes.Add(node);
                        nodeAndParent.Add(node, n);
                        Q.Enqueue(node);
                    }
                }
            }

            //Path.Add(PlayerGO.transform.Find("Node").GetComponent<Node>());
        Path[0] = PlayerGO.GetComponent<PlayerMovement>().playerNode;
        }


        void MakePath(Dictionary<Node, Node> nap)
        {
            if (nap.Count > 0)
            {
                if (nap.ContainsKey(TargetNode) && nap.ContainsValue(ClosestNode))
                {
                    Node cNode = TargetNode;
                    while (cNode != ClosestNode)
                    {
                        Path.Add(cNode);
                        cNode = nap[cNode];

                    }

                    Path.Add(ClosestNode);
                    Path.Add(PlayerGO.GetComponent<Node>());

                    Path.Reverse();
                }
            }
        }

        void MoveTowardsPath()
        {
            movObject.HorizontalMov(0);
            movObject.jumpPress = false;
            var currentNode = Path.First();
            if (Path.Count > 0)
            {

                var xMag = Mathf.Abs(currentNode.transform.position.x - transform.position.x);
                var yMag = Mathf.Abs(currentNode.transform.position.y - transform.position.y);

                if (currentNode && xMag >= minDistance && yMag <= maxDistance)
                {
                    if (transform.position.x > currentNode.transform.position.x)
                    {
                        movObject.HorizontalMov(-1);
                    }

                    if (transform.position.x < currentNode.transform.position.x)
                    {
                        movObject.HorizontalMov(1);
                    }

                    if (transform.position.y < currentNode.transform.position.y && (yMag > minDistance))
                    {
                        movObject.jumpPress = true;
                    }
                }
                else
                {
                    if (Path.Count > 1)
                    {
                        Path.Remove(Path.First());
                    }

                    if (Path.First() == TargetNode &&
                        Mathf.Abs(Vector2.Distance(currentNode.transform.position, transform.position)) < minDistance)
                    {
                        if (Path.Count != 0)
                        {
                            movObject.FireAway();
                        }

                        Path.Clear();
                        // Path = new List<Node>();
                    }
                }

            }


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
        }
    }
}
