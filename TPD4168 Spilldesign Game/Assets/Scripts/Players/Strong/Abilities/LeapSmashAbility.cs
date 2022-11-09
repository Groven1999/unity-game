using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Leap Smash Ability in project hierarchy. It lets you create ability objects
public class LeapSmashAbility : Ability
{

    public float leapSpeed;
    public float splashRange = 5;
    public float damage = 1;

    // How far away can Strong be Wik for him to be able to use Leap Smash
    [SerializeField] private float maxDistanceFromPlayerWik;

    [Header("Camera shake")]
    public CameraShake cameraShake; // Assigned in code with tag
    public float shakeDuration;
    public float shakeMagnitude;

    [Header("Knockback")]
    [SerializeField] public float knockbackDamage;
    [SerializeField] public float knockbackDuration;

    [Header("Invulnerability")]
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private int numberOfFlashes;

    private void Awake() {
        //feedbackMessageHolder = GameObject.FindGameObjectWithTag("FeedbackMessageHolder").GetComponent<FeedbackMessage>();
    }

    public override void Activate(GameObject parent) {

        // Play sound 
        FindObjectOfType<AudioManager>().Play("LeapSmashAbilityJump");

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

        // Play sound 
        FindObjectOfType<AudioManager>().Play("LeapSmashAbilityLand");

        // Play sound 
        FindObjectOfType<AudioManager>().Play("LeapSmashAbilityExplosion"); 

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

        // Become Invulnerable for a brief moment
        var playerStrongHealthScript = parent.GetComponent<Health>();
        playerStrongHealthScript.StartCoroutine(playerStrongHealthScript.Invunerability(invulnerabilityDuration, numberOfFlashes, false));

        // Explosion animation
        parent.GetComponent<Animator>().SetTrigger("leapSmashExplosion");

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

        // Cannot use ability if Wik is currently being held by Strong, or if Wik is too far away
        // If FALSE -> give feedback to player
        GameObject player_wik = GameObject.FindGameObjectWithTag("Player_Wik");
        float distanceBetweenStrongAndWik = Vector3.Distance(parent.transform.position, player_wik.transform.position);

        if (!player_wik.GetComponent<Player_Wik_Movement>().isPickedUp) {
            if (distanceBetweenStrongAndWik <= maxDistanceFromPlayerWik) {
                return true;
            } else {
                var feedbackMessageController = GameObject.FindGameObjectWithTag("FeedbackMessageHolder").GetComponent<FeedbackMessageController>();
                feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("WIK IS TOO FAR AWAY"));
                return false;
            }
        } else {
            var feedbackMessageController = GameObject.FindGameObjectWithTag("FeedbackMessageHolder").GetComponent<FeedbackMessageController>();
            feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("THROW WIK FIRST"));
            return false;
        }
    }

    public override bool IsAbilityFinished(GameObject parent) {
        return false;
    }
}
