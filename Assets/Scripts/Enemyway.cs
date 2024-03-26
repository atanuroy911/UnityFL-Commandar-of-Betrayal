using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    private int waypointIndex = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned.");
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].position,
            moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].position)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length; 
        }
    }
}
