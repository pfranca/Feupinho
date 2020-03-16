using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    [SerializeField] float positionX = 0;
    [SerializeField] float velocityX = 0;
    [SerializeField] new GameObject camera;

    private CameraMovement cameraMovement;

    void Start() {
        cameraMovement = camera.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update() {
        if(camera.transform.position.x >= positionX) {
            this.transform.position -= transform.right * (velocityX * Time.deltaTime);
        }
    }
}
