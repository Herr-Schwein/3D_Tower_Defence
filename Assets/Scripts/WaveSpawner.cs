using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform EnemyPrefab;
	public Transform spawnPoint;

	public float timeBetweenWaves = 20f;
	public Text waveCountDownText;
	private float countdown = 5f;
	private int waveIndex = 0;


	// Update is called once per frame
	void Update () {

		if (countdown <= 0f) {
			StartCoroutine (SpawnWave());
			countdown = timeBetweenWaves;


		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);
		waveCountDownText.text = string.Format ("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave() {
		waveIndex++;

		for (int i = 0; i < waveIndex; ++i) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy () {
		Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);

	}
		
}
