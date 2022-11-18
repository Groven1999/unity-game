using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownRenderer : MonoBehaviour
{

    // Images for abilities, used in the Canvas
    [Header("Images")]
    private Image bombImage;
    private Image leapSmashImage;
    private Image retractImage;
    private Image dashImage;

    // Ability holders
    [Header("Ability holders")]
    private AbilityHolder bombAbilityHolder;
    private AbilityHolder leapSmashAbilityHolder;
    private AbilityHolder retractAbilityHolder;
    private AbilityHolder dashAbilityHolder;

    // Cooldown for the abilities
    private float bombCooldown;
    private float leapSmashCooldown;
    private float retractCooldown;
    private float dashCooldown;

    private void Awake() {
        // Assign Player Strong ability holders
        GameObject playerStrong = GameObject.FindGameObjectWithTag("Player_Strong");
        AbilityHolder[] abilityHoldersPlayerStrong = playerStrong.GetComponents<AbilityHolder>();

        foreach (AbilityHolder abilityHolder in abilityHoldersPlayerStrong) {
            if (abilityHolder.ability.name == "LeapSmash") {
                leapSmashAbilityHolder = abilityHolder;
            }
            if (abilityHolder.ability.name == "Retract") {
                retractAbilityHolder = abilityHolder;
            }

            if (abilityHolder.ability.name == "Dash") {
                dashAbilityHolder = abilityHolder;
            }
        }

        // Assign Player Wik ability holders
        GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");
        AbilityHolder[] abilityHoldersPlayerWik = playerWik.GetComponents<AbilityHolder>();

        foreach (AbilityHolder abilityHolder in abilityHoldersPlayerWik) {
            if (abilityHolder.ability.name == "Bomb") {
                bombAbilityHolder = abilityHolder;
            }
        }

        // Set cooldowns
        bombCooldown = bombAbilityHolder.ability.cooldownTime;
        leapSmashCooldown = leapSmashAbilityHolder.ability.cooldownTime;
        retractCooldown = retractAbilityHolder.ability.cooldownTime;
        dashCooldown = dashAbilityHolder.ability.cooldownTime;

        // Set Images
        bombImage = GameObject.FindGameObjectWithTag("Ability_Bomb").GetComponent<Image>();
        leapSmashImage = GameObject.FindGameObjectWithTag("Ability_LeapSmash").GetComponent<Image>();
        retractImage = GameObject.FindGameObjectWithTag("Ability_Retract").GetComponent<Image>();
        dashImage = GameObject.FindGameObjectWithTag("Ability_Dash").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        // Bomb
        if (bombAbilityHolder.getAbilityState().Equals("ready")) {
            bombImage.fillAmount = 1;
        }
        else if (bombAbilityHolder.getAbilityState().Equals("cooldown")) {
            float currentCooldownTime = bombAbilityHolder.getCooldownTime();
            if (currentCooldownTime > 0) {
                float fillAmount = 1 - (currentCooldownTime / bombCooldown);
                bombImage.fillAmount = fillAmount;
            }
        }

        // LeapSmash
        if (leapSmashAbilityHolder.getAbilityState().Equals("ready")) {
            leapSmashImage.fillAmount = 1;
        }
        else if (leapSmashAbilityHolder.getAbilityState().Equals("cooldown")) {
            float currentCooldownTime = leapSmashAbilityHolder.getCooldownTime();
            if (currentCooldownTime > 0) {
                float fillAmount = 1 - (currentCooldownTime / leapSmashCooldown);
                leapSmashImage.fillAmount = fillAmount;
            }
        }

        // Retract
        if (retractAbilityHolder.getAbilityState().Equals("ready")) {
            retractImage.fillAmount = 1;
        }
        else if (retractAbilityHolder.getAbilityState().Equals("cooldown")) {
            float currentCooldownTime = retractAbilityHolder.getCooldownTime();
            if (currentCooldownTime > 0) {
                float fillAmount = 1 - (currentCooldownTime / retractCooldown);
                retractImage.fillAmount = fillAmount;
            }
        }

        // Dash
        if (dashAbilityHolder.getAbilityState().Equals("ready")) {
            dashImage.fillAmount = 1;
        }
        else if (dashAbilityHolder.getAbilityState().Equals("cooldown")) {
            float currentCooldownTime = dashAbilityHolder.getCooldownTime();
            if (currentCooldownTime > 0) {
                float fillAmount = 1 - (currentCooldownTime / dashCooldown);
                dashImage.fillAmount = fillAmount;
            }
        }
    }
}
