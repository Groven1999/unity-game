using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [Header("Camera Shake")]
    public CameraShake cameraShake;
    public float shakeDuration;
    public float shakeMagnitude;

    private void Awake() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0) {
            // player hurt

            // screen shake
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
        } else {
            // player dead

        }
    }
}
