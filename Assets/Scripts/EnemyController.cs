using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GlobalScript manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript>();
		transform.position = manager.enemyPos.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
