using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    private float coins;
    public TMP_Text coinsText;
    public TMP_Text coinsTextShop;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject health;

     void Update()
    {
        
        if(coins >= 2)
        {
            weapon.SetActive(true);
            health.SetActive(true);
             
        }
        else
            {
                weapon.SetActive(false);
                health.SetActive(false);
                  
            }


    }

    private void OnTriggerEnter2D (Collider2D coll) 
    {

        if(coll.gameObject.tag == "Coins")  
        {
            coins++;
            coinsText.text = coins.ToString();
            coinsTextShop.text = coins.ToString();
            Destroy(coll.gameObject);
        } 

    }

    public void CoinsMinus()
   {
        ChangeheroCoinsMinus(2);
   }

    public void  ChangeheroCoinsMinus(int coinsminus) 
    {
       coins -= coinsminus;
       coinsText.text = coins.ToString();
        coinsTextShop.text = coins.ToString();
    }

     public void CoinsPlus()
   {
        ChangeheroCoinsPlus(3);
   }

    public void  ChangeheroCoinsPlus(int coinsplus) 
    {
       coins += coinsplus;
       coinsText.text = coins.ToString();
        coinsTextShop.text = coins.ToString();
    }
}
