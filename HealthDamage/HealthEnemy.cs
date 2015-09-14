using UnityEngine;
using System.Collections;

public class HealthEnemy : HealthBase{


    public GameObject deadBody;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Kill()
    {

        gamemanager.AddPoints(10);
        gamemanager.ReduceEnemyCount();

        Instantiate(deadBody, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage, GameObject instigator)
    {
        // AudioSource.PlayClipAtPoint(healthLossSound, transform.position);

        //Instantiate(OuchEffect, instigator.transform.position, transform.rotation);

        _healthValue -= damage;

        Debug.Log("I have been hit and have " + _healthValue + " health remaining");

        if (_healthValue <= 0)
        {
            _isDead = true;
            Debug.Log("I am dead :(");
            Kill();
        }

    }
}
