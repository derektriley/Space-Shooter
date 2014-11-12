using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private int score;
	private Matrix4x4 matrix;
	public Texture2D num0;
	public Texture2D num1;
	public Texture2D num2;
	public Texture2D num3;
	public Texture2D num4;
	public Texture2D num5;
	public Texture2D num6;
	public Texture2D num7;
	public Texture2D num8;
	public Texture2D num9;

	void Start() {
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}

	void DestroyAllScoreNumbers()
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Number");
		for(int i = 0 ; i < gameObjects.Length ; i ++)
		{
			Destroy(gameObjects[i]);
		}
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
		DestroyAllScoreNumbers ();
		string scoreString = score.ToString ();
		for (int i = 0; i < scoreString.Length; i++) {
			GameObject number = new GameObject ("ScoreNumber");
			number.tag = "Number";
			number.AddComponent ("GUITexture");
			number.guiTexture.texture = charToGUITexture(scoreString[i]);
			number.transform.position = new Vector3 (0.32f + (i * 0.06f), 0.97f, 8.5f);
			number.transform.localScale = new Vector3 (0.07f, 0.05f, 1.0f);
		}
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public Texture2D charToGUITexture(char c) {
		switch (c)
		{
		case '0':
			return num0;
			break;
		case '1':
			return num1;
			break;
		case '2':
			return num2;
			break;
		case '3':
			return num3;
			break;
		case '4':
			return num4;
			break;
		case '5':
			return num5;
			break;
		case '6':
			return num6;
			break;
		case '7':
			return num7;
			break;
		case '8':
			return num8;
			break;
		case '9':
			return num9;
			break;
		default:
			Debug.LogError("charToGUITexture failed");
			return null;
			break;
		}

	}

}
