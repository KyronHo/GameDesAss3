using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {
	
	// Use this for initialization
	private Text timeLeft;
	private float timer = 0.0f;
	private float timerMax = 20.0f;
	public int level;
	private string vip;
	
	void Start () {
		timeLeft = GetComponent<Text>();
		timer = timerMax;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= -1) 
		{
			Application.LoadLevel("LoseScene");
		}

		timer -= Time.deltaTime;
		if (level == 0) {
			vip = "Caesar";
		}else if(level ==1) {
			vip = "Arthur";
		}
		timeLeft.text = "Time until "+ vip + "'s death: " + timer.ToString("F2") + " Seconds";
	}
}
