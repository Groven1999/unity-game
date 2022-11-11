using UnityEngine;

public class UICanvasController : MonoBehaviour
{
    [Header("Abilities")]
    public Ability leapSmashAbility;
    public Ability retractAbility;
    public Ability dashAbility;
    public Ability bombAbility;

    [Header("AbilityPanelHolders")]
    public GameObject leapSmashHolder;
    public GameObject retractHolder;
    public GameObject dashHolder;
    public GameObject bombHolder;

    private void Start() {
        leapSmashHolder.SetActive(false);
        retractHolder.SetActive(false);
        dashHolder.SetActive(false);
        bombHolder.SetActive(false);
    }

    private void Update() {
        if (leapSmashAbility.isUnlocked) {
            leapSmashHolder.SetActive(true);
        }

        if (retractAbility.isUnlocked) {
            retractHolder.SetActive(true);
        }

        if (dashAbility.isUnlocked) {
            dashHolder.SetActive(true);
        }

        if (bombAbility.isUnlocked) {
            bombHolder.SetActive(true);
        }
    }
}
