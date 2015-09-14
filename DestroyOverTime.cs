using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{

    public float timer, timertarget;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if (timer >= timertarget)
	    {
	        Destroy(gameObject);
	    }
	    else
	    {
	        timertarget += Time.deltaTime;
	    }
	}
}
