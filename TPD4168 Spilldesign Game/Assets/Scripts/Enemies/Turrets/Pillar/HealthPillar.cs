using System.Collections;
using TMPro;
using UnityEngine;

public class HealthPillar : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [Header("Camera Shake")]
    public CameraShake cameraShake;
    public float onDamageShakeDuration;
    public float onDamageShakeMagnitude;
    public float onDeathShakeDuration;
    public float onDeathShakeMagnitude;

    [Header("HealthBar")]
    public HealthBarImage healthBarPillar;

    [Header("Animation")]
    Animator pillarBottomanimator;

    [Header("Pillar top")]
    public Animator pillarTopAnimator; // Set manually
    public GameObject pillarTop;

    [Header("UI Text")]
    public GameObject pillarsDestroyedText;

    private void Start() {
        pillarBottomanimator = GetComponent<Animator>();
    }

    private void Awake() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        healthBarPillar.UpdateHealth(currentHealth / startingHealth);

        if (currentHealth > 0) {
            // screen shake
            StartCoroutine(cameraShake.Shake(onDamageShakeDuration, onDamageShakeMagnitude));
        }
        else {
            // screen shake
            StartCoroutine(cameraShake.Shake(onDeathShakeDuration, onDeathShakeMagnitude));

            StartCoroutine(KillSelf());
        }
    }

    IEnumerator KillSelf() {

        pillarsDestroyedText.GetComponent<PillarsDestroyedController>().PillarDestroyed();

        // Shrink turret
        pillarBottomanimator.SetTrigger("shrink");
        pillarTopAnimator.SetTrigger("shrink");
        yield return new WaitForSeconds(1.3f);

        // Particle explosion
        GetComponent<ParticleEffectExplosion>().ParticleExplosion();

        // Set inactive
        gameObject.SetActive(false);
        pillarTop.SetActive(false);
        yield return null;
    }
}
