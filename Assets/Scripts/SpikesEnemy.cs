using UnityEngine;

public class SpikesEnemy : MonoBehaviour
{
    [SerializeField] private float damage;
    private Health heroHealth;

    private void OnTriggerEnter2D(Collider2D collision) 
  
    {
       if(collision.gameObject.TryGetComponent(out PlayerMove body))
        collision.GetComponent<Health>().TakeDamage(damage);  
    }


    
}
