using UnityEngine;

public class FlyingEnemySpawner : MonoBehaviour
{

    public bool isActive;

    public GameObject flyingEnemy;
    [SerializeField] public float spawnCountdown;
    [SerializeField] public float spawnCount;

    // Used in script
    private float countDown;
    GameObject spawnPosition;

    private void Start() {
        countDown = spawnCountdown;
    }

    private void Update() {
        if (!isActive) {
            return;
        }

        if (countDown <= 0) {
            countDown = spawnCountdown;
            spawnPosition = GameObject.FindGameObjectWithTag("Player_Strong_SpawnFlyingEnemyPoint");
            var newFlyingEnemy = Instantiate(flyingEnemy, spawnPosition.transform.position, spawnPosition.transform.rotation);
            newFlyingEnemy.transform.parent = gameObject.transform;
        } else {
            countDown -= Time.deltaTime;
        }
    }
}
