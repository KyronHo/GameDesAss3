using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {
	
	// Use this for initialization
	private Text timeLeft;
	private float timer = 0.0f;
	private float timerMax = 20.0f;
	
	void Start () {
		timeLeft = GetComponent<Text>();
		timer = timerMax;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0) 
		{
			Application.LoadLevel("LoseScene");
		}

		timer -= Time.deltaTime;
		timeLeft.text = "Time until Caesar's death: " + timer.ToString("F2") + " Seconds";
	}
}
