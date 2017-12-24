using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Selector_main_menu : MonoBehaviour {

	public int mode = 1;
    public AudioSource[] aSources;
    private float[] position_mode_1 = { (float)0.05, (float)0.156, (float)0.4 };
    private float[] position_mode_2 = { (float)0.05, (float)0.058, (float)0.4 };
    private float[] position_mode_3 = { (float)0.05, (float)-0.03, (float)0.4 };
    private float[] position_mode_4 = { (float)0.05, (float)-0.123, (float)0.4 };
    private Rigidbody rb;
	Vector3 position;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			mode--;
			if (mode <1) mode = 4;
            GetComponent<AudioSource>().Play();
        }

		if (Input.GetKeyDown (KeyCode.DownArrow)){
			mode++;
			if (mode > 4) mode = 1;
            GetComponent<AudioSource>().Play();
        }

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
            
            switch (mode)
            {
                case 1:
                    SceneManager.LoadScene("_Scenes/Game");
                    break;
                case 2:
                    SceneManager.LoadScene("_Scenes/Help_menu");
                    break;
                case 3:
                    SceneManager.LoadScene("_Scenes/About_menu");
                    break;
                case 4:
                    Application.Quit();
                    break;
                default:
                    break;
            }
		}

        switch (mode)
        {
            case 1:
                position.Set(position_mode_1[0], position_mode_1[1], position_mode_1[2]);
                break;
            case 2:
                position.Set(position_mode_2[0], position_mode_2[1], position_mode_2[2]);
                break;
            case 3:
                position.Set(position_mode_3[0], position_mode_3[1], position_mode_3[2]);
                break;
            case 4:
                position.Set(position_mode_4[0], position_mode_4[1], position_mode_4[2]);
                break;
            default:
                break;
        }
		rb.MovePosition(position);
	}
}
