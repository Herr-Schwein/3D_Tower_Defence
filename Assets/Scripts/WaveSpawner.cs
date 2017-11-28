using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int WavesPerLevel = 3;
	public static int EnemiesAlive = 0;
	public Wave[] waves;
	public Transform spawnPoint;
	public float timeBetweenWaves = 3f;
	public Text waveCountDownText;
	public GameObject levelCompleteUI;
	public GameManager gameManager;

	private float countdown = 3f;
	private int waveIndex = 0;


	void Update () {

		if (EnemiesAlive > 0 && PlayerStats.Rounds % WavesPerLevel == 0 && PlayerStats.Rounds != 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinGame();
			this.enabled = false;
		}
			
		if (countdown <= 0f) {
			StartCoroutine (SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);
		waveCountDownText.text = string.Format ("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave() {
		
		PlayerStats.Rounds++;
		Wave wave = waves [waveIndex];
		for (int i = 0; i < wave.count; ++i) {
			SpawnEnemy (wave.enemy);
			yield return new WaitForSeconds (1f / wave.rate);
		}
		waveIndex++;

	}

	void SpawnEnemy (GameObject enemy) {
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive++;
	}
}
