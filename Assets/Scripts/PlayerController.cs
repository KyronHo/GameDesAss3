using UnityEngine;
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
	public float angle;
	public int friendly = 0;
	public int level;

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
				if (manager.level == 1){
				manager.portrait.showPart (Random.Range (0, 8), manager.enemyType);
					friendly = 1;
				}
				else{
					manager.portrait.showPart (Random.Range (0, 8));
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			if (friendly == 1)
			{
				if(level == 0)
				{
					Application.LoadLevel("Camelot_Intro");
				}
			}
		}
		EnforceBounds ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Enemy")) {
			Interact (other);
			friendly = 1;
		}
		if (other.CompareTag ("NPC")) {
			Interact (other);
			friendly = 2;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
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