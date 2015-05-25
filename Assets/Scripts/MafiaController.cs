using UnityEngine;
using System.Collections;

public class MafiaController : MonoBehaviour {

	//private Transform target;
	public float speed;
	public int t1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (t1 == 1) {
			MoveTowardsTarget (GameObject.Find ("Target_Point_1").GetComponent<Transform> ());
		}
	}

	private void MoveTowardsTarget(Transform target) {
		Vector3 targetPosition = target.position;

		Vector3 currentPosition = transform.position;
		
		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			
			directionOfTravel.Normalize();
			
			transform.position += new Vector3((directionOfTravel.x * speed * Time.deltaTime) ,(directionOfTravel.y * speed * Time.deltaTime), 0);
		}
	}
}
