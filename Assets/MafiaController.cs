using UnityEngine;
using System.Collections;

public class MafiaController : MonoBehaviour {

	private Transform target;
	public float speed;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Target_Point_1").GetComponent<Transform> ();
		speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		MoveTowardsTarget ();
	}

	private void MoveTowardsTarget() {
		Vector3 targetPosition = target.position;

		Vector3 currentPosition = transform.position;
		
		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			
			directionOfTravel.Normalize();
			
			transform.position += new Vector3((directionOfTravel.x * speed * Time.deltaTime) ,(directionOfTravel.y * speed * Time.deltaTime), 0);
		}
	}
}
