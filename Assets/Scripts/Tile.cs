using UnityEngine.EventSystems;
using UnityEngine;


public class Tile : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 postionOffset;

	[Header ("optional")]
	public GameObject turret;


	private Renderer rend;
	private Color startColor;




	BuildManager buildManager;



	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;

		
	}

	public Vector3 GetBuildPosition () {
		return transform.position + postionOffset;
	}

	void OnMouseEnter () {
		if (EventSystem.current.IsPointerOverGameObject ())
			return;
		
		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;
		} else {
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit () {

		rend.material.color = startColor;

	}

	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject ())
			return;
		
		if (!buildManager.CanBuild)
			return;
		

		if (turret != null) {
			Debug.Log ("Can not build here.");
			return;
		}

		buildManager.BuildTurretOn (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
