using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Playermovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    public TMP_Text coinText;

    public int currentCoins = 0;

    public static Playermovement instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //coinText.text = "COINS:" + currentCoins.ToString();
    } 
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        
    }
   
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS:" + currentCoins.ToString();
    }
}



