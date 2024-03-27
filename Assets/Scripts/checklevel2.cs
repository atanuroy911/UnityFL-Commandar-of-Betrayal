using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checklevel2 : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToEnableonlose;

   
    public GameObject[] objectsToDestroyOnWin;
    public GameObject[] objectsToDestroyOnLose;

    CoinCounter c;

    private void Start()
    {
        c = FindObjectOfType<CoinCounter>();
        if (c == null)
        {
            Debug.LogWarning("CoinCounter script not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            Debug.Log("Destroying other object");
            if (c != null)
            {
                if (c.coin == 3)
                {
                    objectToEnable.SetActive(true);
                    AnalyticsManager.Instance.WonGame();

                  
                    foreach (GameObject obj in objectsToDestroyOnWin)
                    {
                        Destroy(obj);
                    }
                }
                else
                {
                    objectToEnableonlose.SetActive(true);

                    
                    foreach (GameObject obj in objectsToDestroyOnLose)
                    {
                        Destroy(obj);
                    }
                }
            }
            else
            {
                objectToEnableonlose.SetActive(true);
                Debug.LogWarning("CoinCounter script is not assigned.");
            }
        }
    }
}
