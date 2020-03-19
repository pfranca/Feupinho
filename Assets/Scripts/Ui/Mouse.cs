using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
    public GameObject trailEffect;
    public float timePart = 0.01f;
    public Vector2 lastPos;
     void Start() {
        Cursor.visible = false;
     }

    void Update() {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        
        transform.position = cursorPos;
        if (lastPos != cursorPos) {
            if (timePart <= 0) {
                Instantiate(trailEffect, cursorPos, Quaternion.identity);
                timePart = 0.01f;
            } else {
                timePart -= Time.deltaTime;
            }
        }
        

        lastPos = cursorPos;
    }
}
