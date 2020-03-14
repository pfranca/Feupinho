using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour{
	public GameObject player;
	public bool active = false;
	public float duration = 0.1f;
	public float actTime;
	public float velocityFactor = 1.0005f;
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			active = true;
			actTime = Time.time;
			Debug.Log("AAA");
			player.GetComponent<Player>().speedUp = true;
		}
	}
	void Update() {
		if (active) {
			if((actTime + duration) > Time.time) {
				Debug.Log("AAAAAA");

				float velocityX = player.GetComponent<Player>().velocityX * velocityFactor;
				
				Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 direction = (targetPosition - player.GetComponent<Player>().transform.position).normalized;

				player.GetComponent<Player>().rigidbody2D.velocity = new Vector2(velocityX, direction.y);
			}
			else {
				player.GetComponent<Player>().speedUp = false;
				active = false;
			}
			
		}
	}
}
