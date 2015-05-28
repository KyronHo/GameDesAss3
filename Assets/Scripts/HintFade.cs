using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintFade : MonoBehaviour {

	private float timer;
	public Color temp;
	// Use this for initialization
	void Start () {
		timer = 5f;
		temp = gameObject.GetComponent<Image>().color;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Image>().enabled == true) {
			timer -= Time.deltaTime;
			if(timer < 0){
				temp.a -= .01f;
				gameObject.GetComponent<Image>().color = temp;}
		}
		if (temp.a <= 0f) {
			Destroy (transform.gameObject);
		}
	}
}
