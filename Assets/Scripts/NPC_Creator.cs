using UnityEngine;
using System.Collections;

public class NPC_Creator : MonoBehaviour {

	//1
	public float minSpawnTime = 0.75f; 
	public float maxSpawnTime = 2f; 

	public GameObject tablePrefab;

	public Vector3 [] tablePos;

//	tablepos[0] = (0, -4, 0);
//	tablepas[1] = (0, -1.5, 0);
//	tablepos[2] = (-3, -1.5, 0);
//	tablepos[3] = (-6, -4, 0);
//	tablepos[4] = (-6, -1.5, 0);
//	tablepos[5] = (-3, -4, 0);

	public bool [] seatTaken;

	//2    
	void Start () {
		for(int i = 0; i < 6; i++) {
			SpawnTable(i);
		}

	}
	
	//3
	void SpawnTable(int i)
	{
		// 1
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize - 0.5f;
		
		// 2
//		Vector3 tablePos = tablePos[i];
		
		// 3
	//	Instantiate(tablePrefab, tablePos, Quaternion.identity);
	}
}
