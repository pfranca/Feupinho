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
                FindObjectOfType<Score>().changeScore(-100);
                FindObjectOfType<Player>().LowerCurEnergy(10f);
                FindObjectOfType<AudioManager>().Play("GotHit");
                isDissolving = true;
				isActive = false;
			}
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        Color color = new Color(150, 0, 0, 0f);
        material.SetColor("_Color", color);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDissolving) {
			fade -= Time.deltaTime * 2;

			if (fade <= 0f) {
				fade = 0f;
				isDissolving = false;
			}
			material.SetFloat("_Fade", fade);
		}
    }
}
