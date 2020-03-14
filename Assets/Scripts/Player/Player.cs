using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Player : MonoBehaviour {
    public ParticleSystem playerParticleSystem;
    new public Rigidbody2D rigidbody2D;
    public Bar bar;
    public GameObject audioControllerSound;
    public GameObject audioControllerMusic;
    Animator animator;
    Material material;

    public float velocityX = 1f;
    public float velocityY = 1f;
    public int energy = 100; //max value
    public float curEnergy = 100;

    float timePassed = 0.25f;
    float timeTillStart;
    float timeTill_deadMusic = 1f;
    float timeOfDeath = 0;
    float fade = 1f;

    bool active = false;
    public bool isDissolving = false;
    
    public bool dosentDie = false;
    public bool won = false;
    public bool dead = false;

    public bool started = false;
    public bool started_extra = true;
    public bool doubleStarted = false;
    public bool tripleStarted = false;
    private bool played_deadMusic = false;

    private float inicialPosX;

    private Vector3 targetPosition;

    public bool speedUp = false;


    void Start() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        bar.SetMaxValue(energy);
        material = GetComponent<SpriteRenderer>().material;
        Color color = new Color(60,0,0,1f);
        animator.enabled = false;
        material.SetColor("_Color", color);
        playerParticleSystem.Stop();
        inicialPosX = transform.position.x;
    }


    void LoadCannon() {
        if(transform.position.x > (inicialPosX - 1)){
            transform.position -= transform.right * Time.deltaTime * 3 * 0.3f;
        }
        else {
            doubleStarted = true;
            tripleStarted = false;
        }
        
    }
    void Cannon() {
        // camera start -> -8, 0
        if (FindObjectOfType<CameraMovement>().transform.position.x < -8) {
            animator.enabled = true;
            playerParticleSystem.Play();
            FindObjectOfType<CameraMovement>().transform.position += transform.right * Time.deltaTime * (200 * 0.3f);
            transform.position += transform.right * Time.deltaTime * 199* 0.3f;
            
        }
        else {
            started = true;
            doubleStarted = false;
        }
        if (FindObjectOfType<CameraMovement>().transform.position.y < 0) {
            FindObjectOfType<CameraMovement>().transform.position += transform.up * Time.deltaTime * (60 * 0.3f);
            transform.position += transform.up * Time.deltaTime * (67 * 0.3f);
        }
        

    }

    void Update(){
        if (Input.GetKey(KeyCode.Mouse0) && !started) {
            tripleStarted = true;   
        }
        if(tripleStarted) {
            LoadCannon();
        }
        if (doubleStarted) {
            Cannon();
        }
        if (started && started_extra) {
            Color color2 = new Color(255f / 255, 121f / 255, 180f / 255, 0.9f);
            GameObject.Find("PlayerLight").GetComponent<Light2D>().color = color2;
            FindObjectOfType<CameraMovement>().SetActive();
            audioControllerMusic.GetComponent<AudioManager>().Play("Theme");
            timeTillStart = Time.time;
            active = true;
            started_extra = false;
        }  
    }
    void Move() {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (targetPosition - transform.position).normalized;
        rigidbody2D.velocity = new Vector2(direction.x * velocityX, direction.y * velocityY);
        //rigidbody2D.velocity = Vector3.MoveTowards(transform.position, targetPosition, velocityX * Time.deltaTime); 
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocityX * Time.deltaTime);
        //rigidbody2D.MovePosition(rigidbody2D.transform.position + targetPosition * velocityX * Time.fixedDeltaTime);
    }
    void FixedUpdate() {
        if (active) {
            if (!speedUp) {
                Move();
            }
            DecreaseEnergy();
            CheckOutOfCamera();
            if (curEnergy <= 0) {
                Die();
            }
            animator.SetFloat("curEnergy", curEnergy);
        }
        if (isDissolving) {
            Dissolver();
        }
        if (dead)
            PlayDeadMusic();
        
    }
    private void PlayDeadMusic() {
        if(Time.time > (timeOfDeath + timeTill_deadMusic) && !played_deadMusic){
            audioControllerSound.GetComponent<AudioManager>().Play("Dies");
            played_deadMusic = true;
        }
    }
    void DecreaseEnergy() {
        if ((Time.time - timeTillStart) >= timePassed) {
            timePassed += 0.03125f;
            LowerCurEnergy(0.25f);
            FindObjectOfType<Score>().changeScore((transform.position.x/5)*1/Time.time);
        }
    }
    void Dissolver() {
        fade -= Time.deltaTime * 0.5f;
        if (GameObject.Find("PlayerLight") != null) {
            GameObject.Find("PlayerLight").GetComponent<Light2D>().intensity -= Time.deltaTime * 0.1f;
        }
        //FindObjectOfType<Light2D>().intensity -= Time.deltaTime * 0.5f;
        if (fade <= 0f) {
            fade = 0f;
            if(isDissolving) {
                if (GameObject.Find("PlayerLight") != null) {
                    GameObject.Find("PlayerLight").SetActive(false);
                }
            }
                

            isDissolving = false;
            
        }
        material.SetFloat("_Fade", fade);
    }
    void CheckOutOfCamera() {
        if(transform.position.x < (FindObjectOfType<CameraMovement>().transform.position.x - 9.3f)) {
            if (GameObject.Find("PlayerBody") != null) {
                GameObject.Find("PlayerBody").SetActive(false);
            }
            Die();
        }
    }
    public bool GetStarted() {
        return started;
    }
    public bool GetDoubleStarted() {
        return doubleStarted;
    }
    public bool GetTripleStarted() {
        return tripleStarted;
    }
    public bool GetWon() {
        return won;
    }

    public void Die() {
        animator.SetBool("dead", true);
        isDissolving = true;
        active = false;
        dead = true;
        FindObjectOfType<CameraMovement>().Stop();
        FindObjectOfType<Score>().SetScore(0);
        audioControllerMusic.GetComponent<AudioManager>().Stop("Theme");
        audioControllerSound.GetComponent<AudioManager>().Play("Dying");

        //
        playerParticleSystem.Stop();
        rigidbody2D.velocity = Vector2.zero;

        timeOfDeath = Time.time;
        animator.speed = 0.1f;
        //animator.enabled = false;
    }
    public void LowerCurEnergy(float value) {
        curEnergy -= value;
        bar.SetCurValue(curEnergy);
    }
    public void UpCurEnergy(float value) {
        curEnergy += value;
        if(curEnergy > 100) {
            curEnergy = energy;
        }
        bar.SetCurValue(curEnergy);
        
    }
    public void Dissolve() {
        isDissolving = true;
        active = false;
        velocityX = 0;
        velocityY = 0;
    }
    public void Won() {
        if (!dead) {
            won = true;
            Color color = new Color(0, 255, 0, 0.2f);
            material.SetColor("_Color", color);
            FindObjectOfType<CameraMovement>().Stop();
            audioControllerMusic.GetComponent<AudioManager>().Stop("Theme");
            playerParticleSystem.Stop();
            rigidbody2D.velocity = Vector2.zero;
        }
        
    }

    public bool GetDead() {
        return dead;
    }
    public bool GetActive() {
        return active;
    }
}
