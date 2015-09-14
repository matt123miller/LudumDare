using UnityEngine;
using System.Collections;

public abstract class HealthBase : MonoBehaviour {
    public int _healthValue;
    public bool _isDead = false;

    //public Player player;
    public int maxHealth;
    public GameObject OuchEffect;
    public GameManager gamemanager;

    public int HealthValue
    {
        get { return _healthValue; }
        set { _healthValue = value; }
    }

    public bool IsDead
    {
        get { return _isDead; }
        private set { _isDead = value; }
    }



    // Use this for initialization
    private void Awake()
    {
        IsDead = _isDead;
        _healthValue = maxHealth;
        var temp = GameObject.FindGameObjectWithTag("GameController");
        gamemanager = temp.GetComponent<GameManager>();
    }

    public void GiveHealth(int healthtogive, GameObject instigator)
    {

        _healthValue = Mathf.Min(_healthValue + healthtogive, maxHealth); // returns the smallest of the 2 arguments
    }


    public abstract void TakeDamage(int damage, GameObject instigator);
    

    //should only be used internally. There is public void InstantKill() below if necessary
    //public void Kill()
    //{
    //    if (gameObject.CompareTag("DefendMe"))
    //    {
    //        //Instantiate(MAKE GameObject BOOM!)
    //        //Destroy(gameObject)

    //        gamemanager.GameOver();

    //        //temporary
    //        GetComponent<BoxCollider>().enabled = false;

    //        return;
    //    }

    //    gamemanager.AddPoints(10);
    //    gamemanager.totalenemies--;

    //    Instantiate(deadBody, gameObject.transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}


    public void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            coll.GetComponent<GiveDamageToTarget>().StartDamaging(this);
            //also set animations
        }
    }

}
