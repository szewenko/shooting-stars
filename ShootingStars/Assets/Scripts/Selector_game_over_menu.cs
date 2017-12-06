using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selector_game_over_menu : MonoBehaviour {

	public int mode = 1;
    private float[] position_mode_1 = { (float)-0.22, (float)0.025, (float)0.4 };
    private float[] position_mode_2 = { (float)-0.22, (float)-0.1, (float)0.4 };
    private Rigidbody rb;
	Vector3 position;
    public Text score_text;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
        score_text.text = "Your score: " + GameController.score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			mode--;
			if (mode <1) mode = 2;
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)){
			mode++;
			if (mode > 2) mode = 1;
			}

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
            switch (mode)
            {
                case 1:
                    SceneManager.LoadScene("_Scenes/Game");
                    break;
                case 2:
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
            default:
                break;
        }
		rb.MovePosition(position);
	}
}
