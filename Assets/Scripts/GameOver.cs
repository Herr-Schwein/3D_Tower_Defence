using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text roundText;
	public string menuSceneName = "MainMenu";

	void OnEnable () {
		roundText.text = PlayerStats.Rounds.ToString();
	}

	public void Retry () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu () {
		SceneManager.LoadScene(menuSceneName);
	}
}
