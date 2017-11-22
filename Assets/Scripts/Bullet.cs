using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public GameObject impactEffect;

	public float speed = 50f;
	public float explosionRadius = 0f;

	public void Aim(Transform _target) {
		target = _target;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distThisFrame) {
			HitTarget ();
			return;
		}
		transform.Translate (dir.normalized * distThisFrame, Space.World);
		transform.LookAt (target);
	}

	void HitTarget() {

		GameObject effectIns = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);

		if (explosionRadius > 0f) {
			Explode ();
		} else {
			Damage (target);
		}
		Destroy (effectIns, 2f);
		Destroy (gameObject);
	}

	void Explode () {
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (Collider collider in colliders) {
			if (collider.tag == "Enemy") {
				Destroy (collider.gameObject);
			}
		}
	}

	void Damage (Transform enemy) {

		Destroy (enemy.gameObject);
	}
} 