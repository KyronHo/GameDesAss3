using UnityEngine;
using System.Collections;

public class NPC_StartUp : MonoBehaviour
{

	private GlobalScript manager;
	public bool checkIn = false;
	private int i = 0;
	public int npcType;
	private Color[] npcColors = new Color[10];
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		npcColor ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (checkIn == false) {
			if (manager.EnemyCheck ()) {
				manager.SetEnemyType(npcType);
				manager.SetEnemyPos (transform.position);
				Destroy (transform.gameObject);
			}
			checkIn = true;
		}
	}

	public void npcColor ()
	{
		npcColors [0] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		npcColors [1] = new Color (Random.Range (0.5f, 1f), Random.Range (0.5f, 1f), Random.Range (0.5f, 1f));
		npcColors [2] = npcColors [1];
		npcColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		npcColors [4] = npcColors [1];
		npcColors [5] = npcColors [1];
		npcColors [6] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		npcColors [7] = npcColors [6];
		npcColors [8] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		npcColors [9] = npcColors [8];

		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = npcColors [i];
			i++;
		}
		i = 0;
	}
}
