using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;


public class Snake : MonoBehaviour {

	// Current movement direction. Default right.
	Vector2 dir = Vector2.right;

	// Keep track of Tail
	List<Transform> tail = new List<Transform>();

	// did the snake ate food?
	bool ate = false;

	// Tail prefab
	public GameObject tailPrefab;

	// Snake speed
	public float speed = 0.1f;

	// Score
	public Text score;
	public Text last;
	public Text best;
	int scoreInt;
	int lastInt;
	int bestInt;

	// Sound Manager
	public GameObject soundFX;

	// Play state
	bool play = false;

	// In Game Screen
	public GameObject inGame;
	public GameObject mainMenu;

	void Awake(){
		soundFX = GameObject.Find("Sound");

		lastInt = PlayerPrefs.GetInt ("Last");
		last.text = "Last: "+lastInt;
		bestInt = PlayerPrefs.GetInt ("Best");
		best.text = "Best: "+bestInt;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && !play) {
			mainMenu.gameObject.SetActive(false);
			inGame.gameObject.SetActive(true);

			if (!play){
				soundFX.GetComponent<Sound> ().PlayBGSound ();
			}

			play = true;
		}

		if (Input.anyKey) {
			mainMenu.gameObject.SetActive(false);
			inGame.gameObject.SetActive(true);
			if (!play){
				soundFX.GetComponent<Sound> ().PlayBGSound ();
			}
			
			play = true;
		}
		// Move in a new direction
		if(Input.GetKey(KeyCode.RightArrow)){
			dir = Vector2.right;
		} else
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			dir = -Vector2.right;
		} else
		
		if(Input.GetKey(KeyCode.UpArrow)){
			dir = Vector2.up;
		} else

		if(Input.GetKey(KeyCode.DownArrow)){
			dir = -Vector2.up;
		}

		if (play) {
			Move();
		}
	}

	void Move(){

		if(play){
			// save current position (free position after Head move forward)
			Vector2 v = transform.position;
			
			// Move Head to a new position (now is when we create a gap between tail and head of the snake)
			// Move head into new direction
			transform.Translate (dir*speed);

			// Ate any Food? Insert new element into the gap
			if (ate) {
				// Load prefab
				GameObject g = Instantiate(tailPrefab, v, Quaternion.identity) as GameObject;
				//g.tag = "Tail";
				
				// Keep track of it in our List
				tail.Insert(0, g.transform);
				
				// increase Snake speed
				//speed =- 0.01f;
				
				// Reset the flag
				ate = false;
				
				//g.gameObject.transform.SetParent(this.gameObject.transform);
			}

			// Do we have a Tail?
			if (tail.Count > 0){
				// Move last Tail element to where Head was
				tail.Last().position = v;
				
				// Add to front of the List, remove from the back
				tail.Insert(0, tail.Last());
				tail.RemoveAt(tail.Count-1);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log(coll.tag);
		// Food?
		if (coll.tag == "Food") {

			// Get longer in next Move call
			ate = true;

			// Remove Food
			Destroy (coll.gameObject);

			// add Score
			scoreInt ++; 
			score.text = (scoreInt).ToString();

			// play sfx
			soundFX.GetComponent<Sound>().PlayEatSound();

			// change snake speed. range from 0.5 to 0.1
			//if (speed <= 0.5f && speed >= 0.1f){
				speed += 0.03f;
			//}

		}

		// Collided with Tail or Border
		else {
			GameOver();
		}
	}

	void GameOver() {
		play = false;

		soundFX.GetComponent<Sound>().PlayDieSound();

		PlayerPrefs.SetInt("Last", int.Parse(score.text));
		
		if (scoreInt > PlayerPrefs.GetInt("Best")){
			PlayerPrefs.SetInt("Best", scoreInt);
		}

		Application.LoadLevel("Scene");
	}

	public void SetDir(Vector2 direction){
		dir = direction;
	}
}
