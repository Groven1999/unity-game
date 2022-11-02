using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] public float health;
    [SerializeField] public float damage;

    // Particle explosion on death
    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object explosionRef;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
        explosionRef = Resources.Load("ExplosionOnDeath2");
    }

    public void takeDamage(float _damage) {
        health -= _damage;
        if (health <= 0) {
            KillSelf();
        }
    }

    public void KillSelf() {
        gameObject.SetActive(false);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(3, 3, 0);
    }
}
