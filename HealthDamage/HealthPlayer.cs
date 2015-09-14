using System.Xml.Schema;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPlayer : HealthBase
{


    public GameObject healthUI;
    public Slider healthSlider;
	// Use this for initialization
	void Start ()
	{
	    healthSlider = healthUI.GetComponent<Slider>();
	    healthSlider.value = maxHealth/maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Kill()
    {
            //Instantiate(MAKE GameObject BOOM!)
            //Destroy(gameObject)

            gamemanager.GameOver();
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

        UpdateHealthSlider();
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = (float)_healthValue/(float)maxHealth;
    }
}
