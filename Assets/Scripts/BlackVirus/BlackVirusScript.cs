using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackVirusScript : MonoBehaviour
{

    Material material;
	bool isActive = true;
	bool isDissolving = false;
	float fade = 1f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
			if (isActive) {
				//Debug.Log("OLAAAA");
				FindObjectOfType<Player>().LowerCurEnergy(10f);
				isDissolving = true;
				isActive = false;
			}
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDissolving) {
			fade -= Time.deltaTime * 3;

			if (fade <= 0f) {
				fade = 0f;
				isDissolving = false;
			}
			material.SetFloat("_Fade", fade);
		}
    }
}
