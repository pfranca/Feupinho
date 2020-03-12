﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour {

    private bool active = true;

    void Update() {
        if (active) {
            if (FindObjectOfType<Player>().GetDoubleStarted()) {
                GameObject.Find("StartText").SetActive(false);
                active = false;
            }
        }
    }
}
