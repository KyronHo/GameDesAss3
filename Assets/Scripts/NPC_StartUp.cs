using UnityEngine;
using System.Collections;

public class NPC_StartUp : MonoBehaviour
{

	private GlobalScript manager;
	public bool checkIn = false;
	private int i = 0;
	public int npcType;
	private Color[] npcColors = new Color[10];
	private float redSkin;
	private float blueSkin;
	private float greenSkin;
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		if (manager.level == 1) {
			lv2NPCColor ();
		} else {
			npcColor ();
		}
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
		redSkin = Random.Range (0.5f, 1f) + Random.Range(0, Random.Range (0f, .4f));
		blueSkin = redSkin - Random.Range(.15f, .3f);
		greenSkin = (redSkin + blueSkin)/2 - Random.Range(0f, .3f);
		npcColors [0] = new Color (Random.Range (0f, 1f), greenSkin, Random.Range (0f, 1f));
		npcColors [1] = new Color (redSkin, blueSkin, greenSkin);
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

	public void lv2NPCColor()
	{
		if (npcType == 0) {
			npcColors [0] = new Color (Random.Range (.3f, .6f), Random.Range (.3f, .6f), Random.Range (.3f, .6f));
			npcColors [1] = npcColors [0] + new Color (Random.Range (-.3f, .3f), Random.Range (-.3f, .3f), Random.Range (-.3f, .3f));
			npcColors [2] = npcColors [1];
			npcColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			npcColors [4] = npcColors [0] + new Color (Random.Range (-.3f, .3f), Random.Range (-.3f, .3f), Random.Range (-.3f, .3f));
			npcColors [5] = npcColors [4];
		} else {
			redSkin = Random.Range (0.5f, 1f);
			blueSkin = redSkin - Random.Range(.15f, .3f);
			greenSkin = (redSkin + blueSkin)/2 - Random.Range(0f, .3f);
			npcColors [0] = new Color (redSkin, blueSkin, greenSkin);
			npcColors [1] = new Color (.2f, Random.Range (0f, .5f)+.2f, Random.Range (0f, .5f)+.2f);
			npcColors [2] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			npcColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			npcColors [4] = npcColors[2] + new Color (Random.Range (-.3f, .3f), Random.Range (-.3f, .3f), Random.Range (-.3f, .3f));
			npcColors [5] = npcColors[4];
			npcColors [6] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			npcColors [7] = npcColors [6];
		}
		
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = npcColors [i];
			i++;
		}
		i = 0;
	}
}
