using UnityEngine;
using System.Collections;

public class NPC_StartUp : MonoBehaviour {

	private GlobalScript manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript>();
		if (manager.EnemyCheck()) 
		{
			manager.SetEnemyPos(GetComponent<Transform>());
			Destroy(transform.gameObject);
		}
		else print("i aint a spy");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
