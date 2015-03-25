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

	// Use this for initialization
	void Start () {

		// Spawn food every 4 seconds starting in 3
		InvokeRepeating ("Spawn", 3, 4);
	
	}

	// Spawn one piece of food
	void Spawn(){

		// x position between left & right border
		int x = (int)Random.Range (borderLeft.position.x, borderRight.position.x);

		// y position between top & bottom border
		int y = (int)Random.Range (borderTop.position.y, borderBottom.position.y);

		// Spawn a new Food gameobject
		GameObject cloneFood = Instantiate (foodPrefab, new Vector2(x, y), Quaternion.identity) as GameObject; //with default rotation
		cloneFood.gameObject.transform.SetParent (this.gameObject.transform); // for organization matters, add as chield of Food gameobj
	}

}
