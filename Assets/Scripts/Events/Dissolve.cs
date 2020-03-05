using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour {
    bool isDissolving = false;
    public float fade = 1f;
    public float fadePower = 0.6f;
    Material material;
    void Start() {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update() {
        if (FindObjectOfType<Player>().won || (FindObjectOfType<Player>().curEnergy <= 0)) {
            isDissolving = true;
        }
        if (isDissolving) {
            fade -= Time.deltaTime * fadePower;

            if (fade <= 0f) {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }

    }
}
