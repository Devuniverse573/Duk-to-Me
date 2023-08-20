using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line to include the SceneManager class

public class NPCInteractable : MonoBehaviour
{
    //private NPCHeadLookAt npcHeadLookAt;

    private void Awake()
    {
        //npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(Transform interactorTransform)
    {
        //float playerHeight = 1.7f;
        //npcHeadLookAt.LookAtPosition(interactorTransform.position = vector3.up * playerHeight);

        // Use the SceneManager to load the 'SampleScene'
        SceneManager.LoadScene("GCSR_Example");
    }
}
