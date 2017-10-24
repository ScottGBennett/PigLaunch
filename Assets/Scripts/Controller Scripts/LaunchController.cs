using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchController : MonoBehaviour {

    public static LaunchController instance;
    public Image fullShader;
    public PlayerController pig;
    public GameObject powerBar;

    [HideInInspector]
    public bool launched = false;

    private bool movePowerUp = true;
    private int power = 0;

    // Use this for initialization
    void Start () 
    {
        launched = false;
        powerBar.SetActive(true);
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (!launched) //if the pig hasn't already been launched, change the power level
        {
            changePowerText();
        }

        if (Input.GetMouseButtonDown(0) && !launched)
        {
            launched = true;
            pig.Launch((float)power);
            powerBar.SetActive(false);
        }
    }

    public void changePowerText()
    {
        if (movePowerUp) //if the power number in the UI should increase, execute this block
        {
            if (power <= 98) //98 or less and we just need to increment then update the UI text
            {
                power++;
                fullShader.transform.localScale = new Vector3(((float)power / 100f), 1, 1);
            }
            else //once we hit 99, change the movePowerUp variable so this block is skipped next frame
            {
                movePowerUp = false;
                power++;
                fullShader.transform.localScale = new Vector3(((float)power / 100f), 1, 1);
            }
        }
        else //if the movePowerUp flag is false, decrease the power number
        {
            if (power > 1) //2 or greater and we just need to decrement then update the UI text 
            {
                power--;
                fullShader.transform.localScale = new Vector3(((float)power / 100f), 1, 1);
            }
            else //once we hit 1, change the movePowerUp variable so the above block is executed next frame
            {
                movePowerUp = true;
                power--;
                fullShader.transform.localScale = new Vector3(((float)power / 100f), 1, 1);
            }
        }
    } 
}