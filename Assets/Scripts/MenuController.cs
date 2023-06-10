using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingBar;
    public void OnClickStart()
    {
        StartCoroutine(LoadSceneAsync(1));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            loadingPanel.SetActive(true);
            loadingBar.value = asyncLoad.progress;
            yield return null;
        }
    }

    public void OnClickExit()
    {
        Debug.Log("Exit");
    }
}
