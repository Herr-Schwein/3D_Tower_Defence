using UnityEngine;

public class Shop : MonoBehaviour {
	public TurretBlueprint standardTurret;
	public TurretBlueprint frozenTurret;

	BuildManager buildManager;

	public void SelectStandardTurret(){
		Debug.Log("Standard Turret Purchased.");
		buildManager.SelectTurretToBuild (standardTurret);
	}

	public void SelectFrozenTurret(){
		Debug.Log("Standard Turret Purchased.");
		buildManager.SelectTurretToBuild (frozenTurret);
	}

	// Use this for initialization
	void Start () {
		buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame  
	void Update () { 
		
	}
}
