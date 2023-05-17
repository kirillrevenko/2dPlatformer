using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;


    //продолжительность простоя врага
    [SerializeField] private float idleDuration;
    private float idleTimer;


    public Animator animator;


    private void Awake () 
    {
      initScale = enemy.localScale;  
    } 

     private void Update() 
    {   
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
            else
        {
             if (enemy.position.x <= rightEdge.position.x)
            MoveInDirection(1);
            else
            {
                DirectionChange();
            } 
        }
    }

    private void OnDisable() 
    {
        animator.SetBool("Moving", false);        
    }

    private void DirectionChange()
    {
        animator.SetBool("Moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }


    

 
   private void MoveInDirection(int _direction)
    {
        animator.SetBool("Moving", true);
        idleTimer = 0;
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x)*_direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }


}
