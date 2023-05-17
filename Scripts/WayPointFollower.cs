using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int wayPointIndex = 0;

    [SerializeField] float speed = 1f;
    void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[wayPointIndex].transform.position)<.1f)
        {
            wayPointIndex++;
            if(wayPointIndex>=waypoints.Length)
            {
                wayPointIndex=0;
            }
        }


        transform.position = Vector3.MoveTowards(transform.position, waypoints[wayPointIndex].transform.position, speed*Time.deltaTime);
    }
}
