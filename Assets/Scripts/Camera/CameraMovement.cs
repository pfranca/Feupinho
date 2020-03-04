using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float velocity = 28;
    public bool active = true;
    void Start() {
        
    }

    void Update() {
        //shit code
        if (active) {
            if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 7)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.9f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 3)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.8f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.7f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -2)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.6f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -4)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.5f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -6)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.4f));
            }
            else {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.10f));
            }

        }
    }

    public void SetVelocity(float value) {
        velocity = value;
    }
}
