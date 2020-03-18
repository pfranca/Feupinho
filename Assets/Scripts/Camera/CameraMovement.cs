using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float velocity = 28;
    bool active = false;
    [SerializeField] bool normalLevel = true;
    public void Stop() {
        active = false;
    }
    public void SetActive() {
        active = true;
    }

    void Update() {
        if (active) {

            /*float increaser = 0.000001f;
            for(float i = -6; i < 10; i+=0.25f) {
                if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + i)) {
                    transform.position += transform.right * (Time.deltaTime * (velocity * increaser));
                    increaser += 0.0125f;
                }
            }*/
            /*if (FindObjectOfType<Player>().speedUp) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 4f));
            }
            else*/ if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 7)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.9f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 5)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.866f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 4)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.833f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 3)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.8f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 2)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.766f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + 1)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.733f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.7f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -1)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.65f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -2)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.6f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -3)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.55f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -4)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.5f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -5)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.45f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -6)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.4f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x > (transform.position.x + -7)) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.3f));
            }
            else {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.1f));
            }

            if (normalLevel && FindObjectOfType<Player>().GetActive()) {
                active = false;
            }

        }
    }

    public void SetVelocity(float value) {
        velocity = value;
    }
    public void Deactivate() {
        active = false;
    }
}
