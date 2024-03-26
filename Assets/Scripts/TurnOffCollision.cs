using System.Collections;
using UnityEngine;

public class TurnOffCollision : MonoBehaviour
{
    public KeyCode turnOffCollisionKey = KeyCode.T;

    public Collider2D playerCollider;

    private bool collisionTurnedOff = false;

    private bool featureActivated = false;

    void Update()
    {
        if (!featureActivated && Input.GetKeyDown(turnOffCollisionKey))
        {
            ActivateFeature();
        }
    }

    private void ActivateFeature()
    {
        SetCollisionState(true);

        StartCoroutine(RevertCollisionStateAfterDelay(3f));

        featureActivated = true;
    }

    private void SetCollisionState(bool state)
    {
        if (playerCollider != null)
        {
            playerCollider.enabled = !state;
            collisionTurnedOff = state;
        }
        else
        {
            Debug.LogWarning("Player collider is not assigned.");
        }
    }

    private IEnumerator RevertCollisionStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SetCollisionState(false);
    }
}
