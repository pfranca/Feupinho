using UnityEngine;

public class Energy : MonoBehaviour {
	Material material;
	bool isActive = true;
	bool isDissolving = false;
	float fade = 1f;
	public GameObject audioControllerSound;

	private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
			if (isActive) {
				FindObjectOfType<Player>().UpCurEnergy(50f);
				isDissolving = true;
				isActive = false;
				audioControllerSound.GetComponent<AudioManager>().Play("EnergyUp");
			}
            
        }
    }
	void Start() {
		material = GetComponent<SpriteRenderer>().material;
		Color color = new Color(0, 150, 0, 0f);
		material.SetColor("_Color", color);
	}

	void Update() {
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
