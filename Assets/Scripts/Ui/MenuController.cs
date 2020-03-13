using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour {
    public GameObject loadingPanel;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject exitButton;
    public GameObject backButton;
    public GameObject allOptions;
    public new Camera camera;
    public Slider slider;
    public float cameraVelocityX = 40;


    bool options = false;
    bool back = false;

    void Update() {
        if (options) {
            if(camera.transform.position.x < 20) {
                camera.transform.position += transform.right * (Time.deltaTime * (cameraVelocityX * 0.9f));
            }
            else {
                backButton.SetActive(true);
                allOptions.SetActive(true);
            }
        }
        if(back) {
            if (camera.transform.position.x >= 0) {
                camera.transform.position -= transform.right * (Time.deltaTime * (cameraVelocityX * 0.9f));
            }
            else {
                playButton.SetActive(true);
                optionsButton.SetActive(true);
                exitButton.SetActive(true);
            }
        }
    }
    public void Play() {
        StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void Exit() {
        Application.Quit();
    }
    public void Options() {
        back = false;
        options = true;
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        exitButton.SetActive(false);
    }
    public void Back() {
        back = true;
        options = false;
        backButton.SetActive(false);
        allOptions.SetActive(false);

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

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
