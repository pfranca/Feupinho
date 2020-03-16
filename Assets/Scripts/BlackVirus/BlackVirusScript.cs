using UnityEngine;

public class BlackVirusScript : MonoBehaviour {

    Material material;
	bool isActive = true;
	bool isDissolving = false;
	float fade = 1f;
    public GameObject audioControllerSound;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
			if (isActive) {
                FindObjectOfType<Score>().changeScore(-100);
                FindObjectOfType<Player>().LowerCurEnergy(10f);
                audioControllerSound.GetComponent<AudioManager>().Play("GotHit");
                isDissolving = true;
				isActive = false;
                this.GetComponent<Animator>().SetBool("Active", isActive);
			}
            
        }
    }

    void Start() {
        material = GetComponent<SpriteRenderer>().material;
        Color color = new Color(150, 0, 0, 0f);
        material.SetColor("_Color", color);
    }

    void Update() {
        if (isDissolving) {
            fade -= Time.deltaTime * 2f;

			if (fade <= 0f) {
				fade = 0f;
				isDissolving = false;
			}
			material.SetFloat("_Fade", fade);
		}
    }
}
