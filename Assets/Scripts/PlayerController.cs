﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 1f;
	public float turnSpeed;
//	public Vector3 lookAt;
	private Vector3 moveDirection;
	private GlobalScript manager;
	private Transform interactable;
	private SpriteRenderer interactableOn;
	//public float angle;
	public int friendly = 0;
	public int level;
	public int tPortrait = 0;

	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		interactable = GameObject.Find ("Interactable").GetComponent<Transform> ();
		interactableOn = interactable.GetComponentInChildren<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3 (0.0f, moveSpeed * Time.deltaTime, 0.0f);
			//lookAt = transform.position + new Vector3 (0.0f, 0.1f, 0.0f);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3 (-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
			//lookAt = transform.position + new Vector3 (-0.1f, 0.0f, 0.0f);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += new Vector3 (0.0f, -moveSpeed * Time.deltaTime, 0.0f);
			//lookAt = transform.position + new Vector3 (0.0f, -0.1f, 0.0f);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (moveSpeed * Time.deltaTime, 0.0f, 0.0f);
			//lookAt = transform.position + new Vector3 (0.1f, 0.0f, 0.0f);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			if (friendly == 2) {
				GetComponent<AudioSource>().Play();
				GameObject.Find ("Wanted").GetComponent<Animator> ().SetTrigger ("Vibrate");
				if (manager.level == 1){
				manager.portrait.showPart (Random.Range (0, 8), manager.enemyType);
					friendly = 3;
					interactableOn.enabled = false;
				}
				else if(manager.level == 2){
					manager.portrait.showPart (Random.Range (0, 9), manager.enemyType);
					friendly = 3;
					interactableOn.enabled = false;
				}
				else if(level == -1){
					if(tPortrait == 0){
						GameObject.Find ("tEnemyPortrait1").GetComponent<SpriteRenderer> ().enabled = true;
						tPortrait++;
					}else if (tPortrait == 1){
						GameObject.Find ("tEnemyPortrait2").GetComponent<SpriteRenderer> ().enabled = true;
						tPortrait++;
					}else if (tPortrait == 2){
						GameObject.Find ("tEnemyPortrait3").GetComponent<SpriteRenderer> ().enabled = true;
						tPortrait++;
					}else if (tPortrait == 3){
						GameObject.Find ("tEnemyPortrait4").GetComponent<SpriteRenderer> ().enabled = true;
						tPortrait++;
					}else if (tPortrait == 4){
						GameObject.Find ("tEnemyPortrait5").GetComponent<SpriteRenderer> ().enabled = true;
						tPortrait++;
					}else if (tPortrait == 5){
						GameObject.Find ("tEnemyPortrait6").GetComponent<SpriteRenderer> ().enabled = true;
					}
					friendly = 3;
					interactableOn.enabled = false;
				}
				else{
					manager.portrait.showPart (Random.Range (0, 8));
					friendly = 3;
					interactableOn.enabled = false;
				}
			}else{
				GetComponent<AudioSource>().Play();
				GameObject.Find ("Wanted").GetComponent<Animator> ().SetTrigger ("Vibrate");
				interactableOn.enabled = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			if (friendly == 1)
			{
				manager.GetComponent<AudioSource>().Play();
				if(level == 0)
				{
					Application.LoadLevel("Camelot_Intro");
				}
				if(level == 1)
				{
					Application.LoadLevel("Sengoku_Intro");
				}
				if (level == 2)
				{
					Application.LoadLevel("Mafia_Intro");
				}
				if(level == 3){
					Application.LoadLevel("WinScene");
				}
				if(level == -1){
					GameObject.Find ("tEnemy").GetComponent<Transform>().position = new Vector3(-200,-200,1);
					interactableOn.enabled = false;
					friendly = 3;
				}
			}
		}
		if (manager.ui.timer <= 0 && level != -1) {
			this.enabled = false;
		}
		EnforceBounds ();
	}

	void OnTriggerExit2D(Collider2D other) {
		if (interactable.position == (other.transform.position + new Vector3 (0.4f, 0.8f, 0))) {
			interacted ();
		}
		if (level == 3) {
			interacted();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("NPC")) {
			Interact (other);
			friendly = 2;
		}else if (other.CompareTag ("Enemy") && level !=2) {
			Interact (other);
			friendly = 1;
		}else if(other.CompareTag ("Enemy") && level == 2){
			friendly = 1;
		}
	}

	void OnTriggerStay2D (Collider2D other){
	}

	private void interacted(){
		interactableOn.enabled = false;
	}

	private void Interact (Collider2D other)
	{
		interactable.position = other.transform.position;
		interactable.position += new Vector3 (0.4f, 0.8f, 0);
		interactableOn.enabled = true;
	}

	private void EnforceBounds ()
	{
		// 1
		Vector3 newPosition = transform.position; 
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;
		
		// 2
		float xDist = mainCamera.aspect * mainCamera.orthographicSize; 
		float xMax = cameraPosition.x + xDist - 0.5f;
		float xMin = cameraPosition.x - xDist + 0.5f;
		
		// 3
		if (newPosition.x < xMin || newPosition.x > xMax) {
			newPosition.x = Mathf.Clamp (newPosition.x, xMin, xMax);
			moveDirection.x = -moveDirection.x;
		}

		float yMax = mainCamera.orthographicSize - 0.5f;
		
		if (newPosition.y < -yMax || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp (newPosition.y, -yMax, yMax);
			moveDirection.y = -moveDirection.y;
		}
		
		// 4
		transform.position = newPosition;
	}
}