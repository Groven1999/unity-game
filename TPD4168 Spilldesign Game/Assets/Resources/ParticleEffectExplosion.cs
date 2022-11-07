using UnityEngine;

public class ParticleEffectExplosion : MonoBehaviour
{

    private Object explosionRef;

    private void Start() {
        explosionRef = Resources.Load("ExplosionOnDeath2");
    }

    public void ParticleExplosion() {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
