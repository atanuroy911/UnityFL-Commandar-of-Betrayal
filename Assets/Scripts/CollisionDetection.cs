//using UnityEngine;

//public class CollisionDetection : MonoBehaviour
//{

//    public Canvas canvasToEnable;
//    void Start()
//    {

//    }

//    void Update()
//    {

//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.CompareTag("Square"))
//        {
//            Debug.Log("Destroying other object");
//            Destroy(other.gameObject);

//            if (canvasToEnable != null)
//            {
//                canvasToEnable.enabled = true;
//            }
//            else
//            {
//                Debug.LogWarning("Canvas to enable is not assigned.");
//            }
//        }
//    }
//}
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject objectToEnable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            Debug.Log("Destroying other object");
            Destroy(other.gameObject);

            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Banner canvas is not assigned.");
            }
        }
    }
}
