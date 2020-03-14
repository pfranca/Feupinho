using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {
    public GameObject audioControllerSound;
    bool isDissolving = false;
    Material material;
    float fade = 1f;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    bool end = false;
    bool over = false;
    void Start(){
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Scale", 5);
    }

    void Update(){
        if(end) {
            if(fade < 0.9f) {
                spriteRenderer.sprite = sprite2;
                end = false;
            }
            
        }
        if (isDissolving) {
            fade -= Time.deltaTime * 0.25f;

            if (fade <= 0f) {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }
        if (!over) {
            if (FindObjectOfType<CameraMovement>().transform.position.x > (transform.position.x - 7)) {
                FindObjectOfType<CameraMovement>().Stop();
                over = true;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            FindObjectOfType<CameraMovement>().Stop();
            FindObjectOfType<Player>().Won();
            FindObjectOfType<Player>().Dissolve();
            FindObjectOfType<Score>().changeScore(100000*1/Time.time);
            isDissolving = true;
            spriteRenderer.sprite = sprite1;
            end = true;
            audioControllerSound.GetComponent<AudioManager>().Play("Extra_Firework1");
            audioControllerSound.GetComponent<AudioManager>().Play("Celebrate");
        }
    }
}
