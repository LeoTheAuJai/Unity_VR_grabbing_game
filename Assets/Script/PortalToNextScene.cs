using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToNextScene : MonoBehaviour
{
    public GameObject player;
    public Scene NextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Increment the scene index to load the next scene
        int nextSceneIndex = currentSceneIndex + 1;
        if ((player.transform.position.x<2f && player.transform.position.y < 2f && player.transform.position.z < 3.6f) &&
            (player.transform.position.x > -3.9f && player.transform.position.y > -1.9f && player.transform.position.z > 1.7f))
        {
            Debug.Log("in range");
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("out range");
        }
    }
}
