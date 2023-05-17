using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float heroHealth { get; private set; }
    private Animator anima;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Awake()
    {
        heroHealth = startingHealth;
        anima = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(heroHealth > numOfHearts)
        {
            heroHealth = numOfHearts;
        }
        for (int i=0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(heroHealth))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts) 
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(float _damage)
    {
        //Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        heroHealth = Mathf.Clamp(heroHealth - _damage, 0, startingHealth);
        anima.SetTrigger("hurt");

        if (heroHealth <= 0)
        {
            this.enabled = false;
            Debug.Log("Hero died");
            anima.SetTrigger("die");
            //onPlayerDestroy();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Potion"))
        {
            ChangeheroHealth(1);
            Destroy(other.gameObject);
        }
    }

    public void  ChangeheroHealth(int healthValue) 
    {
        heroHealth += healthValue;
    }
 
    void onPlayerDestroy()
    {
        Destroy(gameObject);
    }

    void restartscene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

}
