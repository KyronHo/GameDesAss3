using UnityEngine;
using System.Collections;

public class IntroTimer : MonoBehaviour {

	public int level;
	public float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			if(level ==0){
			Application.LoadLevel("Roman_Level");
			}
			else if(level == 1){
				Application.LoadLevel("Camelot_Level");
			}
		}
	}
}
