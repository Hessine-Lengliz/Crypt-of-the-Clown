using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    public int value = 1; 
    public TMP_Text coinText;
     public int currentCoins =  0;
    public float rotationSpeed = 90.0f; // Adjust the speed of rotation as needed
  void Start()
    {
        coinText.text = "Coins:" + currentCoins.ToString();
    }
    void Update()
    {
        
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

     public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin")) 
        {
             currentCoins += 1;
           coinText.text = "Coins:" + currentCoins.ToString();  
            Destroy(this.gameObject);
           
        }
    }
}
