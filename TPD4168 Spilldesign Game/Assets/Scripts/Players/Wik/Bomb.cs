using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{

    [SerializeField] public Image abilityImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*// Update the ability image, corresponding to cooldowntime
        AbilityHolder abilityHolder = gameObject.GetComponentInParent<AbilityHolder>();
        float cooldownTime = abilityHolder.ability.cooldownTime;

        if (abilityHolder.getAbilityState().Equals("ready")) {
            abilityImage.fillAmount = 1;
        }
        else if (abilityHolder.getAbilityState().Equals("cooldown")) {
            float currentCooldownTime = abilityHolder.getCooldownTime();
            if (currentCooldownTime > 0) {
                float fillAmount = 1 - (currentCooldownTime / cooldownTime);
                abilityImage.fillAmount = fillAmount;
            }
        }*/
    }
}
