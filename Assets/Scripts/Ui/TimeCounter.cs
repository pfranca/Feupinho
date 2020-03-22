using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour {
    private bool active = false;
    private float realTime = 0;
    public float time;
    void Start() {
        GetComponent<UnityEngine.UI.Text>().text = "";
        time = 0;
        realTime = Time.time;
    }

    void Update() {
        time = Time.time - realTime;
        if (active) {
            GetComponent<UnityEngine.UI.Text>().text = time.ToString("0");
        } else if (FindObjectOfType<Player>().GetStarted()) {
            active = true;
        }
        if (!active) {
            realTime = Time.time;
        }
    }
}
