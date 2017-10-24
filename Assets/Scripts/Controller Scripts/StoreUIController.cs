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

    [SerializeField]
    int costMultiplier = 100;

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
        numCoinsText.text = "Current Amount off Coins: " + numCoins;
        groundForceText.text = storeState.groundForceLevel.ToString() + " Pig Newtons";
        enemyForceText.text = storeState.enemyForceLevel.ToString() + " Pig Newtons";
        numAttacksText.text = storeState.numAttacksLevel.ToString();

        //upgrades cost (current level * cost multiplier coins)
        groundButtonText.text = "Upgrade: " + (storeState.groundForceLevel * costMultiplier).ToString() + " Coins";
        enemyButtonText.text = "Upgrade: " + (storeState.enemyForceLevel * costMultiplier).ToString() + " Coins";
        numAttackButtonText.text = "Upgrade: " + (storeState.numAttacksLevel * costMultiplier).ToString() + " Coins";

        if (storeState.nextLevel == "NONE")
        {
            levelButton.SetActive(false);
        }
        else
        {
            levelButtonText.text = "Unlock " + storeState.nextLevel + ": 500 Coins";
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
            storeState.groundForceLevel++;
            UpdateStore();
        }
    }
    public void UpgradeEnemyForce()
    {
        if (storeState.enemyForceLevel * costMultiplier <= numCoins)
        {
            numCoins -= storeState.enemyForceLevel * costMultiplier;
            storeState.enemyForceLevel++;
            UpdateStore();
        }
    }
    public void UpgradeNumAttacks()
    {
        if (storeState.numAttacksLevel * costMultiplier <= numCoins)
        {
            numCoins -= storeState.numAttacksLevel * costMultiplier;
            storeState.numAttacksLevel++;
            UpdateStore();
        }
    }
    public void UnlockLevel()
    {
        if (numCoins >= 500)
        {
            switch (storeState.nextLevel)
            {
                case "Forest":
                    storeState.nextLevel = "Marsh";
                    numCoins -= 500;
                    break;
                case "Marsh":
                    storeState.nextLevel = "Castle";
                    numCoins -= 500;
                    break;
                case "Castle":
                    storeState.nextLevel = "Mountains";
                    numCoins -= 500;
                    break;
                case "Mountains":
                    storeState.nextLevel = "NONE";
                    numCoins -= 500;
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