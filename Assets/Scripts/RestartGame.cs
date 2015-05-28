using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {

	public int level;
	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(LoadLevel);
	}
	
	void LoadLevel() {
		if (level == 0) {
			Application.LoadLevel ("Roman_Intro");
		} else if (level == 1) {
			Application.LoadLevel ("Roman_Level");
		} else if (level == 2) {
			Application.LoadLevel ("Camelot_Level");
		} else if (level == 3) {
			Application.LoadLevel ("Sengoku_Level");
		} else if (level == 4) {
			Application.LoadLevel ("Mafia_Level");
		}
	}
}