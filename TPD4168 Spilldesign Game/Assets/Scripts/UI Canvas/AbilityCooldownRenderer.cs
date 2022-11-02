using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownRenderer : MonoBehaviour
{

    // Images for abilities, used in the Canvas
    [Header("Images")]
    [SerializeField] public Image bombImage;
    [SerializeField] public Image leapSmashImage;

    // Ability holders
    [Header("Ability holders")]
    [SerializeField] public AbilityHolder bombAbilityHolder;
    [SerializeField] public AbilityHolder leapSmashAbilityHolder;

    // Cooldown for the abilities
    private float bombCooldown;
    private float leapSmashCooldown;

    private void Start() {
        // Set cooldowns
        bombCooldown = bombAbilityHolder.ability.cooldownTime;
        leapSmashCooldown = leapSmashAbilityHolder.ability.cooldownTime;
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
    }
}
