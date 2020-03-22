using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MadEgg : MonoBehaviour {
    [SerializeField] new GameObject camera;
    [SerializeField] GameObject audioControllerMusic;
    [SerializeField] GameObject actionLight;

    private bool musicPlay = false;
    private SpriteRenderer spriteRenderer;
    private CameraMovement cameraMovement;

    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    [SerializeField] Sprite sprite3;

    [SerializeField] float animSecs = 0.5f;
    private float animeTime;

    Material material;


    public GameObject audioControllerSound;
    bool isDissolving = false;
    bool dissolveBack = false;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite baby;
    bool end = false;
    bool over = false;
    float fade = 1f;

    bool timeover = false;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraMovement = camera.GetComponent<CameraMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
        spriteRenderer.sprite = sprite1;
    }
    void Update() {
        if(cameraMovement.transform.position.x > 26 && !timeover) {
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
        if(!timeover && FindObjectOfType<TimeCounter>().time > 108) {
            timeover = true;
            GetComponent<PolygonCollider2D>().isTrigger = true;
            spriteRenderer.sprite = sprite6;
        }
        if (timeover) {
            if (end) {
                if (fade < 0.9f) {
                    spriteRenderer.sprite = sprite5;
                    end = false;
                }

            }
            if (isDissolving) {
                fade -= Time.deltaTime * 0.25f;
                material.SetFloat("_Fade", fade);
                if (fade <= 0f) {
                    fade = 0f;
                    isDissolving = false;
                    spriteRenderer.sprite = baby;
                    transform.position -= transform.right * 2;
                    material.SetFloat("_Fade", 0);
                    dissolveBack = true;
                }
                
            }
            if(dissolveBack) {
                if(fade < 1) {
                    fade += Time.deltaTime * 0.25f;
                    material.SetFloat("_Fade", fade);
                }
                else{
                    dissolveBack = false;
                }
                
            }
            if (!over) {
                if (FindObjectOfType<CameraMovement>().transform.position.x > (transform.position.x - 7)) {
                    FindObjectOfType<CameraMovement>().Stop();
                    over = true;
                }
            }
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            spriteRenderer.sprite = sprite2;
            animeTime = Time.time + animSecs;
            Color color = new Color(60, 0, 0, 1f);
            material.SetColor("_Color", color);
            actionLight.GetComponent<Light2D>().color = new Color(1, 1, 1);
            actionLight.SetActive(true);
        }
        if (collision.gameObject.tag == "Enemy2") {
            spriteRenderer.sprite = sprite3;
            animeTime = Time.time + animSecs;
            Color color = new Color(60, 0, 0, 1f);
            material.SetColor("_Color", color);
            actionLight.GetComponent<Light2D>().color = new Color(0, 1, 0);
            actionLight.SetActive(true);
        }
        if (timeover) {
            if (collision.gameObject.tag == "Player") {
                Debug.Log("DSFFSD");
                FindObjectOfType<CameraMovement>().Stop();
                FindObjectOfType<Player>().Won();
                FindObjectOfType<Player>().Dissolve();
                //FindObjectOfType<Score>().changeScore(100000 * 1 / Time.time);
                isDissolving = true;
                spriteRenderer.sprite = sprite4;
                end = true;
                audioControllerSound.GetComponent<AudioManager>().Play("Extra_Firework1");
                audioControllerSound.GetComponent<AudioManager>().Play("Celebrate");
            }
        }
    }
}
