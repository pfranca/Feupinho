using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadEgg : MonoBehaviour {
    [SerializeField] new GameObject camera;
    [SerializeField] GameObject audioControllerMusic;

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
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Update() {
        if(cameraMovement.transform.position.x > 26) {
            //this.transform.position = transform.right * (cameraMovement.transform.position.x+9);
            if (!musicPlay) {
                audioControllerMusic.GetComponent<AudioManager>().Play("BossTheme");
                musicPlay = true;
            }
            cameraMovement.Deactivate();
            if(Time.time > animeTime) {
                spriteRenderer.sprite = sprite1;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            Debug.Log("Enemu");
            spriteRenderer.sprite = sprite2;
            animeTime = Time.time + animSecs;
        }
    }
}
