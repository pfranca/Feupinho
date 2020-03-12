using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour {
    TMPro.TextMeshProUGUI textMesh;
    void Start() {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
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
            switch (textMesh.color.a.ToString()) {
                case "0":
                    textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
}
