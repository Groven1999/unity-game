using TMPro;
using UnityEngine;

public class InsectMovement : MonoBehaviour {

    [SerializeField] public float baseMovementSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] public bool shouldRespawn;
    public bool isSpawnedFromPillar;

    // If it should follow a trigger for when a level-goal starts
    [SerializeField] public bool followsBeginGoalCollider;
    [SerializeField] public bool shouldMoveTowardsPlayer;
    [SerializeField] public Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;

    private void Start() {
        movementSpeed = baseMovementSpeed;
    }

    private void Awake() {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update() {

        if (followsBeginGoalCollider || isSpawnedFromPillar) {
            if (shouldMoveTowardsPlayer) {
                GameObject playerStrong = GameObject.FindGameObjectWithTag("Player_Strong");

                // Make enemy move towards player
                transform.position = Vector3.MoveTowards(transform.position, playerStrong.transform.position, Time.deltaTime * movementSpeed);

                // Rotate enemy towards player
                RotateTowardsTarget(playerStrong.transform.position);
            } else {
                // Move back to startposition and reset health (Reset health happens in "LevelController script"
                transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * movementSpeed);
                RotateTowardsTarget(startPosition);

                if (transform.position == startPosition) {
                    transform.rotation = startRotation;
                }
            }
        }             
    }

    private void RotateTowardsTarget(Vector3 targetPosition) {
        var offset = -90f;
        Vector2 direction = targetPosition - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}