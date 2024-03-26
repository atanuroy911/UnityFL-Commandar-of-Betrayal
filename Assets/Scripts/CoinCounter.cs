using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CoinCounter : MonoBehaviour
{
    public int coin = 0;
    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Reward")
        {
            coin++;
            textCoins.text = coin.ToString();
            AnalyticsManager.Instance.DiamondCollected();
            Destroy(other.gameObject);
        }
    }

}
