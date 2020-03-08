using UnityEngine;

public class Energy : MonoBehaviour {
	Material material;
	bool isActive = true;
	bool isDissolving = false;
	float fade = 1f;

	private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
			if (isActive) {
				FindObjectOfType<Player>().UpCurEnergy(20f);
				isDissolving = true;
				isActive = false;
			}
            
        }
    }
	void Start() {
		material = GetComponent<SpriteRenderer>().material;
		material.SetColor("_Color", Color.green);
	}

	void Update() {
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
