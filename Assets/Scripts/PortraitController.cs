using UnityEngine;
using System.Collections;

public class PortraitController : MonoBehaviour
{
	
	private GlobalScript manager;
	public Color[] enemyColors = new Color[8];
	private int i = 0;
	private Transform type0;
	private Transform type1;
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		manager.portrait = this;
		type0 = GameObject.Find ("p0").GetComponent<Transform>();
		type1 = GameObject.Find ("p1").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (i=0; i < 8; i++) {
			enemyColors[i] = manager.enemy.enemyColors[i];
		}
		i = 0;
		EnemyColor ();
	}
	
	public void EnemyColor ()
	{		
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			if(i== enemyColors.Length)
			{
				i=0;
			}
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
	}

	public void showPart(int part){
		i = 0;
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			if(i == part){
			sr.enabled = true;
			}
			i++;
		}
		i = 0;
	}

	public void showPart(int part, int type){
		i = 0;
		if (type == 0) {
			foreach (SpriteRenderer sr in type0.GetComponentsInChildren<SpriteRenderer>()) {
				if (i == part) {
					sr.enabled = true;
				}
				i++;
			}
			i = 0;
		}else if (type == 1) {
			foreach (SpriteRenderer sr in type1.GetComponentsInChildren<SpriteRenderer>()) {
				if (i == part) {
					sr.enabled = true;
				}
				i++;
			}
			i = 0;
		}
	}
	
}
