using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    public Transform[] waypointTargets;
    public float speed = 2f;
    private int waypointIndex = 0;
    private Quaternion originalRotation; 

    void Start()
    {
       
        transform.position = waypointTargets[waypointIndex].position;
       
        originalRotation = transform.rotation;
    }

    void Update()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, waypointTargets[waypointIndex].position, step);

       
        if (Vector3.Distance(transform.position, waypointTargets[waypointIndex].position) < 0.1f)
        {
           
            transform.rotation = originalRotation;

            
            transform.Rotate(0, 180, 0, Space.Self);

           
            waypointIndex++;

            
            if (waypointIndex >= waypointTargets.Length)
            {
                waypointIndex = 0;
            }

         
            originalRotation = transform.rotation;
        }
    }
}
