using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node[] connectsTo;

    private void OnDrawGizmos()
    {
        foreach(Node n in connectsTo)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
        }
    }
}
