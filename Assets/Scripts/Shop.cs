using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Coins coins;
    private Health heroHealth;
    private Attacker attackDamage;
    [SerializeField] GameObject reklama;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject pause;
   
   
    private void Awake()
    {
        attackDamage = GetComponentInParent<Attacker>();
    }

   public void AttackPlus()
   {
        upAttack(10);
   }

    public void  upAttack(int attackplus) 
    {
        //attackDamage += attackplus;
        Debug.Log(attackDamage);
    }

    public void openReklam()
    {
        reklama.SetActive(true);
        timer.SetActive(true);
        Time.timeScale = 1;  
    }

    public void closeShop()
    {
        shop.SetActive(false); 
        pause.SetActive(true);
    }

    public void closeReklam()
    {
        reklama.SetActive(false);
        timer.SetActive(false);
    }

}
