using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {
	
	// Use this for initialization
	private Text timeLeft;
	public float timer = 0.0f;
	private float timerMax = 20.0f;
	public int level;
	private string vip;
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
		if (timer <= -1) 
		{
			loseScreen.SetActive(true);
			timer = -1;
		}

		if (level == 0) {
			vip = "Caesar";
		} else if (level == 1) {
			vip = "Arthur";
		} else if (level == 2) {
			vip = "Hideyoshi";
		}
		timeLeft.text = "Time until "+ vip + "'s death: " + timer.ToString("F2") + " Seconds";
	}
}
