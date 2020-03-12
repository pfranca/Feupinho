using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyColorShader : MonoBehaviour {
    Material material;
    void Start() {
        material = GetComponent<SpriteRenderer>().material;
        material.SetColor("_Color", Color.red);
        material.SetFloat("_Fade", 0.80f);
        material.SetFloat("_Scale", 22f);
    }

    void Update() {
        
    }
}
