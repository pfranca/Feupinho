using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour {
    private bool active = true;
    bool timer = false;
    [SerializeField] GameObject startText = null;
    void Update() {
        if (active) {
            if (FindObjectOfType<Player>().GetTripleStarted()) {
                startText.SetActive(false);
                active = false;
            }
        }
    }
    void Start() {
        BlinkStart();
    }

    void BlinkStart() {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
    void StopBlinking() {
        StopCoroutine("Blink");
    }
    IEnumerator Blink() {
        while (true) {
            switch (timer) {
                case false:
                    startText.SetActive(false);
                    timer = true;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case true:
                    startText.SetActive(true);
                    timer = false;
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
}
