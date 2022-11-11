using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Retract Ability in project hierarchy. It lets you create ability objects
public class Retract : Ability {

    public float retractSpeed;

    public override void Activate(GameObject parent) {

        // Play sound 
        FindObjectOfType<AudioManager>().Play("RetractStart");

        GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");
        Player_Wik_Movement wikMovementScript = playerWik.GetComponent<Player_Wik_Movement>();
        wikMovementScript.movementSpeed = retractSpeed;
        wikMovementScript.isRetracted = true;

        // Ignore collision with enemies and skippable walls
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(8, 14, true);


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
        Physics2D.IgnoreLayerCollision(8, 14, false);

        // Ignore damage to touched enemies
        playerWik.GetComponent<RetractDamage>().shouldDoDamage = false;
    }

    public override bool CanUse(GameObject parent) {
        Player_Wik_Movement wikMovementScript = GameObject.FindGameObjectWithTag("Player_Wik").GetComponent<Player_Wik_Movement>();
        var feedbackMessageController = GameObject.FindGameObjectWithTag("FeedbackMessageHolder").GetComponent<FeedbackMessageController>();

        if (wikMovementScript.isPickedUp) {
            feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("Can't use that now"));
            return false;
        } 
        else if (wikMovementScript.isThrown) {
            feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("Can't use that now"));
            return false;
        }
        else {
            return true;
        }
        
    }

    public override bool IsAbilityFinished(GameObject parent) {
        Player_Wik_Movement wikMovementScript = GameObject.FindGameObjectWithTag("Player_Wik").GetComponent<Player_Wik_Movement>();
        return (wikMovementScript.isPickedUp);
    }
}
