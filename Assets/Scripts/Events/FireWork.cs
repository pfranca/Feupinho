using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private bool active = false;
    public Animator animator;
    private float generatedTime;
    private float timeTillAction = 0;
    // Start is called before the first frame update
    void Start() {
        spriteRenderer.enabled = false;
        animator.speed = 0;
        generatedTime = Random.Range(0.5f, 3f);
    }

    // Update is called once per frame
    void Update() {
        if (active) {
            if(timeTillAction == 0) {
                timeTillAction = generatedTime + Time.time;
            }
            else if (Time.time >= timeTillAction) {
                spriteRenderer.enabled = true;
                animator.speed = 1;
            }            
        }
        if (FindObjectOfType<Player>().won) {
            active = true;
        }
    }
}
