using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string sceneName;

    // Method to change the scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
