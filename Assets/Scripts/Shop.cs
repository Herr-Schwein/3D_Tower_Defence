using UnityEngine;

public class Shop : MonoBehaviour {
	public TurretBlueprint standardTurret;
	public TurretBlueprint frozenTurret;
	public TurretBlueprint deathStar;

	BuildManager buildManager;

	public void SelectStandardTurret(){
		buildManager.SelectTurretToBuild (standardTurret);
	}

	public void SelectFrozenTurret(){
		buildManager.SelectTurretToBuild (frozenTurret);
	}

	public void SelectDeathStar(){
		buildManager.SelectTurretToBuild (deathStar);
	}

	// Use this for initialization
	void Start () {
		buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame  
	void Update () { 
		
	}
}
