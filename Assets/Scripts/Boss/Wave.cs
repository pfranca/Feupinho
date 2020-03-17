using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    [SerializeField] float timeToAction = 60;
    [SerializeField] float velocityX = 0;
    [SerializeField] new GameObject camera;
    [SerializeField] GameObject playerObject;

    private float time = 0;
    private float timeTillAction = 0;
    private bool active = false;
    private bool oneCycle = true;

    private CameraMovement cameraMovement;
    private Player player;


    void Start() {
        cameraMovement = camera.GetComponent<CameraMovement>();
        player = playerObject.GetComponent<Player>();
    }
    void FixedUpdate() {
        if (player.GetActive() && oneCycle) {
            active = true;
            timeTillAction = Time.time + timeToAction;
            oneCycle = false;
        }
        if (active) {
            time = Time.time;
            if(time > timeTillAction) {
                this.transform.position -= transform.right * (velocityX * Time.deltaTime);
            }
            if(time > (timeTillAction + 200)) { //Go afk
                active = false;
            }
        }
    }
}
