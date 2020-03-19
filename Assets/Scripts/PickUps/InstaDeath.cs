using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDeath : MonoBehaviour {
    private bool active = true;
    private bool isDissolving = false;
    float fade = 1f;
    [SerializeField] GameObject player;
    Material material;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (active) {
                isDissolving = true;
                active = false;
                //player.GetComponent<Player>().Die();
            }
        }
    }
    void Start() {
        material = GetComponent<SpriteRenderer>().material;
        Color color = new Color(0, 255, 0, 0f);
        material.SetColor("_Color", color);
    }

    void Update() {
        if (isDissolving) {
            fade -= Time.deltaTime * 2;

            if (fade <= 0f) {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }
    }
}
