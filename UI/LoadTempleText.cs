using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Must be applied to the object that handles GUI, it won't be destroyed.

public class LoadTempleText : MonoBehaviour
{


    public string playerName;

    public string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        playerName = PlayerPrefs.GetString("PlayerName");
        //Debug.Log (playerName);
        gameObject.GetComponent<Text>().text = "THE TEMPLE OF \n" + playerName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
