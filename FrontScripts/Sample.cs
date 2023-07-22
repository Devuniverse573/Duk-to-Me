using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Sample : MonoBehaviour
{
    public static Sample sample;
    public TMP_InputField inputField;

    public string player_name;

    private void Awake()
    {
        if(sample == null)
        {
            sample = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void SetPlayerName()
    {
        player_name = inputField.text;

        SceneManager.LoadSceneAsync("Guest");
    }
}
