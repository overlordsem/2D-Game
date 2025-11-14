using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float patrolDistance = 3.0f; // Distance to patrol left and right
    public float speed = 2.0f;           // Speed of movement

    private Vector3 startPoint;          // Starting position
    private Vector3 endPoint;            // Ending position
    private Vector3 targetPoint;         // Current target point
    private bool movingRight = true;     // Flag to track direction

    void Start()
    {
        // Set the starting point based on the object's current position
        startPoint = transform.position;
        endPoint = startPoint + new Vector3(patrolDistance, 0, 0); // Calculate the endpoint
        targetPoint = endPoint; // Start by moving to the end point
    }

    void Update()
    {
        // Move towards the target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        // Check if the object has reached the target point
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            // Reverse direction
            movingRight = !movingRight;

            // Set the next target point based on the current direction
            if (movingRight)
            {
                targetPoint = endPoint; // Move to the right
            }
            else
            {
                targetPoint = startPoint; // Move to the left
            }
        }
    }
}