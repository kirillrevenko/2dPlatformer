using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    private float coins;
    public TMP_Text coinsText;

    private void OnTriggerEnter2D (Collider2D coll) 
    {

        if(coll.gameObject.tag == "Coins")  
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(coll.gameObject);
        }    
    }
}
