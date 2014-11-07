using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float virtualWidth = 1920.0f;
	public float virtualHeight = 1080.0f;

	public GUIText scoreText;
	private int score;
	private Matrix4x4 matrix;

	void Start() {
		score = 0;
		matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}

	void OnGUI() {
		GUI.matrix = matrix;
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

}
