using System.Collections;
using UnityEngine;

public class FOVEnemyRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
        StartCoroutine(RotateAndBack());
    }

    IEnumerator RotateAndBack()
    {
        while (true)
        {
            Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, 90); 
            Quaternion originalRotationInverse = Quaternion.Inverse(originalRotation);

            
            while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f); 

          
            while (Quaternion.Angle(transform.rotation, originalRotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f); 
        }
    }
}
