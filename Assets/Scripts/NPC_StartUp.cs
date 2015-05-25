using UnityEngine;
using System.Collections;

public class NPC_StartUp : MonoBehaviour
{

	private GlobalScript manager;
	public bool checkIn = false;
	private int i = 0;
	public int npcType;
	private Color[] npcColors = new Color[12];
	private float redSkin;
	private float blueSkin;
	private float greenSkin;
	private float whiteSkin;
	public bool dead = false;
	private Animator animControl;
	public float roll;
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		if (manager.level == 1) {
			lv2NPCColor ();
		} else if (manager.level == 2) {
			lv3NPCColor();
			animControl = GetComponent<Animator>();
			if(npcType < 2){
				checkDeath (1000);
			}
		}else {
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

	void OnTriggerStay2D (Collider2D other)
	{
		if (manager.level == 2 && !other.CompareTag ("NPC") && npcType >= 3) {
			checkDeath(1499);
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
			redSkin = Random.Range (.7f, 1f);
			greenSkin = redSkin - Random.Range(0f, .2f);
			blueSkin = redSkin - Random.Range(.2f, .5f);
			whiteSkin = Random.Range(0, Random.Range(0, 0.5f));
			npcColors [0] = new Color (redSkin - whiteSkin, greenSkin - whiteSkin, blueSkin - whiteSkin);
			npcColors [1] = npcColors [0] + new Color (Random.Range (-.1f, .1f), Random.Range (-.1f, .1f), Random.Range (-.1f, .1f));
			npcColors [2] = npcColors [1];
			npcColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			npcColors [4] = npcColors [0] + new Color (Random.Range (-.1f, .1f), Random.Range (-.1f, .3f), Random.Range (-.1f, .1f));
			npcColors [5] = npcColors [4];
		} else {
			redSkin = Random.Range (0.5f, 1f);
			blueSkin = redSkin - Random.Range(.15f, .3f);
			greenSkin = (redSkin + blueSkin)/2 - Random.Range(0f, .3f);
			npcColors [0] = new Color (redSkin, blueSkin, greenSkin);
			npcColors [1] = new Color (.2f, Random.Range (0f, .5f)+.2f, Random.Range (0f, .5f)+.2f);
			npcColors [2] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			npcColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			npcColors [4] = npcColors[2] + new Color (Random.Range (-.2f, .2f), Random.Range (-.2f, .2f), Random.Range (-.3f, .3f));
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

	public void lv3NPCColor()
	{
		if (npcType == 0 || npcType == 3) {
			redSkin = Random.Range (0.5f, 1f) + Random.Range (0, Random.Range (0f, .4f));
			blueSkin = redSkin - Random.Range (.15f, .3f);
			greenSkin = (redSkin + blueSkin) / 2 - Random.Range (0f, .3f);
			whiteSkin = Random.Range (0f, .4f);
			npcColors [0] = new Color (whiteSkin + Random.Range (0, 0.1f), whiteSkin + Random.Range (0, 0.2f), whiteSkin + Random.Range (0f, .5f)) + new Color (0, 0, 0);
			npcColors [1] = new Color (redSkin, blueSkin, greenSkin); 
			npcColors [2] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [3] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [4] = npcColors [3];
			npcColors [5] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [6] = npcColors [5];
			npcColors [7] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [8] = npcColors [7];
			npcColors [9] = new Color (1, 1, 1);
			npcColors [10] = new Color (1, 1, 1);
			npcColors [11] = new Color (1, 1, 1);
		} else {
			redSkin = Random.Range (0.5f, 1f) + Random.Range (0, Random.Range (0f, .4f));
			blueSkin = redSkin - Random.Range (.15f, .3f);
			greenSkin = (redSkin + blueSkin) / 2 - Random.Range (0f, .3f);
			whiteSkin = Random.Range (0f, .2f);
			npcColors [0] = new Color (whiteSkin + Random.Range (0.2f, 0.7f), whiteSkin + Random.Range (0, 0.2f), whiteSkin + Random.Range (0f, .1f)) + new Color (0, 0, 0);
			npcColors [1] = new Color (redSkin, blueSkin, greenSkin); 
			npcColors [2] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [3] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [4] = npcColors [3];
			npcColors [5] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [6] = npcColors [5];
			npcColors [7] = npcColors [0] + new Color (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f));
			npcColors [8] = npcColors [7];
			npcColors [9] = new Color (1, 1, 1);
			npcColors [10] = new Color (1, 1, 1);
		}

		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = npcColors [i];
			i++;
		}
		i = 0;

		if (npcType >= 3) {
			checkIn = true;
		} 
	}

	public void checkDeath(int chance)
	{
		roll = Random.Range (0, 1500f);
		if(roll>chance){
		animControl.SetTrigger("Death");
		gameObject.tag = "NPC";
		}
	}
}
