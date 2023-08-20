using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//MainCamera->Canvas->Inspector window->SceneChanger
public class SceneChanger : MonoBehaviour
{
    // Name of the scene to load
    public string sceneToLoad = "GCSR_Example";

    // Function to handle trigger detection
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player character (or any other object with the "Player" tag) enters the trigger area
        if (other.CompareTag("Player"))
        {
            // Call the SceneChange method to load the specified scene
            SceneChange();
        }
    }

    // Method to load the scene
    public void SceneChange()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
