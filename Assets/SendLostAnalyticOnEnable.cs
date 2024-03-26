using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendLostAnalyticOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        AnalyticsManager.Instance.LostGame();
    }
}
