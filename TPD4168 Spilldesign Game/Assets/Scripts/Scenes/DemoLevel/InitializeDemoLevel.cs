using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDemoLevel : MonoBehaviour
{

    [Header("Strong")]
    public Ability leapSmashAbility;
    public Ability retractAbility;
    public Ability dashAbility;
    public Ability throwWikAbility;

    [Header("Wik")]
    public Ability bombAbility;

    private void Awake() {
        leapSmashAbility.isUnlocked = true;
        retractAbility.isUnlocked = true;
        dashAbility.isUnlocked = true;
        throwWikAbility.isUnlocked = true;
        bombAbility.isUnlocked = true;
    }
}
