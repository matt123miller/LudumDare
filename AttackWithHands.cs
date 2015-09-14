using UnityEngine;
using System.Collections;

public class AttackWithHands : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            coll.gameObject.GetComponent<HealthEnemy>().Kill();
        }
    }
}
