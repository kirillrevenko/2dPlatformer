using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timeBar;
    public float maxTime = 20f;
    float timeLeft;
    [SerializeField] GameObject buttonExit;

    void Start()
    {
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;       
    }

    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
             buttonExit.SetActive(true);
        }
    }
}
