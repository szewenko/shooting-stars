using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Selector_main_menu : MonoBehaviour {

	public int tryb = 1;
	private Rigidbody rb;
	Vector3 position;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			tryb--;
			if (tryb <1)
				tryb = 4;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)){
			tryb++;
			if (tryb > 4)
				tryb = 1;
			}

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
			if (tryb == 1) {
                SceneManager.LoadScene ("_Scenes/Game");
            }
			if (tryb == 2) {
                SceneManager.LoadScene("_Scenes/Help_menu");
            }
			if (tryb == 3) {
                SceneManager.LoadScene("_Scenes/About_menu");
            }
			if (tryb == 4) {
				Application.Quit();
			}
		}

		if (tryb == 1) {
			position.Set((float)0.05, (float)0.156, (float)0.4);
		}
		if (tryb == 2) {
			position.Set((float)0.05, (float)0.058, (float)0.4);
		}
		if (tryb == 3) {
			position.Set((float)0.05, (float)-0.03, (float)0.4);
		}
		if (tryb == 4) {
			position.Set((float)0.05, (float)-0.123, (float)0.4);
		}
		rb.MovePosition(position);
	}
}
