using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class SpawnPoint : MonoBehaviour {


	public GameObject enemyToSpawn;
    public Transform attackThisTarget;
    public int spawnAmount;
    public GameObject gamemanager;

	[SerializeField]
	private float spawnTimer, spawnTarget, beginTimer, beginTarget;
	private bool spawning = false;



	// Use this for initialization
	void Start ()
	{
	    gamemanager.GetComponent<GameManager>().totalenemies += spawnAmount;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawning)
		{
		    spawnTimer += Time.deltaTime;
		    if (spawnTimer >= spawnTarget)
		    {
		        spawnAmount--;

		        GameObject instEnemy = (GameObject)Instantiate(enemyToSpawn, gameObject.transform.position, Quaternion.identity);
		        AICharacterControl AIC = instEnemy.GetComponent<AICharacterControl>();

		        AIC.target = attackThisTarget;
                AIC.targetTransform = attackThisTarget; 

                //This was for when there were multiple things for the player to defend. That plan didn't work out
                //if (spawnRandom)
                //{
                //    AIC.FindATargetRand();
                //}
                //else
                //{
                //    AIC.FindClosestTargetLoop(); 
                //}
                
		        spawnTimer = 0f;
                if (spawnAmount >= 0)
                {
                    spawning = false;
                }
		    }
			
		} 
        else 
        {
		beginTimer += Time.deltaTime;
			if(beginTimer >= beginTarget)
				spawning = true;
		}
	}
}
