using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using UnityStandardAssets.Characters.ThirdPerson;

public class AIController : MonoBehaviour
{

    private NavMeshAgent agent;
    private AudioSource shoutClip;


    //public GameObject[] arrTargets;
    //private int arrLength, iCurrentDest;
    //private float iRedirectDistance = 2f;
    public Transform rootPlayer; // target to aim for
    public ThirdPersonCharacter character;
    public int damageToGive;
    public Transform[] targetArr;
    public Transform targetTransform;
    public float canAttackTimer, canAttackTarget;
    private HealthBase _targetHealth;
    private bool busyBool, canAttack; //used to ensure AI focuses on current task instead of doing others.
    private bool attackState, runningState; //change running state on trigger enter

    public bool BusyBool
    {
        get { return busyBool; }
        set { busyBool = value; }
    }



    // Use this for initialization
    void Awake()
    {

        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        runningState = true;
        attackState = false;

        BusyBool = false;

    }

    // Update is called once per frame
    private void Update()
    {
        
        #region
        if (rootPlayer != null)
        {
            // update the agents posiiton 
            agent.transform.position = transform.position;

            //float walkMultiplier = (walkToggle ? 1 : 0.5f);
            //move *= walkMultiplier;
            // use the values to move the character;
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            // We still need to call the character's move function, but we send zeroed input as the move param.
            character.Move(Vector3.zero, false, false);
        }
        #endregion
       

        //timer to make a decision
        //if (!attackState)
        //{
        //    canAttackTimer += Time.deltaTime;
        //    if (canAttackTimer >= canAttackTarget)
        //    {
        //        attackState = true;
        //        canAttackTimer = 0f;
        //    }
        
        //}
        //enemy logic
        if (attackState)
        {
            Attack();
        }
        else if (runningState)// running to target
        {
            if (targetTransform == null)
            {
                targetTransform = FindClosestTargetLoop();
                _targetHealth = targetTransform.gameObject.GetComponent<HealthBase>();
            }
            agent.destination = targetTransform.position;
        }
        else 
        {
        }

    }


    public void Shout()
    {
        Debug.Log("Shouting! RAWR!");
        shoutClip.Play();
    }

    private void Attack()
    {
        if (_targetHealth.IsDead)
        {
            attackState = false;
            targetTransform = null;
            runningState = true;
        }
        else
        {
            _targetHealth.TakeDamage(damageToGive, gameObject);
        }

    }



    private Transform FindClosestTargetLoop()
    {
        Transform bestTarget = null;

        float closestDistanceSqr = Mathf.Infinity;

        foreach (Transform potentialTarget in targetArr)
        {
            float f = Vector3.Distance(potentialTarget.transform.position, transform.position);
            if (f < closestDistanceSqr)
            {
                    bestTarget = potentialTarget.transform;
            }
        }
        return bestTarget;

    }


    //private void Waypoint()
    //{
    //    //Waypoint system
    //    if (agent.remainingDistance < iRedirectDistance)
    //    {

    //        if (iCurrentDest >= arrLength - 1)
    //        {
    //            iCurrentDest = 0;
    //        }
    //        else
    //        {
    //            iCurrentDest++;
    //        }
    //        agent.destination = arrTargets[iCurrentDest].transform.position;
    //    }
    //}




}

