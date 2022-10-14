using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Leap Smash Ability in project hierarchy. It lets you create ability objects
public class LeapSmashAbility : Ability
{

    public float leapSpeed;

    public override void Activate(GameObject parent) {

        // Calculates the speed of the leapSmash based on the distance to Wik, and how long the active time is
        leapSpeed = Vector2.Distance(parent.transform.position, GameObject.FindGameObjectWithTag("Player_Wik").transform.position) / (activeTime - (activeTime / 5));

        // Updates the movement speed
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();
        playerStrongMovement.movementSpeed = leapSpeed;
        playerStrongMovement.usingLeapSmash = true;

        // Animation
        Animator animator = parent.GetComponent<Animator>();
        animator.SetTrigger("leapSmash");
    }

    public override void BeginCooldown(GameObject parent) {

        // Resets movement speed
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();
        playerStrongMovement.movementSpeed = playerStrongMovement.normalMovementSpeed;
        playerStrongMovement.usingLeapSmash = false;
    }
}
