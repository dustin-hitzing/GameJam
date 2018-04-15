using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string name) {
		Debug.Log("Load scene: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Application.Quit();
	}
}
