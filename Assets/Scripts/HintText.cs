using UnityEngine;
using UnityEngine.UI;

public class HintText : MonoBehaviour {
	
	public int level;
	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(ShowHint);
	}
	
	void ShowHint() {
		foreach (Image i in GetComponentsInChildren<Image>()) {
			i.enabled = true;
		}
	}
}