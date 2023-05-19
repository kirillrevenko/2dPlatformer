using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[SerializeField] private float attackCooldown;
    public Animator anima;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        Attack();
    }

    public void Attack()
    {
        anima.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    //+1 attackdamage in sop
     public void AttackPlus()
   {
        upAttack(10);
   }

    public void  upAttack(int attackplus) 
    {
        attackDamage += attackplus;
        Debug.Log(attackDamage);
    }

    void OnDrawGizmosSelected() 
        {
            if (attackPoint == null)
                return;
                Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }     
    

}
