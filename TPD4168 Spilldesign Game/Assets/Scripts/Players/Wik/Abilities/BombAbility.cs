using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Bomb Ability in project hierarchy. It lets you create ability objects
public class BombAbility : Ability
{
    Animator animator;
    public float splashRange = 5;
    public float damage = 1;

    public override void Activate(GameObject parent) {

        animator = GameObject.FindGameObjectWithTag("Bomb").GetComponent<Animator>();
        animator.SetTrigger("bomb");
    }

    public override void BeginCooldown(GameObject parent) {

        // Do damage to enemies around
        var hitColliders = Physics2D.OverlapCircleAll(parent.transform.position, splashRange);
        foreach (var hitCollider in hitColliders) {
            var enemy = hitCollider.GetComponent<EnemyBehaviour>();
            if (enemy) {
                enemy.takeDamage(damage);
            }
        }
    }
}
