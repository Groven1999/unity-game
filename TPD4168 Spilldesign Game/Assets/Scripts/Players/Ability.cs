using System;
using UnityEngine;

public class Ability : ScriptableObject
{

    public new string name;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent) {}
    public virtual void BeginCooldown(GameObject parent) {}

    public virtual bool CanUse(GameObject parent) { return false; }

    public virtual bool IsAbilityFinished(GameObject parent) { return false; }
}
