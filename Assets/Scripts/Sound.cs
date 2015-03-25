using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour {

	// sound/music
	public AudioClip eat;
	public AudioClip die;
	public AudioClip main;

	private static Sound instance = null;
	public static Sound Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

		//this.GetComponent<AudioSource>().clip =  Resources.Load("main") as AudioClip;
	}

	public void PlayEatSound(){
		AudioSource.PlayClipAtPoint (eat, transform.position);
	}
	
	public void PlayDieSound(){
		//AudioSource.PlayClipAtPoint (die, transform.position);
		GetComponent<AudioSource> ().clip = die;
		GetComponent<AudioSource>().loop = false;
		GetComponent<AudioSource>().Play();
	}
	
	public void VolumeLow(){
		GetComponent<AudioSource>().pitch +=0.01f;
	}
	
	public void PlayBGSound(){
		GetComponent<AudioSource> ().clip = main;
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().Play();
	}
	
	public void StopBGSound(){
		GetComponent<AudioSource>().Stop();
	}
}
