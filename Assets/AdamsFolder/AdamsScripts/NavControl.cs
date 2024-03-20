using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavControl : MonoBehaviour
{
    public void LoadMyScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadMyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
