using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour
{

	public int seed;
	public int npcNo = 0;
	public Vector3 enemyPos;
	public EnemyController enemy;

	// Use this for initialization
	void Start ()
	{
		seed = Random.Range (0, 8);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetEnemyPos (Vector3 i)
	{
		enemyPos = i;
	}

	public bool EnemyCheck ()
	{
		if (npcNo == seed) {
			npcNo++;
			return true;
		} else {
			npcNo++;
			return false;
		}
	}
}
