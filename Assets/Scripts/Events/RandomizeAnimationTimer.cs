using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimationTimer : MonoBehaviour {
    Animator animator;
    
    void Start() {
        animator = GetComponent<Animator>();
        float num = Random.Range(0.6f, 1.3f);
        animator.speed = num;
    }
}
