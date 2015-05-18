using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour
{

	public int seed;
	public int npcNo = 0;
	public Vector3 enemyPos;
	public EnemyController enemy;
	public PortraitController portrait;
	public int level;

	// Use this for initialization
	void Start ()
	{
		if (level == 0) {
			seed = Random.Range (0, 8);
		} else if (level == 1) {
			seed = Random.Range (0, 12); //no. is no.of npcs
		}
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
