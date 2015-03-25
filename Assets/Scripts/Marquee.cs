using UnityEngine;

public class Marquee : MonoBehaviour
{
	public string message = "Where we're going, we don't need roads.";
	public float scrollSpeed = 50;
	
	Rect messageRect;

	public Font f;
	
	void OnGUI () {

		// setting Font
		if(!f) {
			Debug.LogError("No font found, assign one in the inspector.");
			return;
		}
		GUI.skin.font = f;

		// Set up message's rect if we haven't already.
		if (messageRect.width == 0) {
			var dimensions = GUI.skin.label.CalcSize(new GUIContent(message));
			
			// Start message past the left side of the screen.
			messageRect.x = -dimensions.x;
			messageRect.width = dimensions.x;
			messageRect.height = dimensions.y;
		}
		
		messageRect.x += Time.deltaTime * scrollSpeed;
		
		// If message has moved past the right side, move it back to the left.
		if (messageRect.x > Screen.width) {
			messageRect.x = -messageRect.width;
		}
		
		GUI.Label(messageRect, message);
	}
}