using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{

    public Slider slider;
    public GameObject loadScreen;

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
    {
        SceneManager.LoadScene(1);
    }
 }

    public void runToLevel() 
    {
        SceneManager.LoadScene(1);  
        StartCoroutine(LoadingScreenOnFade()); 
    } 

    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        loadScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
