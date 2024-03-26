using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (!other.attachedRigidbody)
        {
            
            MoveAwayFromCollider(other.transform);
        }
    }

    
    private void MoveAwayFromCollider(Transform objTransform)
    {
       
        Vector2 direction = (objTransform.position - transform.position).normalized;
        float distance = 1.0f; 
        Vector2 newPosition = (Vector2)objTransform.position + direction * distance;

      
        objTransform.position = newPosition;
    }
}

