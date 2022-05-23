using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerr : MonoBehaviour
{
    public GameObject canvas;
    public void Transferr()
    {
        StartCoroutine(Transfer());
    }
    public IEnumerator Transfer()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asynLoad = SceneManager.LoadSceneAsync(5,LoadSceneMode.Additive);
        while (!asynLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(canvas,SceneManager.GetSceneByBuildIndex(5));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
