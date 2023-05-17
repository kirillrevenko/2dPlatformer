using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackenemy;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    private float attackTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;


    public Animator animator;
    private EnemyPatrol enemyPatrol;
    private Health heroHealth;
    public GameObject deathEffect;

    public int maxHealth = 100;
    int currentHealth;

     private void Awake()
     {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
     }   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        //attack only if player in sight?
        if  (PlayerInSight())
        {
            if(attackTimer >= attackenemy)
                {
                    attackTimer = 0;
                    animator.SetTrigger("EnemyAttack");
                }
        }

        if(enemyPatrol != null)
        enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit  = Physics2D.BoxCast(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        //return hit.collider != null;

        if(hit.collider != null)
            heroHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        this.enabled = false;
        Debug.Log("Enemy died");
        animator.SetBool("IsDead", true);
        OnDestroy();
        //GetComponent<Collider2D>().enabled = false;    
        //this.enabled = false;
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    void OnDestroy() 
    {  
        Destroy(gameObject);
    }

     private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            heroHealth.TakeDamage(damage);
            //playerHealth.GetComponent<Health>().TakeDamage(damage);
        }
    }   

}
