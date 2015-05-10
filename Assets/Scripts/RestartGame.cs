using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(LoadLevel);
	}
	
	void LoadLevel() {
		Application.LoadLevel("Roman_Level");
	}
}