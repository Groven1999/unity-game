using System;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Leap Smash Ability in project hierarchy. It lets you create ability objects
public class LeapSmashAbility : Ability
{

    public float leapSpeed;
    public float splashRange = 5;
    public float damage = 1;

    [Header("Camera shake")]
    public CameraShake cameraShake;
    public float shakeDuration;
    public float shakeMagnitude;

    [Header("Knockback")]
    [SerializeField] public float knockbackDamage;
    [SerializeField] public float knockbackDuration;

    public override void Activate(GameObject parent) {

        GameObject player_Wik = GameObject.FindGameObjectWithTag("Player_Wik");

        // Calculates the speed of the leapSmash based on the distance to Wik, and how long the active time is
        leapSpeed = Vector2.Distance(parent.transform.position, player_Wik.transform.position) / (activeTime - (activeTime / 3));

        // Updates the movement speed
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();
        playerStrongMovement.movementSpeed = leapSpeed;
        playerStrongMovement.usingLeapSmash = true;

        // Animation
        Animator animator = parent.GetComponent<Animator>();
        animator.SetTrigger("leapSmash");
    }

    public override void BeginCooldown(GameObject parent) {

        // Damage enemies
        var hitColliders = Physics2D.OverlapCircleAll(parent.transform.position, splashRange);
        foreach (var hitCollider in hitColliders) {
            var enemyScript = hitCollider.GetComponent<EnemyBehaviour>();
            if (enemyScript) {
                
                // Knockback
                enemyScript.StartCoroutine(enemyScript.Knockback(knockbackDuration, knockbackDamage, parent));

                enemyScript.takeDamage(damage);
            }
        }

        // Damage Pillars
        foreach (var hitCollider in hitColliders) {
            var enemyScript = hitCollider.GetComponent<HealthPillar>();
            if (enemyScript) {
                enemyScript.TakeDamage(damage);
            }
        }

        // Resets movement speed
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();
        playerStrongMovement.movementSpeed = playerStrongMovement.normalMovementSpeed;
        playerStrongMovement.usingLeapSmash = false;

        // Camera shake
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        cameraShake.shakeDuration = shakeDuration;
        cameraShake.shakeMagnitude = shakeMagnitude;
        cameraShake.shake = true;    
    }

    public override bool CanUse(GameObject parent) {

        // Cannot use ability if Wik is currently being held by Strong
        GameObject player_wik = GameObject.FindGameObjectWithTag("Player_Wik");
        return !(player_wik.GetComponent<Player_Wik_Movement>().isPickedUp);
    }

    public override bool IsAbilityFinished(GameObject parent) {
        return false;
    }
}
