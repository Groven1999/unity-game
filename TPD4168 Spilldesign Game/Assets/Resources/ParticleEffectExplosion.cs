using UnityEngine;

public class ParticleEffectExplosion : MonoBehaviour
{
    // Ensures that particle effect is casted in intervals
    private float activeTime;

    private void Update() {
        if (activeTime > 0) {
            activeTime -= Time.deltaTime;
        } else if (activeTime <= 0) {
            return;
        }
    }

    // Explosion when enemy dies
    public void ParticleExplosion() {
        Object explosionRef = Resources.Load("ExplosionOnDeath2");
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        print("particle effect: " + transform.position);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Retract damage
    public void ParticleExplosionOnRetractDamage() {
        
        if (activeTime <= 0) {
            Object explosionRef = Resources.Load("RetractTakeDamage");
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        activeTime = 0.1f;
    }

    // Gold Box explode
    public void ParticleExplosionGoldBoxDestroy() {
        Object explosionRef = Resources.Load("GoldBoxExplode");
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Pillar explode
    public void ParticleExplosionPillarDestroy() {
        Object explosionRef = Resources.Load("PillarExplode");
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
