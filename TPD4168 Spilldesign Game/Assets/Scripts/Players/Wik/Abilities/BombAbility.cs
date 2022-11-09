using UnityEngine;

[CreateAssetMenu] // THIS TAG ENABLES CREATE -> Bomb Ability in project hierarchy. It lets you create ability objects
public class BombAbility : Ability
{
    Animator animator;
    public float splashRange = 5;
    public float damage = 1;

    // How far away can Wik be Strong for him to be able to use Bomb ability
    public float maxDistanceFromPlayerStrong;

    [Header("Knockback")]
    [SerializeField] public float knockbackDamage = 50;
    [SerializeField] public float knockbackDuration = 0.5f;

    [Header("Camera shake")]
    public CameraShake cameraShake;
    public float shakeDuration;
    public float shakeMagnitude;

    public override void Activate(GameObject parent) {

        // Play Sound
        FindObjectOfType<AudioManager>().Play("BombAbilityExplosion");

        animator = GameObject.FindGameObjectWithTag("Bomb").GetComponent<Animator>();
        animator.SetTrigger("bomb");
    }

    public override void BeginCooldown(GameObject parent) {

        // Damage Pillars
        var hitColliders = Physics2D.OverlapCircleAll(parent.transform.position, splashRange);
        foreach (var hitCollider in hitColliders) {
            var enemyScript = hitCollider.GetComponent<HealthPillar>();
            if (enemyScript) {
                enemyScript.TakeDamage(damage);
            }
        }

        // Do damage to enemies around
        foreach (var hitCollider in hitColliders) {
            var enemyScript = hitCollider.GetComponent<EnemyBehaviour>();
            if (enemyScript) {
                
                // Knockback
                enemyScript.StartCoroutine(enemyScript.Knockback(knockbackDuration, knockbackDamage, parent));

                enemyScript.takeDamage(damage);
            }
        }

        // Camera shake
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        cameraShake.shakeDuration = shakeDuration;
        cameraShake.shakeMagnitude = shakeMagnitude;
        cameraShake.shake = true;
    }

    public override bool CanUse(GameObject parent) {

        // Return FALSE if Strong is currently using LeapSmash
        // Return FALSE if Strong is too far away from Wik, or if Wik is currently being held by Strong
        // Return FALSE if Wik is currently being held by Strong

        GameObject player_Strong = GameObject.FindGameObjectWithTag("Player_Strong");

        float distanceBetweenStrongAndWik = Vector3.Distance(parent.transform.position, player_Strong.transform.position);
        bool isWikPickedUp = parent.GetComponent<Player_Wik_Movement>().isPickedUp;
        bool isStrongUsingLeapSmash = player_Strong.GetComponent<Player_Strong_Movement>().usingLeapSmash;

        if (
            !isStrongUsingLeapSmash &&
            !isWikPickedUp &&
            distanceBetweenStrongAndWik <= maxDistanceFromPlayerStrong 
        ) { 
            return true; 
        } else {

            // Give feedback message, depending on why Player cannot use Bomb
            string feedbackMessage = "";
            var feedbackMessageController = GameObject.FindGameObjectWithTag("FeedbackMessageHolder").GetComponent<FeedbackMessageController>();

            if (isStrongUsingLeapSmash) {
                feedbackMessage = "Can't use that now";
            }
            else if (isWikPickedUp) {
                feedbackMessage = "THROW WIK FIRST";
            }
            else if (distanceBetweenStrongAndWik >= maxDistanceFromPlayerStrong) {
                feedbackMessage = "WIK IS TOO FAR AWAY";
            }

            feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage(feedbackMessage));

            return false;
        }
    }

    public override bool IsAbilityFinished(GameObject parent) {
        return false;
    }
}
