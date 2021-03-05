using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : Seek
{
    public GameObject[] path;

    float closeEnoughRadius = 0.5f;

    int currWayPtNdx = 0;

    public override SteeringOutput getSteering()
    {
        if(target == null)
        {
            int closestWayPtNdx = 0;
            float closestDistance = float.PositiveInfinity;
            
            for(int i= 0; i < path.Length; i++)
            {
                GameObject wayPt = path[i];

                float wayPtDistance = (character.transform.position - wayPt.transform.position).magnitude;

                if(wayPtDistance < closestDistance)
                {
                    closestDistance = wayPtDistance;
                    closestWayPtNdx = i;
                }
            }

            target = path[closestWayPtNdx].gameObject;
        }

        float targetDistance = (character.transform.position - target.transform.position).magnitude;

        if(targetDistance < closeEnoughRadius)
        {
            currWayPtNdx = (currWayPtNdx + 1) % path.Length;
            target = path[currWayPtNdx].gameObject;
        }

        return base.getSteering();
    }

}
