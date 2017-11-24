using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTarget : MonoBehaviour {

	[Header("General")]
	public float range = 20f;

	[Header("Use Bullets (default)")]
	public GameObject bulletPrefab;
	public float fireRate = 1f;
	private float fireCooldown = 0f;

	[Header("Use Laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer;

	[Header("System Setup")]
	private Transform target;
	public float rotationSpeed = 200f;
	public string enemytag = "Enemy";

	public GameObject firePoint;

	// Use this for initialization
	void Start() {

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget() {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemytag);
		float shortestDist = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) {
			float dist = Vector3.Distance (transform.position, enemy.transform.position);
			if (dist < shortestDist) {
				shortestDist = dist;
				nearestEnemy = enemy;
			}

		}

		if (nearestEnemy != null && shortestDist <= range) 
			target = nearestEnemy.transform;
		else
			target = null;
	}
	// Update is called once per frame
	void Update () {
		if (target == null) {
			if (useLaser) {
				if (lineRenderer.enabled)
					lineRenderer.enabled = false;
			}
			return;
		}
		LockOnTarget ();

		if (useLaser) {
			Laser ();
		} else {
			if (fireCooldown <= 0f) {
				Shoot ();
				fireCooldown = 1f / fireRate;
			}

			fireCooldown -= Time.deltaTime;
		}
	}

	void LockOnTarget () {
		Vector3 direction = target.position - transform.position;
		Quaternion desiredRotation = Quaternion.LookRotation (direction, Vector3.up);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
	}

	void Laser () {
		if (!lineRenderer.enabled) {
			lineRenderer.enabled = true;
		}

		lineRenderer.SetPosition (0, firePoint.transform.position);
		lineRenderer.SetPosition (1, target.position);
	}


	void Shoot() {

		GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null) {
			bullet.Aim (target);
		
		}
	}
}
