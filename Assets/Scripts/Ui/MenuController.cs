﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MenuController : MonoBehaviour {
    public GameObject loadingPanel;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject instructionsButton;
    public GameObject exitButton;
    public GameObject backButton;
    public GameObject allOptions;
    public GameObject allInstructions;
    public GameObject fullscreenToggle;
    public GameObject levelSelector;
    public GameObject audioController;
    public AudioMixer audioMixer;
    public GameObject musicSlider;
    public GameObject soundSlider;

    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public new Camera camera;
    public Slider slider;
    public float cameraVelocityX = 40;


    bool options = false;
    bool back = false;
    bool play = false;
    bool loading = false;
    bool instructions = false;
    int sideMenu = 1;

    private void Start() {
        float musicVolume;
        float soundVolume;
        audioMixer.GetFloat("music", out musicVolume);
        musicSlider.GetComponent<Slider>().value = musicVolume;
        audioMixer.GetFloat("sound", out soundVolume);
        soundSlider.GetComponent<Slider>().value = soundVolume;

        audioController.GetComponent<AudioManager>().Play("Theme");
        if (Screen.fullScreen) {
            fullscreenToggle.GetComponent<Toggle>().isOn = true;
        }
        else {
            fullscreenToggle.GetComponent<Toggle>().isOn = false;
        }
        GetResolutionDropdownInfo();
    }
    void GetResolutionDropdownInfo() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentRes = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentRes = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();
    }
    void Update() {
        if (options) {
            if(camera.transform.position.x < 20) {
                camera.transform.position += transform.right * (Time.deltaTime * (cameraVelocityX * 0.9f));
            }
            else {
                options = false;
                backButton.SetActive(true);
                allOptions.SetActive(true);
            }
        }
        if(instructions) {
            if (camera.transform.position.y > -13) {
                camera.transform.position -= transform.up * (Time.deltaTime * (cameraVelocityX * 0.9f));
            } else {
                instructions = false;
                backButton.SetActive(true);
                allInstructions.SetActive(true);
            }
        }
        
        if(back && sideMenu == 1) {
            if (camera.transform.position.x >= 0) {
                camera.transform.position -= transform.right * (Time.deltaTime * (cameraVelocityX * 0.9f));
            }
            else {
                playButton.SetActive(true);
                optionsButton.SetActive(true);
                instructionsButton.SetActive(true);
                exitButton.SetActive(true);
            }
        }
        if (back && sideMenu == 2 && !loading) {
            if (camera.transform.position.x <= 0) {
                camera.transform.position += transform.right * (Time.deltaTime * (cameraVelocityX * 0.9f));
            }
            else {
                sideMenu = 1;
                playButton.SetActive(true);
                optionsButton.SetActive(true);
                instructionsButton.SetActive(true);
                exitButton.SetActive(true);
            }
        }
        if(back && sideMenu == 3) {
            if (camera.transform.position.y <= 0) {
                camera.transform.position += transform.up * (Time.deltaTime * (cameraVelocityX * 0.9f));
            } else {
                sideMenu = 1;
                playButton.SetActive(true);
                optionsButton.SetActive(true);
                instructionsButton.SetActive(true);
                exitButton.SetActive(true);
            }
        }
        if (play && !loading) {
            if (camera.transform.position.x > -20) {
                camera.transform.position -= transform.right * (Time.deltaTime * (cameraVelocityX * 0.9f));
            }
            else {
                backButton.SetActive(true);
                levelSelector.SetActive(true);
                //allOptions.SetActive(true);
            }
        }
    }
    public void LoadLevel1() {
        LoadLevel(1);
    }
    public void LoadLevel2() {
        Debug.Log("2");
    }
    public void LoadLevel3() {
        LoadLevel(2);
    }
    public void LoadLevel(int index) {

        loading = true;
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        instructionsButton.SetActive(false);
        exitButton.SetActive(false);
        levelSelector.SetActive(false);
        backButton.SetActive(false);
        options = false;
        back = false;


        StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + index));
    }
    public void Play() {
        sideMenu = 2;
        back = false;
        play = true;
        playButton.SetActive(false);
        instructionsButton.SetActive(false);
        optionsButton.SetActive(false);
        exitButton.SetActive(false);
    }
    public void Exit() {
        Application.Quit();
    }
    public void Options() {
        back = false;
        options = true;
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        instructionsButton.SetActive(false);
        exitButton.SetActive(false);
    }
    public void Back() {
        back = true;
        options = false;
        play = false;
        backButton.transform.localPosition = new Vector2(0, -185);
        backButton.SetActive(false);
        allOptions.SetActive(false);
        allInstructions.SetActive(false);
        levelSelector.SetActive(false);
    }
    public void Instructions() {
        sideMenu = 3;
        back = false;
        instructions = true;
        backButton.transform.localPosition = new Vector2(550, -285);
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        instructionsButton.SetActive(false);
        exitButton.SetActive(false);
    }

    IEnumerator Load(int index) {
        loadingPanel.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index); 
        while (!asyncOperation.isDone) {
            
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int index) {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("music", volume);
    }
    public void SetSoundVolume(float volume) {
        audioMixer.SetFloat("sound", volume);
    }
}
