using System.Collections;
using System;
using UnityEngine;

public class GiveDamageToTarget : MonoBehaviour
{


    public int DamageToGive = 1;
    public float timer, timertarget;
    
    public bool damage = false;
    public HealthBase health;

    private void Update()
    {

        if (damage)
        {
            if (timer >= timertarget)
            {
                health.TakeDamage(DamageToGive, gameObject);
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        //seperated damage targets in case it's later useful;

    }


    public void StartDamaging(HealthBase _health)
    {
        damage = true;
        health = _health;
    }


    public IEnumerator StartDamagingCo(HealthBase health)
    {
        
        yield return null;
    }


}

