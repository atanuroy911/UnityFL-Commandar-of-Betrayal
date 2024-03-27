using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform destination;

    public bool isOrange;
    public float distance = 0.2f;


    void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("orange portal").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("blue portal").GetComponent<Transform>();
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Square"))
        {
            if (Vector2.Distance(transform.position, collision.transform.position) > distance)
            {
                collision.transform.position = new Vector2(destination.position.x, destination.position.y);
            }
        }
    }
}
