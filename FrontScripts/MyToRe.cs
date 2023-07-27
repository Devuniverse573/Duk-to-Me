using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyToRe : MonoBehaviour
{//Mypage to Reform

    // Start is called before the first frame update
public void SceneChange()
    {
        SceneManager.LoadScene(8);
    }
}
