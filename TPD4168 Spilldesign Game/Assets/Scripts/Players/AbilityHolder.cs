using UnityEngine;

public class AbilityHolder : MonoBehaviour
{

    public Ability ability;

    float cooldownTime;
    float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    public KeyCode key;

    private void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKey(key)) {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0) {
                    activeTime -= Time.deltaTime;
                }
                else {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0) {
                    cooldownTime -= Time.deltaTime;
                }
                else {
                    state = AbilityState.ready;
                }
                break;
        }
    }

    public float getCooldownTime() {
        return cooldownTime;
    }

    public string getAbilityState() {
        if (state == AbilityState.ready) {
            return("ready");
        } else if (state == AbilityState.active) {
            return ("active");
        } else {
            return ("cooldown");
        }
    }

}
