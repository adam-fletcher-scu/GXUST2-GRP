using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavControl : MonoBehaviour
{
    public void LoadMyScene(int sceneNumber)
    {
        StartCoroutine("PlayOurSound", sceneNumber);
        
    }

    public void LoadMyScene(string sceneName)
    {
        StartCoroutine("PlayOurSound");
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator PlayOurSound(int sceneNumber)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneNumber);
    }
}
