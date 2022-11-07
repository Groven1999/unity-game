using UnityEngine;

public class InsectMovement : MonoBehaviour {

    [SerializeField] public float baseMovementSpeed;
    [SerializeField] private float movementSpeed;

    private void Start() {
        movementSpeed = baseMovementSpeed;
    }

    // Update is called once per frame
    void Update() {
        GameObject playerStrong = GameObject.FindGameObjectWithTag("Player_Strong");

        // Make enemy move towards player
        transform.position = Vector3.MoveTowards(transform.position, playerStrong.transform.position, Time.deltaTime * movementSpeed);

        // Rotate enemy towards player
        RotateTowardsTarget(playerStrong);
    }

    private void RotateTowardsTarget(GameObject target) {
        var offset = -90f;
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}