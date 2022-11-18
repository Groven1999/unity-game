using UnityEngine;

public class PillarController : MonoBehaviour
{

    // THIS SCRIPT COULD BE USED LATER

    // Should spawn Stingers around it
    [SerializeField] public GameObject pillarSpawnStingerPoint;
    [SerializeField] public GameObject stinger;
    [SerializeField] public float spawnRadius;

    private GameObject playerStrong;

    [SerializeField] public float spawnCountdown;
    private float countdown;

    private void Start() {
        countdown = 1;
    }

    private void Awake() {
        playerStrong = GameObject.FindGameObjectWithTag("Player_Strong");
    }

    private void Update() {

        print("STRONG: " + playerStrong.transform.position);
        print("TRANSFORM: " + transform.position);

        // Only spawn Stingers if Strong is close enough, and within a countdown
        if (Vector2.Distance(transform.position, playerStrong.transform.position) <= spawnRadius) {
            print("RANGE");
            if (countdown <= 0) {
                stinger.GetComponent<InsectMovement>().shouldMoveTowardsPlayer = true;
                stinger.GetComponent<InsectMovement>().isSpawnedFromPillar = true;
                Instantiate(stinger, pillarSpawnStingerPoint.transform.position, pillarSpawnStingerPoint.transform.rotation);
                countdown = spawnCountdown;
            }
            else {
                countdown -= Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
