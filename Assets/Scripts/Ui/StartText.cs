using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour {

    private bool active = true;

    void Update() {
        if (active) {
            if (FindObjectOfType<Player>().GetStarted()) {
                GameObject.Find("Text").SetActive(false);
                active = false;
            }
        }
    }
}
