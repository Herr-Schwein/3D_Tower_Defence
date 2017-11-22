using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	public NavMeshAgent Enemy;
	public Transform MoveTarget;



	// Use this for initialization
	void Start () {
		Enemy = GetComponent<NavMeshAgent> ();
		MoveTarget = GameObject.FindWithTag("MoveTarget").transform;
		Enemy.destination = MoveTarget.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Enemy.SetDestination (MoveTarget.position);
		if (Vector3.Distance(transform.position, MoveTarget.position) <= 2f) {
			Destroy (gameObject);
		}
	}
}
