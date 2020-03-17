using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadEgg : MonoBehaviour {
    [SerializeField] new GameObject camera;
    [SerializeField] GameObject audioControllerMusic;
    [SerializeField] GameObject actionLight;

    private bool musicPlay = false;
    private SpriteRenderer spriteRenderer;
    private CameraMovement cameraMovement;

    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;

    [SerializeField] float animSecs = 0.5f;
    private float animeTime;

    Material material;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraMovement = camera.GetComponent<CameraMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update() {
        if(cameraMovement.transform.position.x > 26) {
            if (!musicPlay) {
                audioControllerMusic.GetComponent<AudioManager>().Play("BossTheme");
                musicPlay = true;
            }
            cameraMovement.Deactivate();
            if(Time.time > animeTime) {
                spriteRenderer.sprite = sprite1;
                actionLight.SetActive(false);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            spriteRenderer.sprite = sprite2;
            animeTime = Time.time + animSecs;
            Color color = new Color(60, 0, 0, 1f);
            material.SetColor("_Color", color);
            actionLight.SetActive(true);
        }
    }
}
