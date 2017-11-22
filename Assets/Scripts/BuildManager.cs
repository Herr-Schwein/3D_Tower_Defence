using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake () {
		if (instance != null) {

			Debug.LogError ("More than one build manager.");
			return;
		}
		instance = this;
	}

	public GameObject standardTurretPrefab;
	public GameObject frozenTurretPrefab;

	private TurretBlueprint turretToBuild;

	// Use this for initialization
	public void SelectTurretToBuild (TurretBlueprint turret) {
		turretToBuild = turret;
	}

	public void BuildTurretOn (Tile tile) {
		if (PlayerStats.Money < turretToBuild.cost) {
			Debug.Log ("Not enough money.");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;
		GameObject turret = (GameObject)Instantiate (turretToBuild.Prefab, tile.GetBuildPosition(), Quaternion.identity);
		tile.turret = turret;

		Debug.Log ("Money left " + PlayerStats.Money);
	}

	public bool CanBuild { get { return turretToBuild != null;} }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;} }
	// Update is called once per frame
	void Update () {
		
	}
}
