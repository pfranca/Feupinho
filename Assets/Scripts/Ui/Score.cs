using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private bool active = false;
    private float currentScore;
    void Start() {
        GetComponent<UnityEngine.UI.Text>().text = "";
        currentScore = 0;
    }

    void Update() {
        if(active) {
            GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString("0");
        }
        else if(FindObjectOfType<Player>().GetStarted()) {
            active = true;
        }
    }

    public void changeScore(float value) {
        currentScore += value;
        if(currentScore < 0) {
            currentScore = 0;
        }
    }
    public void SetScore(float value) {
        currentScore = value;
    }
}
