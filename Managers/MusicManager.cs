using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip mainMusic;
	public AudioSource source;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	    if (Application.loadedLevel == 2)
	    {
	        source.clip = mainMusic;
            source.Play();
	        source.loop = true;
	    }
	    //else
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
