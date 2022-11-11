using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevelAbilities : MonoBehaviour
{
    [Header("Strong")]
    public Ability leapSmashAbility;
    public Ability retractAbility;
    public Ability dashAbility;
    public Ability throwWikAbility;

    [Header("Wik")]
    public Ability bombAbility;

    [Header("Is unlocked")]
    public bool leapSmashAbilityUnlocked;
    public bool retractAbilityUnlocked;
    public bool dashAbilityUnlocked;
    public bool throwWikAbilityUnlocked;
    public bool bombAbilityUnlocked;

    private void Awake() {
        leapSmashAbility.isUnlocked = leapSmashAbilityUnlocked;
        retractAbility.isUnlocked = retractAbilityUnlocked;
        dashAbility.isUnlocked = dashAbilityUnlocked;
        throwWikAbility.isUnlocked = throwWikAbilityUnlocked;
        bombAbility.isUnlocked = bombAbilityUnlocked;
        ;
    }
}
