using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour {
    public float velocity = 28;
    bool active = false;
    [SerializeField] GameObject fires;

    public void Stop() {
        active = false;
    }
    public void SetActive() {
        active = true;
    }

    void Update() {
        if (!active && FindObjectOfType<Player>().GetActive()) {
            active = true;
            fires.SetActive(true);
        }
        if (FindObjectOfType<Player>().GetWon() || FindObjectOfType<Player>().GetDead()) {
            fires.SetActive(false);
        }

        if (active && FindObjectOfType<End>().transform.position.x < -3) {
            active = false;
        }
        if (active) {
            if (FindObjectOfType<Player>().rigidbody2D.position.x < -14) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.4f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x < -13) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.55f));
            }
            else if (FindObjectOfType<Player>().rigidbody2D.position.x < -12) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.6f));
            } else if (FindObjectOfType<Player>().rigidbody2D.position.x < -11) {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.65f));
            } else {
                transform.position += transform.right * (Time.deltaTime * (velocity * 0.7f));
            }
        }

        if(active && FindObjectOfType<Player>().GetDead()) {
            active = false;
        }
        if (active && FindObjectOfType<Player>().GetWon()) {
            active = false;
        }
    }

    public void SetVelocity(float value) {
        velocity = value;
    }
    public void Deactivate() {
        active = false;
    }
}

