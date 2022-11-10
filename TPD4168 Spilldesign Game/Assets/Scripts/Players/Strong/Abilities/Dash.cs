using UnityEngine;

[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;
    public float scaleChangeX;
    public float scaleChangeY;

    public override void Activate(GameObject parent) {
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();

        // Play Sound
        FindObjectOfType<AudioManager>().Play("DashAbility");

        // Add movement speed
        playerStrongMovement.movementSpeed += dashVelocity;

        // Shrink animation (Need to disable the animator, to be able to change localscale)
        parent.GetComponent<Animator>().enabled = false;
        Vector3 scaleChange = new Vector3(scaleChangeX, scaleChangeY, 0);
        parent.transform.localScale -= scaleChange;

        // Change color
        parent.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 1, 1);

        // Invulnerability
        parent.GetComponent<Health>().StartCoroutine(parent.GetComponent<Health>().Invunerability(activeTime, 0, true));

        // Set values
        playerStrongMovement.isUsingDash = true;
    }

    public override void BeginCooldown(GameObject parent) {

        // Reset movement speed
        Player_Strong_Movement playerStrongMovement = parent.GetComponent<Player_Strong_Movement>();
        playerStrongMovement.movementSpeed = playerStrongMovement.normalMovementSpeed;

        // Anti shrink animation
        parent.GetComponent<Animator>().enabled = true;
        Vector3 scaleChange = new Vector3(scaleChangeX, scaleChangeY, 0);
        parent.transform.localScale += scaleChange;

        // Reset color
        parent.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        // Reset values
        playerStrongMovement.isUsingDash = false;
    }

    public override bool CanUse(GameObject parent) {
        return true;
    }

    public override bool IsAbilityFinished(GameObject parent) {
        return false;
    }
}
