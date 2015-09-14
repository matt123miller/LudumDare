/*
 * Written by Matt
 * 
 * This is Matt's version of GiveHealth that uses the separated health system.
 * Luke's code is still present at the bottom, commented out, in case it's necessary
 * 
 * It gives health to the player when they pick up the item and instantiates a particle  
 */

using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    public GameObject Effect;
    public int HealthToGive;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            var playerHealth = other.GetComponent<HealthBase>();

            playerHealth.GiveHealth(HealthToGive, gameObject);
            Instantiate(Effect, transform.position, transform.rotation);

            gameObject.SetActive(false);

        }
    }


    
}



//using UnityEngine;

//public class GiveHealth : MonoBehaviour, IPlayerRespawnListener
//{
//    public GameObject Effect;
//    public int HealthToGive;

//    public void OnTriggerEnter2D(Collider2D other)
//    {
//        var player = other.GetComponent<Player>();
//        if(player == null)
//        {
//            return;
//        }

//        player.GiveHealth(HealthToGive, gameObject);
//        Instantiate(Effect, transform.position, transform.rotation);

//        gameObject.SetActive(false);
//    }

//    public void OnPlayerRespoanInThisCheckpoint(Checkpoint checkpoint, Player player)
//    {
//        gameObject.SetActive(true);
//    }
//}
