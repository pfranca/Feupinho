using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    // Start is called before the first frame update
    public float cameraPos = 0;
    public float movePos = 50;
    public float finalPos = 110;
    public float velocityX = 5;
    public bool active = true;
    private float randomFactor;
    void Start() {
        cameraPos = FindObjectOfType<CameraMovement>().transform.position.x;
        //randomFactor = Random.Range(1f, 2f);
        randomFactor = 1;
    }

    // Update is called once per frame
    void Update() {
        if (active) {
            cameraPos = FindObjectOfType<CameraMovement>().transform.position.x;
            if (cameraPos >= movePos) {
                transform.position += transform.right * (Time.deltaTime * (velocityX * randomFactor));
            }
            if (cameraPos > finalPos) {
                active = false;
            }
        }
        
    }
}
