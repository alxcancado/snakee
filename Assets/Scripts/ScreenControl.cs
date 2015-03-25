using UnityEngine;
using System.Collections;

public class ScreenControl : MonoBehaviour {

	// Play state
	bool play = false;
	
	// In Game Screen
	public GameObject inGame;
	public GameObject mainMenu;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && !play) {
			mainMenu.gameObject.SetActive(false);
			inGame.gameObject.SetActive(true);
			play = true;
			
		}
		
		// Move in a new direction
		if(Input.GetKey(KeyCode.RightArrow)){
			mainMenu.gameObject.SetActive(false);
			inGame.gameObject.SetActive(true);
			play = true;
		} else
			
		if(Input.GetKey(KeyCode.LeftArrow)){
			mainMenu.gameObject.SetActive(false);
			inGame.gameObject.SetActive(true);
			play = true;
		} else
			
		if(Input.GetKey(KeyCode.UpArrow)){
			mainMenu.gameObject.SetActive(false);
			inGame.gameObject.SetActive(true);
			play = true;
		} else
			
		if(Input.GetKey(KeyCode.DownArrow)){
			mainMenu.gameObject.SetActive(false);
			inGame.gameObject.SetActive(true);
			play = true;
		}
	}
}
