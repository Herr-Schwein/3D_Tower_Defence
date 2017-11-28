using UnityEngine;
using UnityEngine.AI;
using System.Runtime.CompilerServices;
using System.Threading;

public class Enemy : MonoBehaviour {

	public float initSpeed = 10f;
	[HideInInspector]
	public float speed;

	public float health = 100;
	public int value = 10;
	public GameObject destroyEffect;
	private bool isDead = false;

	void Start() {
		speed = initSpeed; 
	}
		
	public void TakeDamage (float amount) {
		health -= amount;
		if (health <= 0 && !isDead) {
			Die ();
		}
	}

	public void Slow (float amount) {
		speed = initSpeed * (1f - amount); 
	}


	void Die () {
		isDead = true;
		PlayerStats.Money += value;
		GameObject effect = (GameObject)Instantiate (destroyEffect, transform.position, Quaternion.identity);
		Destroy (effect, 2f);
		WaveSpawner.EnemiesAlive--;
		Destroy (gameObject);

	}


}
