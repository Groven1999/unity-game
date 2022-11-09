using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] public float baseHealth;
    [SerializeField] public float health;
    [SerializeField] public float damage;

    [HideInInspector]
    public Health playerHealth;

    [Header("HealthBar")]
    public HealthBarImage healthBar;

    Rigidbody2D rb;

    // Knockback
    public bool isKnockbacked = false;

    // Particle explosion on death
    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object explosionRef;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        //matDefault = spriteRenderer.material;
        explosionRef = Resources.Load("ExplosionOnDeath2");
        rb = GetComponent<Rigidbody2D>();
        health = baseHealth;
        playerHealth = GameObject.FindGameObjectWithTag("Player_Strong").GetComponent<Health>();
    }

    private void Update() {
        // Makes enemy NOT get pushed away, unless it's getting knocked back from some ability (e.g the Bomb)
        if (!isKnockbacked) {
            rb.velocity = Vector2.zero;
        }
    }

    public void takeDamage(float _damage) {
        health -= _damage;

        if (health <= 0) {
            KillSelf();
        }

        healthBar.UpdateHealth(health / baseHealth);
    }

    public void KillSelf() {
        isKnockbacked = false;
        gameObject.SetActive(false);

        // Particle explosion
        GetComponent<ParticleEffectExplosion>().ParticleExplosion();

        if (gameObject.tag == "Enemy_Insect") {
            gameObject.SetActive(true);
            health = baseHealth;
            gameObject.transform.position = new Vector3(Random.Range(-10.0f, 25.0f), Random.Range(-4.0f, 9.0f), 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player_Strong") {
            playerHealth.TakeDamage(damage);
        }
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, GameObject player_Wik) {
        float timer = 0;
        isKnockbacked = true;

        while (knockbackDuration > timer) {
            timer += Time.deltaTime;
            Vector2 direction = (player_Wik.transform.position - transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }

        //yield return 0;
        yield return new WaitForSeconds(knockbackDuration);
        isKnockbacked = false;
    }
}
