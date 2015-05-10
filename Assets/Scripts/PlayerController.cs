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
				manager.portrait.showPart (Random.Range (0, 8));
			}
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			if (friendly == 1){
				Application.LoadLevel("Camelot_Intro");
			}
		}
//		Vector3 norTar = (lookAt - transform.position).normalized;
//		angle = Mathf.Atan2 (norTar.y, norTar.x) * Mathf.Rad2Deg;
//		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, angle), turnSpeed * Time.deltaTime);
		EnforceBounds ();
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.CompareTag ("Roman_Enemy")) {
			Interact ();
			friendly = 1;
		}
		if (other.CompareTag ("Roman_NPC")) {
			Interact ();
			friendly = 2;
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		interactableOn.enabled = false;
		}

	private void Interact ()
	{
		interactable.position = transform.position;
		interactable.position += new Vector3 (0.3f, 0.7f, 0);
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