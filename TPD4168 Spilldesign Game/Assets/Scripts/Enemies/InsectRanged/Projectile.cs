using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed;
    public float lifetime;
    private float damage;

    private void Awake() {
        damage = GameObject.FindGameObjectWithTag("RangedEnemy").GetComponent<RangedEnemyController>().damage;
    }

    private void Start() {
        Invoke("DestroyProjectile", lifetime);
    }

    private void FixedUpdate() {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player_Strong") {
            GameObject.FindGameObjectWithTag("Player_Strong").GetComponent<Health>()
                .TakeDamage(damage);
            DestroyProjectile();
        }
        else if (collision.gameObject.tag == "Wall") {
            DestroyProjectile();
        }
    }
}
