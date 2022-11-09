using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [Header("Camera Shake")]
    public CameraShake cameraShake;
    public float shakeDuration;
    public float shakeMagnitude;

    [Header("iFrames")]
    [SerializeField] private float IFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    public bool isInvulnerable;

    private void Awake() {
        currentHealth = startingHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage) {
        if (!isInvulnerable) {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0) {
                // player hurt

                // Play Sound
                FindObjectOfType<AudioManager>().Play("StrongTakesDamage");

                StartCoroutine(Invunerability(IFramesDuration, numberOfFlashes, true));

                // screen shake
                StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
            }
            else {
                // player dead

            }
        }
    }

    public IEnumerator Invunerability(float duration, int _numberOfFlashes, bool ignoreCollision) {

        // Ignore collision with enemies and projectiles
        if (ignoreCollision) {
            Physics2D.IgnoreLayerCollision(7, 6, true);
            Physics2D.IgnoreLayerCollision(7, 10, true);
        }

        isInvulnerable = true;

        if (_numberOfFlashes > 0) {
            for (int i = 0; i < _numberOfFlashes; i++) {
                spriteRenderer.color = new Color(1, 0.5f, 0, 0.5f);
                yield return new WaitForSeconds(duration / (_numberOfFlashes * 2));
                spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(duration / (_numberOfFlashes * 2));
            }
        } else {
            yield return new WaitForSeconds(duration);
        }

        // Turn on collision with enemies and projectiles
        if (ignoreCollision) {
            Physics2D.IgnoreLayerCollision(7, 6, false);
            Physics2D.IgnoreLayerCollision(7, 10, false);
        }

        isInvulnerable = false;
    }
}
