using UnityEngine;

public class DestroyAfterPos : MonoBehaviour {
    [SerializeField] float position = -30f;
    void Update() {
        if(transform.position.x < position) {
            Destroy(gameObject);
        }
        
    }
    //Camera pos -52 -6.5
}
