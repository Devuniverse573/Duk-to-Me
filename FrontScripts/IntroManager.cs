using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject IntroPanel;
    public int AniTime;

   void Start()
    {
        StartCoroutine(DelayTime(AniTime));
    }

    IEnumerator DelayTime(float time){
        yield return new WaitForSeconds(time);

        IntroPanel.SetActive(false);
        StartPanel.SetActive(true);
    }
    
    public void GoGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
