using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterWindow : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("hit window");
		if (other.gameObject.layer == 10)
		{
			Debug.Log("Win!");
			SceneManager.LoadScene("Win");
		}
	}
}
