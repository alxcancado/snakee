using UnityEngine;
using System.Collections;

public class SwipeControl : MonoBehaviour {

	//First establish some variables
	private Vector3 fp; //First finger position
	private Vector3 lp; //Last finger position
	public float dragDistance;  //Distance needed for a swipe to register
	
	// Update is called once per frame
	void Update()
	{
		//Examine the touch inputs
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
			}
			if (touch.phase == TouchPhase.Moved)
			{
				lp = touch.position;
			}
			if (touch.phase == TouchPhase.Ended)
			{
				//First check if it's actually a drag
				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
				{   //It's a drag
					//Now check what direction the drag was
					//First check which axis
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
					{   //If the horizontal movement is greater than the vertical movement...
						if (lp.x>fp.x)  //If the movement was to the right
						{   //Right move
							this.gameObject.GetComponent<Snake>().SetDir(Vector2.right);
						}
						else
						{   //Left move
							this.gameObject.GetComponent<Snake>().SetDir(-Vector2.right);
						}
					}
					else
					{   //the vertical movement is greater than the horizontal movement
						if (lp.y>fp.y)  //If the movement was up
						{   //Up move
							this.gameObject.GetComponent<Snake>().SetDir(Vector2.up);
						}
						else
						{   //Down move
							this.gameObject.GetComponent<Snake>().SetDir(-Vector2.up);
						}
					}
				}
				else
				{   //It's a tap
					//TAP CODE HERE
				}
				
			}
		}
	}
}