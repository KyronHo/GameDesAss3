using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

	private GlobalScript manager;
	public Color[] enemyColors = new Color[8];
	private int i = 0;
	private Transform target;
	private bool placed = false;
	private float timer = 20;
	private Transform type0;
	private Transform type1;
	public int level;
	// Use this for initialization
	void Start ()
	{
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
		manager.enemy = this;
		if (level == 0) {
			target = GameObject.Find ("Roman_VIP").GetComponent<Transform> ();
			EnemyColor ();
		} else if (level == 1) {
			target = GameObject.Find ("Camelot_VIP").GetComponent<Transform> ();
			type0 = GameObject.Find ("0").GetComponent<Transform>();
			type1 = GameObject.Find ("1").GetComponent<Transform>();
			EnemyColor ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (placed == false && manager.enemyPos != new Vector3(0,0,0)) 
		{
			transform.position = manager.enemyPos;
			placed = true;
		}
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			if(i== enemyColors.Length)
			{
				i=0;
			}
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
		Typecheck(manager.enemyType);
		timer -= Time.deltaTime;
		if (timer <= 2.5f) {
			MoveTowardsTarget();
		}
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
			if(i== enemyColors.Length)
			{
				i=0;
			}
			sr.material.color = enemyColors [i];
			i++;
		}
		i = 0;
	}

	public void Typecheck(int t)
	{
		if (t == 0) {
			foreach (SpriteRenderer sr in type1.GetComponentsInChildren<SpriteRenderer>()) {
				sr.enabled = false;
			}
			foreach (SpriteRenderer sr in type0.GetComponentsInChildren<SpriteRenderer>()) {
				sr.enabled = true;
			}
			if (t == 1) {
				foreach (SpriteRenderer sr in type0.GetComponentsInChildren<SpriteRenderer>()) {
					sr.enabled = false;
				}
				foreach (SpriteRenderer sr in type0.GetComponentsInChildren<SpriteRenderer>()) {
					sr.enabled = true;
				}
			}
		}
	}

	private void MoveTowardsTarget() {

		float speed = 3f;

		Vector3 targetPosition = target.position;
		targetPosition += new Vector3 (0, -2, 0);
		
		Vector3 currentPosition = transform.position;

		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;

			directionOfTravel.Normalize();
			
			transform.position += new Vector3((directionOfTravel.x * speed * Time.deltaTime) ,(directionOfTravel.y * speed * Time.deltaTime), 0);
		}
	}

}
