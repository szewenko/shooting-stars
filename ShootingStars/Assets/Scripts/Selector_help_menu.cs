using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Selector_help_menu : MonoBehaviour {

	// Use this for initialization
	void Start() { }
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("_Scenes/Main_menu");
	}
}
