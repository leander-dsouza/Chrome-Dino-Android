using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    public GameObject loader;
    public Slider Slider;
    public Text progressText;
    
    public void LoadSceneNumber(int sceneIndex)
    {

        StartCoroutine(LoadAsyncronously(sceneIndex));
    }

    IEnumerator LoadAsyncronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loader.SetActive(true);

        while(!operation.isDone)
        {
            //operation.progress gives a float value from 0 -1
            // Loading is 0-0.9, Activation is 0.9 - 1
            //Scaling 0-0.9 to 0-1

            float progress = Mathf.Clamp01(operation.progress / .9f);
            Slider.value = progress;
            progress *= 100f;
            progressText.text = ((int)progress).ToString() + "%";
            yield return null; //Wait a frame
        }

    }

}
