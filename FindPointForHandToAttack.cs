/*
 * So this is pretty messy, sorry. 
 * 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FindPointForHandToAttack : MonoBehaviour
{

    private bool runCo=false;
    //flag to check if the user has tapped / clicked. 
    //Set to true on click. Reset to false on reaching destination
    private bool flag = false;
    //destination point
    private Vector3 endPoint;
    public GameObject manaUI;
    public Slider manaSlider;
    public float mana, maxmana, rechargeRate, spellcost;

    public GameObject skillShotLeft, skillShotRight;
    public GameObject rightArm, leftArm;
    public GameObject explosion;
    public bool lefthand, righthand;

    private void Start()
    {
        mana = maxmana;
        manaSlider = manaUI.GetComponent<Slider>();
        manaSlider.value = maxmana / maxmana;
        //camera = cameraObj.GetComponent<Camera>();
    }

    //I'm sure most of this could be tidied up and probably refactored out into another class encapsulating the attacking behaviour.
    //That was the plan and then the stress hit.
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            skillShotLeft.SetActive(true);
            MoveLeftArmTarget();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mana > spellcost)
            {
            mana -= spellcost;
            UpdateFillCount();
            skillShotLeft.SetActive(false);
            StartCoroutine(SpawnCo());
            }
        }
        if (Input.GetMouseButton(1))
        {
            skillShotRight.SetActive(true);
            MoveRightArmTarget();
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (mana > spellcost)
            {
            mana -= spellcost;
            UpdateFillCount();
            skillShotRight.SetActive(false);
            StartCoroutine(SpawnCo());
            }
            else
            {
                //play bad sound
            }
        }
        if (mana < maxmana)
        {
            mana += Time.deltaTime * rechargeRate;
            UpdateFillCount();
        }
        if (mana > maxmana)
            mana = maxmana;
    }


    //This will spawn the explosions used to attack enemies.
    private IEnumerator SpawnCo()
    {
        while (!runCo)
        {
            runCo = true;
            yield return null;
        }
        Instantiate(explosion, new Vector3(endPoint.x, endPoint.y + 0.5f, endPoint.z), Quaternion.identity);
    }


    //The following 2 methods are used to move the targeting texture used for the left and right arms.
    //For some reason I have basically the same method twice but for right and left arms.
    private Vector3 MoveLeftArmTarget()
    {
        //declare a variable of RaycastHit struct
        RaycastHit hit;
        //Create a Ray on the tapped / clicked position
        Ray ray;
        //for unity editor

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Check if the ray hits any collider
        if (Physics.Raycast(ray, out hit))
        {
            //set a flag to indicate to move the gameobject
            flag = true;
            //save the click / tap position
            endPoint = hit.point;
            endPoint.y += 0.5f;
        }

        //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
        if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            //&& !(V3Equal(transform.position, endPoint))){
            //move the gameobject to the desired position
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance(gameObject.transform.position, endPoint))));
            skillShotLeft.transform.position = endPoint;
            return endPoint;
        }
        //set the movement indicator flag to false if the endPoint and current gameobject position are equal
        else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            flag = false;
            Debug.Log("I am here");
        }
        return endPoint;
    }


    private Vector3 MoveRightArmTarget()
    {
        //declare a variable of RaycastHit struct
        RaycastHit hit;
        //Create a Ray on the tapped / clicked position
        Ray ray;
        //for unity editor

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Check if the ray hits any collider
        if (Physics.Raycast(ray, out hit))
        {
            //set a flag to indicate to move the gameobject
            flag = true;
            //save the click / tap position
            endPoint = hit.point;
            endPoint.y += 0.5f;
        }
        //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
        if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            //&& !(V3Equal(transform.position, endPoint))){
            //move the gameobject to the desired position
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance(gameObject.transform.position, endPoint))));
            skillShotRight.transform.position = endPoint;
            return endPoint;
        }
        //set the movement indicator flag to false if the endPoint and current gameobject position are equal
        else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            flag = false;
            Debug.Log("I am here");
        }
        return endPoint;

    }


    public void UpdateFillCount()
    {
        manaSlider.value = mana / maxmana;
    }
}
