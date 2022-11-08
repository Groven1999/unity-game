using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Retract Ability in project hierarchy. It lets you create ability objects
public class Retract : Ability {

    public float retractSpeed;

    public override void Activate(GameObject parent) {
        GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");
        Player_Wik_Movement wikMovementScript = playerWik.GetComponent<Player_Wik_Movement>();
        wikMovementScript.movementSpeed = retractSpeed;
        wikMovementScript.isRetracted = true;

        // Ignore collision with enemies
        Physics2D.IgnoreLayerCollision(6, 8, true);

        // Do damage to touched enemies
        playerWik.GetComponent<RetractDamage>().shouldDoDamage = true;
    }

    public override void BeginCooldown(GameObject parent) {
        GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");
        Player_Wik_Movement wikMovementScript = playerWik.GetComponent<Player_Wik_Movement>();
        wikMovementScript.isRetracted = false;
        wikMovementScript.movementSpeed = 0;

        // Reset collision with enemies
        Physics2D.IgnoreLayerCollision(6, 8, false);

        // Ignore damage to touched enemies
        playerWik.GetComponent<RetractDamage>().shouldDoDamage = false;
    }

    public override bool CanUse(GameObject parent) {
        Player_Wik_Movement wikMovementScript = GameObject.FindGameObjectWithTag("Player_Wik").GetComponent<Player_Wik_Movement>();
        return (!wikMovementScript.isPickedUp && !wikMovementScript.isThrown);
    }

    public override bool IsAbilityFinished(GameObject parent) {
        Player_Wik_Movement wikMovementScript = GameObject.FindGameObjectWithTag("Player_Wik").GetComponent<Player_Wik_Movement>();
        return (wikMovementScript.isPickedUp);
    }
}
