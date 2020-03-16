using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadEgg : MonoBehaviour {
    [SerializeField] new GameObject camera;
    [SerializeField] GameObject audioControllerMusic;



    private bool musicPlay = false;
    private SpriteRenderer spriteRenderer;
    private CameraMovement cameraMovement;
    void Start() {
        cameraMovement = camera.GetComponent<CameraMovement>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Update() {
        if(cameraMovement.transform.position.x > 26) {
            this.transform.position = transform.right * (cameraMovement.transform.position.x+9);
            if (!musicPlay) {
                audioControllerMusic.GetComponent<AudioManager>().Play("BossTheme");
                musicPlay = true;
            }
            
        }
    }
}
