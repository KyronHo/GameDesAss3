using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

	private GlobalScript manager;
	public Color[] enemyColors = new Color[8];
	private int i = 0;
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		manager.enemy = this;
		EnemyColor ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = manager.enemyPos;
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
	}

	public void EnemyColor ()
	{
		enemyColors [0] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		enemyColors [1] = new Color (Random.Range (0.5f, 1f), Random.Range (0.5f, 1f), Random.Range (0.5f, 1f));
		enemyColors [2] = enemyColors [1];
		enemyColors [3] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		enemyColors [4] = enemyColors [1];
		enemyColors [5] = enemyColors [1];
		enemyColors [6] = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		enemyColors [7] = enemyColors [6];
		
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
	}

}
