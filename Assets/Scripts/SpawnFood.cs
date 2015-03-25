using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	// Food Prefab
	public GameObject foodPrefab;

	// Borders
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;

	float wallSizeHorizontal;
	float wallSizeVertical;

	// Use this for initialization
	void Start () {

		// Spawn food every 4 seconds starting in 3
		InvokeRepeating ("Spawn", 3, 4);

		// ...so we are not spawning inside the Walls... maybe I could only add some ramdom number like "1" but I want to be precise here :)
		wallSizeHorizontal = borderLeft.GetComponent<Renderer>().bounds.size.x;
		wallSizeVertical = borderTop.GetComponent<Renderer>().bounds.size.y;
	
	}

	// Spawn one piece of food
	void Spawn(){

		// x position between left & right border
		int x = (int)Random.Range (borderLeft.position.x + wallSizeHorizontal, borderRight.position.x - wallSizeHorizontal);

		// y position between top & bottom border
		int y = (int)Random.Range (borderTop.position.y + wallSizeVertical, borderBottom.position.y - wallSizeVertical);


		// Spawn a new Food gameobject
		GameObject cloneFood = Instantiate (foodPrefab, new Vector2(x, y), Quaternion.identity) as GameObject; //with default rotation
		cloneFood.gameObject.transform.SetParent (this.gameObject.transform); // for organization matters, add as chield of Food gameobj
	}

}
