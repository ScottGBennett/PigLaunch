using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StoreUIController : MonoBehaviour
{
    [SerializeField]
    Text groundForceText, enemyForceText, numAttacksText, numCoinsText;

    [SerializeField]
    Text groundButtonText, enemyButtonText, numAttackButtonText, levelButtonText;

    [SerializeField]
    GameObject levelButton;

    public Transform groundButton, enemyButton, numAttackButton;

    [SerializeField]
    int costMultiplier = 2;

    [SerializeField]
    int numCoins;

    StoreState storeState;

    // Use this for initialization
    void Start ()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            numCoins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            numCoins = 0;
        }

        if (PlayerPrefs.HasKey("StoreState"))
        {
            //get current state from player prefs
            string storeStateString = PlayerPrefs.GetString("StoreState");
            storeState = JsonUtility.FromJson<StoreState>(storeStateString);
            UpdateStore();
        }
        else
        {
            InitializeStore();
        }
    }

    void UpdateStore()
    {

        //update text on store page with storeState info
        numCoinsText.text = "Current Amount of Coins: " + numCoins;
        groundForceText.text = storeState.groundForceLevel.ToString() + " Pig Newtons";
        enemyForceText.text = storeState.enemyForceLevel.ToString() + " Pig Newtons";
        numAttacksText.text = storeState.numAttacksLevel.ToString();

        /*********************************************/
        /*             Button Text Section           */
        /*********************************************/
        //upgrades cost (current level * cost multiplier coins)
        if (storeState.groundForceLevel < 3) //if this element is upgradable, write its cost
        {
            groundButtonText.text = "Upgrade: " + (storeState.groundForceLevel * costMultiplier).ToString() + " Coins";
        }
        else //if the element is not upgradable, state that it's at max level and make button inactive
        {
            groundButtonText.text = "Max Level";
            groundButton.GetComponent<Button>().interactable = false;
        }

        if (storeState.enemyForceLevel < 3)
        {
            enemyButtonText.text = "Upgrade: " + (storeState.enemyForceLevel * costMultiplier).ToString() + " Coins";
        }
        else
        {
            enemyButtonText.text = "Max Level";
            enemyButton.GetComponent<Button>().interactable = false;
        }
        
        if (storeState.numAttacksLevel < 5)
        {
            numAttackButtonText.text = "Upgrade: " + (storeState.numAttacksLevel * costMultiplier).ToString() + " Coins";
        }
        else
        {
            numAttackButtonText.text = "Max Level";
            numAttackButton.GetComponent<Button>().interactable = false;
        }
        /***********************************************/

        if (storeState.nextLevel == "NONE")
        {
            levelButton.SetActive(false);
        }
        else
        {
            levelButtonText.text = "Unlock " + storeState.nextLevel + ": 5 Coins";
        }

        PlayerPrefs.SetString("StoreState", JsonUtility.ToJson(storeState));

    }

    void InitializeStore()
    {
        storeState = new StoreState("Forest", 1, 1, 2);
        PlayerPrefs.SetString("StoreState", JsonUtility.ToJson(storeState));
        UpdateStore();
    }

    public void UpgradeGroundForce()
    {
        if (storeState.groundForceLevel * costMultiplier <= numCoins)
        {
            numCoins -= storeState.groundForceLevel * costMultiplier;
            PlayerPrefs.SetInt("Coins", numCoins);
            storeState.groundForceLevel++;
            UpdateStore();
        }
    }
    public void UpgradeEnemyForce()
    {
        if (storeState.enemyForceLevel * costMultiplier <= numCoins)
        {
            numCoins -= storeState.enemyForceLevel * costMultiplier;
            PlayerPrefs.SetInt("Coins", numCoins);
            storeState.enemyForceLevel++;
            UpdateStore();
        }
    }
    public void UpgradeNumAttacks()
    {
        if (storeState.numAttacksLevel * costMultiplier <= numCoins)
        {
            numCoins -= storeState.numAttacksLevel * costMultiplier;
            PlayerPrefs.SetInt("Coins", numCoins);
            storeState.numAttacksLevel++;
            UpdateStore();
        }
    }
    public void UnlockLevel()
    {
        if (numCoins >= 5)
        {
            switch (storeState.nextLevel)
            {
                case "Forest":
                    storeState.nextLevel = "Marsh";
                    numCoins -= 5;
                    PlayerPrefs.SetInt("Coins", numCoins);
                    break;
                case "Marsh":
                    storeState.nextLevel = "Castle";
                    numCoins -= 5;
                    PlayerPrefs.SetInt("Coins", numCoins);
                    break;
                case "Castle":
                    storeState.nextLevel = "Mountains";
                    numCoins -= 5;
                    PlayerPrefs.SetInt("Coins", numCoins);
                    break;
                case "Mountains":
                    storeState.nextLevel = "NONE";
                    numCoins -= 5;
                    PlayerPrefs.SetInt("Coins", numCoins);
                    levelButton.SetActive(false);
                    break;
                default:
                    break;
            }
            UpdateStore();
        }
    }

    public void GoHome()
    {
        PlayerPrefs.SetString("StoreState", JsonUtility.ToJson(storeState));
        PlayerPrefs.SetInt("Coins", numCoins);
        SceneManager.LoadScene("MainMenu");
    }
}


//custom class to hold information about the state of the store. An instance of this is serialized to playerprefs as "StoreState"
class StoreState
{
    public string nextLevel;
    public int groundForceLevel;
    public int enemyForceLevel;
    public int numAttacksLevel;

    public StoreState(string levelTitle, int groundForce, int enemyForce, int numAttack)
    {
        nextLevel = levelTitle;
        groundForceLevel = groundForce;
        enemyForceLevel = enemyForce;
        numAttacksLevel = numAttack;
    }
}