using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyColorShader : MonoBehaviour {
    Material material;
    void Start() {
        material = GetComponent<SpriteRenderer>().material;
        material.SetColor("_Color", Color.red);
        material.SetFloat("_Fade", 0.90f);
        material.SetFloat("_Scale", 13f);
    }

    void Update() {
        
    }
}
