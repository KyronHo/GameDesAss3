﻿using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	public float moveSpeed = 1f;
	public float turnSpeed;
	public Vector3 lookAt;

	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
		   {
			transform.position += new Vector3 (0.0f, moveSpeed * Time.deltaTime, 0.0f);
			lookAt = transform.position + new Vector3 (0.0f, 0.1f, 0.0f);
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.position += new Vector3 (-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
			lookAt = transform.position + new Vector3 (-0.1f, 0.0f, 0.0f);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.position += new Vector3 (0.0f, -moveSpeed * Time.deltaTime, 0.0f);
			lookAt = transform.position + new Vector3 (0.0f, -0.1f, 0.0f);
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3 (moveSpeed * Time.deltaTime, 0.0f, 0.0f);
			lookAt = transform.position + new Vector3 (0.1f, 0.0f, 0.0f);
		}

		Vector3 norTar = (lookAt-transform.position).normalized;
		float angle = Mathf.Atan2(norTar.y,norTar.x)*Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, 0, angle ), turnSpeed * Time.deltaTime );
		EnforceBounds ();
	}

	void OnTriggerEnter2D( Collider2D other )
	{

//		if(other.CompareTag("Enemy")) {
//			Application.LoadLevel("WinScene");
//		}
	}

	private void EnforceBounds()
	{
		// 1
		Vector3 newPosition = transform.position; 
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;
		
		// 2
		float xDist = mainCamera.aspect * mainCamera.orthographicSize; 
		float xMax = cameraPosition.x + xDist -0.5f;
		float xMin = cameraPosition.x - xDist +0.5f;
		
		// 3
		if ( newPosition.x < xMin || newPosition.x > xMax ) {
			newPosition.x = Mathf.Clamp( newPosition.x, xMin, xMax );
			moveDirection.x = -moveDirection.x;
		}

		float yMax = mainCamera.orthographicSize -0.5f;
		
		if (newPosition.y < -yMax || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( newPosition.y, -yMax, yMax );
			moveDirection.y = -moveDirection.y;
		}
		
		// 4
		transform.position = newPosition;
	}
}