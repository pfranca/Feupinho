using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPos : MonoBehaviour {
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(transform.position.x < -30) {
            Destroy(gameObject);
        }
        
    }
}
