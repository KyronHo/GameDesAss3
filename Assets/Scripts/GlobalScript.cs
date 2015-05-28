using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour
{

	public int seed;
	public int npcNo = 0;
	public Vector3 enemyPos;
	public EnemyController enemy;
	public PortraitController portrait;
	public UIUpdater ui;
	public int enemyType;
	public int level;

	// Use this for initialization
	void Start ()
	{
		if (level == 0) {
			seed = Random.Range (0, 8);
		} else if (level == 1) {
			seed = Random.Range (0, 12); //no. is no.of npcs
		} else if (level == 2) {
			seed = Random.Range (0, 8);
		} else if (level == 3) {
			seed = Random.Range (0,9);
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

	public void SetEnemyType(int i)
	{
		enemyType = i;
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
