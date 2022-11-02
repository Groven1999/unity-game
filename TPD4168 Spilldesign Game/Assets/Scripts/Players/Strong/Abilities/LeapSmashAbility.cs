using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Leap Smash Ability in project hierarchy. It lets you create ability objects
public class LeapSmashAbility : Ability
{

    public float leapSpeed;
    public float splashRange = 5;
    public float damage = 1;

    public override void Activate(GameObject parent) {

        // Calculates the speed of the leapSmash based on the distance to Wik, and how long the active time is
        leapSpeed = Vector2.Distance(parent.transform.position, GameObject.FindGameObjectWithTag("Player_Wik").transform.position) / (activeTime - (activeTime / 3));

        // Updates the movement speed
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();
        playerStrongMovement.movementSpeed = leapSpeed;
        playerStrongMovement.usingLeapSmash = true;


        // Animation
        Animator animator = parent.GetComponent<Animator>();
        animator.SetTrigger("leapSmash");        
    }

    public override void BeginCooldown(GameObject parent) {

        // Do damage to enemies around
        var hitColliders = Physics2D.OverlapCircleAll(parent.transform.position, splashRange);
        foreach(var hitCollider in hitColliders) {
            var enemy = hitCollider.GetComponent<EnemyBehaviour>();
            if (enemy) {
                enemy.takeDamage(damage);
            }
        }

        // Resets movement speed
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();
        playerStrongMovement.movementSpeed = playerStrongMovement.normalMovementSpeed;
        playerStrongMovement.usingLeapSmash = false;

        // Camera shake
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.GetComponent<Shake>().start = true;

    }
}
