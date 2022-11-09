using System.Collections;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    public GameObject player_Strong;
    public Transform firePoint;
    public Transform gun;
    public float damage;

    public GameObject enemyProjectile;

    public float followPlayerRange;
    private bool inRange;
    public float attackRange;

    public float startTimeBetweenShots;
    private float timeBetweenShots;

    private void Awake() {
        player_Strong = GameObject.FindGameObjectWithTag("Player_Strong");
    }

    private void Update() {
        Vector3 difference = player_Strong.transform.position - gun.transform.position;

        if (Vector2.Distance(transform.position, player_Strong.transform.position) <= attackRange) {
            RotateTowardsTarget(player_Strong);
            if (timeBetweenShots <= 0) {
                Instantiate(enemyProjectile, firePoint.position, firePoint.transform.rotation);
                StartCoroutine(ShrinkAnimation());
                timeBetweenShots = startTimeBetweenShots;
            }
            else {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate() {

    }

    IEnumerator ShrinkAnimation() {
        Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0);
        transform.localScale -= scaleChange;
        yield return new WaitForSeconds(0.07f);
        transform.localScale += scaleChange;
    }

    

    public void RotateTowardsTarget(GameObject target) {
        var offset = -90f;
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
