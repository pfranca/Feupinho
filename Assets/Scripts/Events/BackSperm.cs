using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSperm : MonoBehaviour {
    public float velocityX = 7;
    void Start() {
        
    }

    void Update() {
        if(transform.position.x < 40) {
            transform.position += transform.right * (Time.deltaTime * (velocityX));
        }
        else {
            transform.position = new Vector2(-20, transform.position.y); 
        }
        
    }
}
