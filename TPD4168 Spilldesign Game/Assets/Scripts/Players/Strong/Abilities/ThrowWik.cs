using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> ThrowWik Ability in project hierarchy. It lets you create ability objects
public class ThrowWik : Ability {

    public float movementSpeed;

    public override void Activate(GameObject parent) {
        GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");
        Player_Wik_Movement wikMovementScript = playerWik.GetComponent<Player_Wik_Movement>();

        // Find target position: where Wik is going to land
        Vector2 targetPosition = GameObject.FindGameObjectWithTag("Player_Strong_ThrowPointDir").transform.position;

        wikMovementScript.isThrown = true;
        wikMovementScript.pickedUp(false);
        wikMovementScript.targetPosition = targetPosition;
    }

    public override void BeginCooldown(GameObject parent) {
        GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");
        Player_Wik_Movement wikMovementScript = playerWik.GetComponent<Player_Wik_Movement>();

        wikMovementScript.movementSpeed = 0;
        wikMovementScript.isThrown = false;
        wikMovementScript.body.velocity = Vector2.zero;
    }

    public override bool CanUse(GameObject parent) {
        return (GameObject.FindGameObjectWithTag("Player_Wik").GetComponent<Player_Wik_Movement>().isPickedUp == true);
    }

    public override bool IsAbilityFinished(GameObject parent) {
        return false;
    }
}
