using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractDamage : MonoBehaviour
{

    public bool shouldDoDamage;
    public float damagePerFrame;
    public float damageRadius;

    [Header("Camera shake")]
    public CameraShake cameraShake;
    public float shakeDuration;
    public float shakeMagnitude;

    private void Start() {
        // Camera shake
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldDoDamage) {
            // Damage enemies
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
            foreach (var hitCollider in hitColliders) {
                var enemyScript = hitCollider.GetComponent<EnemyBehaviour>();
                if (enemyScript) {
                    enemyScript.takeDamage(damagePerFrame);
                    cameraShake.shakeDuration = shakeDuration;
                    cameraShake.shakeMagnitude = shakeMagnitude;
                    cameraShake.shake = true;
                }
            }

            // Damage Pillars
            foreach (var hitCollider in hitColliders) {
                var enemyScript = hitCollider.GetComponent<HealthPillar>();
                if (enemyScript) {
                    enemyScript.TakeDamage(damagePerFrame);
                }
            }
        }
    }
}
