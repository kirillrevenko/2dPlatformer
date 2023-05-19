using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject shop;

    void Start()
    {
        pause.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;  
        }


    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;    
    }

    public void Shop()
    {
        shop.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0;    
    }

}
