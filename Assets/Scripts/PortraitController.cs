using UnityEngine;
using System.Collections;

public class PortraitController : MonoBehaviour
{
	
	private GlobalScript manager;
	public Color[] enemyColors = new Color[8];
	private int i = 0;
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		manager.portrait = this;
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
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
	}

	public void showPart(int part){
		i = 0;
		print (part);
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			if(i == part){
			sr.enabled = true;
			}
			i++;
		}
		i = 0;
	}
	
}
