using UnityEngine;
using UnityEngine.UI;


public class LevelSelectController : MonoBehaviour
{
    [SerializeField]
    Button forestButton, marshButton, castleButton, mountainButton;
    StoreState storeState;

    void Start ()
    {

        storeState = JsonUtility.FromJson<StoreState>(PlayerPrefs.GetString("StoreState"));
        switch (storeState.nextLevel)
        {
            case "Marsh":
                forestButton.interactable = true;
                break;
            case "Castle":
                forestButton.interactable = true;
                marshButton.interactable = true;
                break;
            case "Mountains":
                forestButton.interactable = true;
                marshButton.interactable = true;
                castleButton.interactable = true;
                break;
            case "NONE":
                forestButton.interactable = true;
                marshButton.interactable = true;
                castleButton.interactable = true;
                mountainButton.interactable = true;
                break;
            default:
                break;
        }
    }
}
