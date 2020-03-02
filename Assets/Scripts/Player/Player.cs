using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //private float cameraVelocity;
    new public Rigidbody2D rigidbody2D;
    public float velocityX = 1f;
    public float velocityY = 1f;
    public int energy = 100; //max value
    public float curEnergy = 100;
    public Bar bar;
    public float timePassed = 0.25f;
    Animator animator;
    bool active = true;

    private Vector3 targetPosition;

    void Start() {
        animator = GetComponent<Animator>();
        //cameraVelocity = FindObjectOfType<CameraMovement>().velocity;
        rigidbody2D = GetComponent<Rigidbody2D>();
        bar.SetMaxValue(energy);
    }

    void Update(){
        if (active) {
            handleInput();
            //Debug.Log(Time.time);
            if (Time.time >= timePassed) {
                timePassed += 0.03125f;
                LowerCurEnergy(0.25f);
            }
            if(curEnergy <= 0) {
                active = false;
                FindObjectOfType<CameraMovement>().active = false;
                animator.enabled = false;
            }
            SetTargetPosition();
            Move();
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
        //handleInput();
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

    void LowerCurEnergy(float value) {
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
    void SetCurEnergy(int value) {
        curEnergy = value;
    }
    
}
