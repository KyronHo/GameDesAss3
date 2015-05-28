using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {
	public int stage =1;
	private Text ttext;
	public float timer  = 5f;
	private GlobalScript manager;


	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(Proceed);
		ttext = GameObject.Find ("TutorialText").GetComponent<Text> ();
		manager = GameObject.Find ("GlobalScript").GetComponent<GlobalScript> ();
	}

	void Update(){
		if (stage == 1) {
			manager.enemy.placed = true;
		}
		if(stage >= 3){
			timer -= Time.deltaTime;
			if(timer < 3f){
				GameObject.Find ("tNPC").GetComponent<Transform>().position = new Vector3(3.48f,.66f,0);
			}
			if(timer < 2f){
				GameObject.Find ("tNPC2").GetComponent<Transform>().position = new Vector3(.66f,1.75f,0);
			}			
			if(timer < 1f){
				GameObject.Find ("tNPC3").GetComponent<Transform>().position = new Vector3(-1.56f,-.41f,0);
			}			
			if(timer < 0f){
				if (stage == 3 || stage == 4 || stage == 5){
					manager.enemy.placed = false;
				}
			}
		}
		if (GameObject.Find ("tEnemyPortrait1").GetComponent<SpriteRenderer> ().enabled == true && stage == 4) {
			manager.enemy.placed = false;
			Proceed ();
		}
		if (GameObject.Find ("tEnemy").GetComponent<Transform> ().position.z == 1 && stage == 5) {
			manager.enemy.placed = true;
			stage = 6;
			Proceed ();
		}
		if (stage == 8) {
			manager.enemy.placed = true;
			if (GameObject.Find ("tEnemy").GetComponent<Transform> ().position.z == 1){
				stage = 6;
			}
		}
	}
	
	void Proceed() {
		if (stage == 1) {
			ttext.text = "To start you off, you can move with the WASD Keys.";
			stage++;
		} else if (stage == 2) {
			stage++;
			ttext.text = "In the course of your travels, you will find others who will tell you about those who wish to alter history.";
		} else if (stage == 3) {
			stage++;
			ttext.text += " If you press E to talk to these individuals when near them, they will be able to show you part of those you are looking for.";

		} else if(stage == 4){
			ttext.text = "The part they told you about will appear at the top right, also, see that box with the '∞' symbol? that shows the time left for you to complete your mission, right now it's infinite, but if it reaches 0 you will have failed!";
			stage = 5;
		}else if (stage == 5) {
			if(timer < 0){
				manager.enemy.placed = false;
			}
			GameObject.Find ("ButtonText").GetComponent<Text> ().text = "Find them to continue";
			ttext.text = "When you think you've worked out who is the one you're looking for, press X when close to them";
		} else if (stage == 6) {
			GameObject.Find ("ButtonText").GetComponent<Text> ().text = "Travel through time!";
			ttext.text = "You've passed this test! Congratulations!, you are now authorised to track down those who would change time!";
			stage = 7;
		} else if (stage == 7) {
			Application.LoadLevel ("Roman_Intro");
		}
	}
}