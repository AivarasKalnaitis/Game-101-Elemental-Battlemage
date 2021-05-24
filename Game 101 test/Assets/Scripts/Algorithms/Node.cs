using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public  List<Node> connectedTo;

    public void OnDrawGizmos()
    {
        //Vector3 size = new Vector3(1f, 0.5f, 1f);
        Gizmos.DrawSphere(transform.position, 0.2f);

        foreach (var node in connectedTo)
        {   
            //Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }
}
