using UnityEngine;
using UnityEngine.UI;

public class HintText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(ShowHint);
	}
	
	void ShowHint() {
		foreach (Image i in GetComponentsInParent<Image>()) {
			i.enabled = true;
		}
		Destroy (transform.gameObject);
	}
}