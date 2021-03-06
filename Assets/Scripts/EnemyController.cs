﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

	private GlobalScript manager;
	public Color[] enemyColors = new Color[12];
	private int i = 0;
	public float speed;
	private Transform target;
	public bool placed = false;
	private float timer = 20;
	private Transform type0;
	private Transform type1;
	public int level;
	private float redSkin;
	private float blueSkin;
	private float greenSkin;
	private float whiteSkin;
	private int type = -1;
	private Animator animControl;
	private bool shooting;
	private Vector3 prevloc;
	private bool appear = false;
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		manager.enemy = this;
		if (level == 0) {
			target = GameObject.Find ("Roman_VIP").GetComponent<Transform> ();
			EnemyColor ();
		} else if (level == 1) {
			target = GameObject.Find ("Camelot_VIP_Body").GetComponent<Transform> ();
			type0 = GameObject.Find ("0").GetComponent<Transform> ();
			type1 = GameObject.Find ("1").GetComponent<Transform> ();
		} else if (level == 2) {
			type0 = GameObject.Find ("0").GetComponent<Transform> ();
			type1 = GameObject.Find ("1").GetComponent<Transform> ();
			animControl = GetComponentInChildren<Animator> ();
		} else if (level == 3) {
			lv4EnemyColor();
			animControl = GetComponent<Animator> ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (placed == false && manager.enemyPos != new Vector3(0,0,0)) 
		{
			transform.position = manager.enemyPos;
			placed = true;
		}
		if (level == 0) {
			foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
				if (i == enemyColors.Length) {
					i = 0;
				}
				sr.material.color = enemyColors [i];
				i++;
			}
			i = 0;
		}
		if (level == 1) {
			Typecheck (manager.enemyType);
			lv2EnemyColor();
		}else if (level == 2){
			Typecheck (manager.enemyType);
			lv3EnemyColor();
		}else if(level == 3){
			transform.position = manager.enemyPos;
		}
		timer -= Time.deltaTime;
		if (timer <= 2.5f && level < 2 && level != -1) {
			MoveTowardsTarget ();
		} else if (level == 2) {
			if (timer <= 1f && shooting == false) {
				shootTarget ();
				shooting = true;
			} else if (timer < 0f && !GetComponent<AudioSource> ().isPlaying && timer > -1f) {
				GetComponent<AudioSource> ().Play ();
			}
		}
		if (level == 3) {
			if(GetComponent<Transform>().position.z >= -1){
				animControl.enabled = true;
			}else{
				animControl.enabled = false;
			}
			if(prevloc != GetComponent<Transform>().position){
				animControl.SetBool("FaceCamera", false);
			}else{
				animControl.SetBool("FaceCamera", true);
			}
			if (timer <= 2f && shooting == false) {
				shootTarget ();
				shooting = true;
			} else if (timer < 1f && !GetComponent<AudioSource> ().isPlaying && timer > -1f) {
				GetComponent<AudioSource> ().Play ();
			}
			prevloc = GetComponent<Transform>().position;
		}
	}

	public void EnemyColor ()
	{
		redSkin = Random.Range (0.5f, 1f) + Random.Range(0, Random.Range (0f, .4f));
		blueSkin = redSkin - Random.Range(.15f, .3f);
		greenSkin = (redSkin + blueSkin)/2 - Random.Range(0f, .3f);
		enemyColors [0] = new Color (Random.Range (0f, 1f), greenSkin, Random.Range (0f, 1f));
		enemyColors [1] = new Color (redSkin, blueSkin, greenSkin);
		enemyColors [2] = enemyColors [1];
		enemyColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		enemyColors [4] = enemyColors [1];
		enemyColors [5] = enemyColors [1];
		enemyColors [6] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		enemyColors [7] = enemyColors [6];
		
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			if(i== enemyColors.Length)
			{
				i=0;
			}
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
	}

	public void lv2EnemyColor()
	{
		if (redSkin == 0) {
			if (manager.enemyType == 0) {
				redSkin = Random.Range (.7f, 1f);
				greenSkin = redSkin - Random.Range(0f, .2f);
				blueSkin = redSkin - Random.Range(.2f, .5f);
				whiteSkin = Random.Range(0, Random.Range(0, 0.5f));
				enemyColors [0] = new Color (redSkin - whiteSkin, greenSkin - whiteSkin, blueSkin - whiteSkin);
				enemyColors [1] = enemyColors [0] + new Color (Random.Range (-.1f, .1f), Random.Range (-.1f, .1f), Random.Range (-.1f, .1f));
				enemyColors [2] = enemyColors [1];
				enemyColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
				enemyColors [4] = enemyColors [0] + new Color (Random.Range (-.1f, .1f), Random.Range (-.1f, .1f), Random.Range (-.1f, .1f));
				enemyColors [5] = enemyColors [4];
				redSkin = 1;
			} else {
				redSkin = Random.Range (0.5f, 1f);
				blueSkin = redSkin - Random.Range (.15f, .3f);
				greenSkin = (redSkin + blueSkin) / 2 - Random.Range (0f, .3f);
				enemyColors [0] = new Color (redSkin, blueSkin, greenSkin);
				enemyColors [1] = new Color (.2f, Random.Range (0f, .5f) + .2f, Random.Range (0f, .5f) + .2f);
				enemyColors [2] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
				enemyColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
				enemyColors [4] = enemyColors [2] + new Color (Random.Range (-.3f, .3f), Random.Range (-.3f, .3f), Random.Range (-.3f, .3f));
				enemyColors [5] = enemyColors [4];
				enemyColors [6] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
				enemyColors [7] = enemyColors [6];
			}
			whiteSkin = 0;
			foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
				if (i == 6 && whiteSkin ==0) {
					i = 0;
					whiteSkin = 1;
				}
				sr.material.color = enemyColors [i];
				i++;
			}
			i = 0;
		}
	}

	public void lv3EnemyColor()
	{
		if (manager.enemyType != type) {
			if (manager.enemyType == 0) {
				redSkin = Random.Range (0.5f, 1f) + Random.Range (0, Random.Range (0f, .4f));
				blueSkin = redSkin - Random.Range (.15f, .3f);
				greenSkin = (redSkin + blueSkin) / 2 - Random.Range (0f, .3f);
				whiteSkin = Random.Range (0f, .4f);
				enemyColors [0] = new Color (whiteSkin + Random.Range (0, 0.1f), whiteSkin + Random.Range (0, 0.2f), whiteSkin + Random.Range (0f, .5f)) + new Color (0, 0, 0);
				enemyColors [1] = new Color (redSkin, blueSkin, greenSkin); 
				enemyColors [2] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [3] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [4] = enemyColors [3];
				enemyColors [5] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [6] = enemyColors [5];
				enemyColors [7] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [8] = enemyColors [7];
				enemyColors [9] = new Color (1, 1, 1);
				enemyColors [10] = new Color (1, 1, 1);
				enemyColors [11] = new Color (1, 1, 1);
				type = 0;
			} else {
				redSkin = Random.Range (0.5f, 1f) + Random.Range (0, Random.Range (0f, .4f));
				blueSkin = redSkin - Random.Range (.15f, .3f);
				greenSkin = (redSkin + blueSkin) / 2 - Random.Range (0f, .3f);
				whiteSkin = Random.Range (0f, .2f);
				enemyColors [0] = new Color (whiteSkin + Random.Range (0.2f, 0.7f), whiteSkin + Random.Range (0, 0.2f), whiteSkin + Random.Range (0f, .1f)) + new Color (0, 0, 0);
				enemyColors [1] = new Color (redSkin, blueSkin, greenSkin); 
				enemyColors [2] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [3] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [4] = enemyColors [3];
				enemyColors [5] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [6] = enemyColors [5];
				enemyColors [7] = enemyColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
				enemyColors [8] = enemyColors [7];
				enemyColors [9] = new Color (1, 1, 1);
				enemyColors [10] = new Color (1, 1, 1);
				enemyColors [11] = new Color (1, 1, 1);
				type =1;
			}
			whiteSkin = 0;
			foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
				if (i == 11 && whiteSkin == 0) {
					i = 0;
					whiteSkin = 1;
				}
				sr.material.color = enemyColors [i];
				i++;
			}
			i = 0;
		}
	}

	public void lv4EnemyColor()
	{
		redSkin = Random.Range (0.5f, 1f) + Random.Range(0, Random.Range (0f, .4f));
		blueSkin = redSkin - Random.Range(.15f, .3f);
		greenSkin = (redSkin + blueSkin)/2 - Random.Range(0f, .3f);
		whiteSkin = Random.Range (0f, .4f);
		enemyColors [0] = new Color (0, 0, 0);
		enemyColors [1] = new Color (redSkin + whiteSkin, blueSkin + whiteSkin, greenSkin + whiteSkin);
		enemyColors [2] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		enemyColors [3] = enemyColors [1];
		enemyColors [4] = enemyColors [1];
		enemyColors [5] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		enemyColors [6] = enemyColors [5];
		enemyColors [7] = new Color (.5f, .3f, .05f);
		enemyColors [8] = new Color (1, 1, 1);
		enemyColors [9] = new Color (1, 1, 1);
		
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
	}

	public void Typecheck(int t)
	{
		if (t == 0) {
			foreach (SpriteRenderer sr in type1.GetComponentsInChildren<SpriteRenderer>()) {
				sr.enabled = false;
			}
			foreach (SpriteRenderer sr in type0.GetComponentsInChildren<SpriteRenderer>()) {
				sr.enabled = true;
			}
		} else if (t == 1) {
			foreach (SpriteRenderer sr in type0.GetComponentsInChildren<SpriteRenderer>()) {
				sr.enabled = false;
			}
			foreach (SpriteRenderer sr in type1.GetComponentsInChildren<SpriteRenderer>()) {
				sr.enabled = true;
			}
		}
	}

	private void MoveTowardsTarget() {
		Vector3 targetPosition = target.position;
		if (level == 0) {
			targetPosition += new Vector3 (0, -2, 0);
		} else if (level == 1) {
			targetPosition += new Vector3 (-1, 0, 0);
		}
		Vector3 currentPosition = transform.position;

		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;

			directionOfTravel.Normalize();
			
			transform.position += new Vector3((directionOfTravel.x * speed * Time.deltaTime) ,(directionOfTravel.y * speed * Time.deltaTime), 0);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (manager.level < 2) {
			if (other.CompareTag ("VIP")) {
				GetComponent<AudioSource> ().Play ();
			}
		}
	}

	private void shootTarget(){
		animControl.SetTrigger("Killing_VIP");
	}

}
