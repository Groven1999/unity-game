using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] Health playerHealth;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player_Strong") {
            playerHealth.TakeDamage(damage);
        }
    }
}
