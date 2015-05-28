using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {
	
	// Use this for initialization
	private Text timeLeft;
	public float timer = 0.0f;
	private float timerMax = 20.00f;
	public int level;
//	private string vip;
	public GameObject loseScreen;
	private GlobalScript manager;

	
	void Start () {
		timeLeft = GetComponent<Text>();
		timer = timerMax;
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		manager.ui = this;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (level == -1) {
			timer = timerMax;
		}

		if (timer <= -1) {
			loseScreen.SetActive (true);
			timer = -1;
		}
		if (timer <= 5 && timer > 0) {
			timeLeft.color = new Color (1, timer / 5, 0);
			timeLeft.fontSize = 20;
			timeLeft.text = timer.ToString ("F0");
		} else if(timer < 0){
			timeLeft.fontSize = 14;
			timeLeft.text = "Dead";
		}
		else{
			timeLeft.text = timer.ToString ("F2");
		}
	}
}
