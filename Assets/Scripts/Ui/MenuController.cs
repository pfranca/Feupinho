using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour {
    public GameObject loadingPanel;
    public Slider slider;
    public void Play() {
        StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
        
    }
    public void Exit() {
        Application.Quit();
    }

    IEnumerator Load(int index) {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        loadingPanel.SetActive(true);
        while (!asyncOperation.isDone) {
            
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }

    }
}
