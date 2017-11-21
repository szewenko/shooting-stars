using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Selector_help_menu : MonoBehaviour {

	public int tryb = 1;
	private Rigidbody rb;
	Vector3 position;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
			if (tryb == 1) {
                SceneManager.LoadScene ("_Scenes/Main_menu");
            }
		}
	}
}
