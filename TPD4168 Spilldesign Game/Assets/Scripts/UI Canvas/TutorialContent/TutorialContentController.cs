using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialContentController : MonoBehaviour
{

    GameObject abilityUnlockedScreen;

    [Header("Content in the Unlocked Ability screen")]
    public GameObject abilityName;
    public GameObject abilityText;
    public GameObject abilityImage;

    [Header("Ability Images")]
    public Image retractImage;
    public GameObject leapSmashImage;
    public GameObject bombImage;
    public GameObject dashImage;

    private void Start() {
        abilityUnlockedScreen = GameObject.FindGameObjectWithTag("AbilityUnlocked");
        abilityUnlockedScreen.SetActive(false);
    }


    public void ShowTutorialScreen(string ability) {

        if (ability == "Retract") {
            abilityName.GetComponent<TextMeshProUGUI>().text = "RETRACT";

            var newText = "Retract <color=#0EC1FF>WIK</color> to <color=#0EC1FF>Strong's</color> position, dealing damage to enemies along the way! \n\nActivation key: <color=#0EC1FF>R</color>";
            abilityText.GetComponent<TextMeshProUGUI>().text = newText;

            abilityImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("RetractAbility");
        }
        else if (ability == "LeapSmash") {
            abilityName.GetComponent<TextMeshProUGUI>().text = "LEAP SMASH";
            
            var newText = "<color=#0EC1FF>Strong</color> leaps into the air and slams down on <color=#0EC1FF>Wik</color>'s position, dealing huge damage to nearby enemies! \n\nActivation key: <color=#0EC1FF>E</color>";
            abilityText.GetComponent<TextMeshProUGUI>().text = newText;

            abilityImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("LeapSmashAbility");
        } 
        else if (ability == "Bomb") {
            abilityName.GetComponent<TextMeshProUGUI>().text = "BOMB";

            var newText = "<color=#0EC1FF>WIK</color> explodes, dealing huge damage and knocks back nearby enemies! \n\nActivation key: <color=#0EC1FF>Q</color>";
            abilityText.GetComponent<TextMeshProUGUI>().text = newText;

            abilityImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("BombAbility");
        } 
        else if (ability == "Dash") {
            abilityName.GetComponent<TextMeshProUGUI>().text = "DASH";

            var newText = "<color=#0EC1FF>STRONG</color> performs a dash, becoming temporarily invulnerable and ignoring collision with enemies. \n\nActivation key: <color=#0EC1FF>SPACE</color>";
            abilityText.GetComponent<TextMeshProUGUI>().text = newText;

            abilityImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("DashAbility");
        }

        abilityUnlockedScreen.SetActive(true);

        // Play sound
        FindObjectOfType<AudioManager>().Play("AbilityUnlock");
    }

    public void ExitTutorialSreen() {
        abilityUnlockedScreen.SetActive(false);
    }
}
