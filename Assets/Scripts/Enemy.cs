using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public float initSpeed = 10f;
	[HideInInspector]
	public float speed;

	public float health = 100;
	public int value = 10;
	public GameObject destroyEffect;




	void Start() {
		speed = initSpeed; 
	}

	public void TakeDamage (float amount) {
		health -= amount;
		if (health <= 0) {
			Die ();
		}
	}

	public void Slow (float amount) {
		speed = initSpeed * (1f - amount); 
	}

	void Die () {
		PlayerStats.Money += value;

		GameObject effect = (GameObject)Instantiate (destroyEffect, transform.position, Quaternion.identity);
		Destroy (effect, 2f);
		Destroy (gameObject);
	}


}
