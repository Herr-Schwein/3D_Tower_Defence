using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	public float speed = 10f;
	private Transform target;
	private int waypointIndex = 0;





	// Use this for initialization
	void Start () {
		target = Waypoints.points [0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
		
		//Enemy.SetDestination (MoveTarget.position);
		if (Vector3.Distance (transform.position, target.position) <= 0.2f) {
			GetNextWaypoint ();
		}
	}

	void GetNextWaypoint () {
		if (waypointIndex >= Waypoints.points.Length - 1) {
			EndPath ();
			return;
		}
		waypointIndex++;
		target = Waypoints.points[waypointIndex];
	}

	void EndPath () {
		PlayerStats.Lives--;
		Destroy (gameObject);
	}
}
