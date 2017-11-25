using UnityEngine;

public class TileUI : MonoBehaviour {
	public GameObject ui;
	private Tile target;

	public void SetTarget (Tile _target) {
		target = _target;
		transform.position = target.GetBuildPosition();
		ui.SetActive (true);
	}

	public void Hide () {
		ui.SetActive (false);
	}

}
