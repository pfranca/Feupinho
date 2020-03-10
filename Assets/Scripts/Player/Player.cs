using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Player : MonoBehaviour {
    //private float cameraVelocity;
    new public Rigidbody2D rigidbody2D;
    public float velocityX = 1f;
    public float velocityY = 1f;
    public int energy = 100; //max value
    public float curEnergy = 100;
    public Bar bar;
    public float timePassed = 0.25f;
    public float timeTillStart;
    Animator animator;
    Material material;
    bool active = false;
    public bool dosentDie = false;
    bool isDissolving = false;
    float fade = 1f;
    public bool won = false;
    public bool dead = false;
    public bool started = false;

    private bool played_deadMusic = false;
    public float timeTill_deadMusic = 1f;
    private float timeOfDeath = 0;

    private Vector3 targetPosition;

    void Start() {
        animator = GetComponent<Animator>();
        //cameraVelocity = FindObjectOfType<CameraMovement>().velocity;
        rigidbody2D = GetComponent<Rigidbody2D>();
        bar.SetMaxValue(energy);
        material = GetComponent<SpriteRenderer>().material;
        Color color = new Color(255,0,0,0.2f);
        material.SetColor("_Color", color);
    }

    void Update(){
        if (Input.GetKey(KeyCode.Mouse0) && !started) {
            FindObjectOfType<CameraMovement>().SetActive();
            FindObjectOfType<AudioManager>().Play("Theme");
            timeTillStart = Time.time;
            active = true;
            started = true;
        }
        if (active) {
            SetTargetPosition();
            Move();
            //Move();
            //Debug.Log(Time.time);


            //transform.position += transform.right * (Time.deltaTime * cameraVelocity);
        }

        
    }

    void SetTargetPosition() {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
    }
    void Move() {
        //rigidbody2D.velocity = Vector3.MoveTowards(transform.position, targetPosition, velocityX * Time.deltaTime); 
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocityX * Time.deltaTime);
        //rigidbody2D.MovePosition(rigidbody2D.transform.position + targetPosition * velocityX * Time.fixedDeltaTime);
    }
    void FixedUpdate() {
        if (active) {
            DecreaseEnergy();
            CheckOutOfCamera();
            if (curEnergy <= 0) {
                Die();
            }
        }
        if (isDissolving) {
            Dissolver();
        }
        if (dead)
            PlayDeadMusic();
        
    }
    private void PlayDeadMusic() {
        if(Time.time > (timeOfDeath + timeTill_deadMusic) && !played_deadMusic){
            FindObjectOfType<AudioManager>().Play("Dies");
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

    public void Die() {
        isDissolving = true;
        active = false;
        dead = true;
        FindObjectOfType<CameraMovement>().Stop();
        FindObjectOfType<Score>().SetScore(0);
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("Dying");
        animator.enabled = false;

        timeOfDeath = Time.time;
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
        won = true;
        Color color = new Color(0, 255, 0, 0.2f);
        material.SetColor("_Color", color);
        FindObjectOfType<AudioManager>().Stop("Theme");
    }
    void SetCurEnergy(int value) {
        curEnergy = value;
    }






    void handleInput() {
        /*int moved = 0;
        if (Input.GetKey(KeyCode.RightArrow)) {
            rigidbody2D.velocity = new Vector2(velocityX, 0);
            moved++;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody2D.velocity = new Vector2(-velocityX, 0);
            moved++;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            rigidbody2D.velocity = new Vector2(0, velocityY);
            moved++;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            rigidbody2D.velocity = new Vector2(0, -velocityY);
            moved++;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) {
            rigidbody2D.velocity = new Vector2(velocityX, velocityY);
            moved++;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody2D.velocity = new Vector2(-velocityX, velocityY);
            moved++;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) {
            rigidbody2D.velocity = new Vector2(velocityX, -velocityY);
            moved++;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody2D.velocity = new Vector2(-velocityX, -velocityY);
            moved++;
        }

        if (moved == 70) {
            rigidbody2D.velocity = new Vector2(cameraVelocity, 0);
        }
        */

        /*int aux = 0;
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += transform.right * (Time.deltaTime * velocityX);
            animator.speed = 3;
            aux = 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= transform.right * (Time.deltaTime * velocityX);
            aux = 2;
        }
        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position += transform.up * (Time.deltaTime * velocityY);
            aux = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position -= transform.up * (Time.deltaTime * velocityY);
            aux = 0;
        }

        if((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.RightArrow)) {
            aux = 1;
        }

        if(aux == 0) {
            animator.speed = 1;
        }
        else if(aux == 2) {
            animator.speed = 0.4f;
        }*/

    }

}
