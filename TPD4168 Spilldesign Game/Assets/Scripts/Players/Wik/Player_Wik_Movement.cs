using UnityEngine;

public class Player_Wik_Movement : MonoBehaviour
{

    [SerializeField] private GameObject player_Strong_firePoint;
    [SerializeField] private GameObject player_Strong;
    public Rigidbody2D body;
    public bool isPickedUp;
    public bool isThrown;
    public bool isRetracted;
    public Vector2 targetPosition;

    // Movement speed
    public float baseMovementSpeed;
    public float movementSpeed;

    private void Start()
    {
        movementSpeed = baseMovementSpeed;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        pickedUp(false);
    }

    private void Update()
    {
        if (isPickedUp)
        {
            // Updates the POSITION whenever Wik gets picked up by Strong
            transform.position = new Vector3(player_Strong_firePoint.transform.position.x, player_Strong_firePoint.transform.position.y, player_Strong_firePoint.transform.position.z);

            // Updates the ROTATION when picked up
            transform.rotation = Quaternion.Euler(0, 0, player_Strong.transform.rotation.eulerAngles.z);
        }
    }

    private void FixedUpdate()
    {
        // If Strong throws or retracts Wik
        if (isThrown) {
            isPickedUp = false;
            movementSpeed = 5;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
        } else if (isRetracted) {
            // Ignore collision with enemies
            targetPosition = GameObject.FindGameObjectWithTag("Player_Strong").transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
        } else {
            movementSpeed = 0;
            //Physics.IgnoreLayerCollision(6, 8, false);
        }
    }

    public void SetDirection(float rotation)
    {
        body.rotation = rotation + 90;
    }

    public void pickedUp(bool _isPickedUp)
    {
        isPickedUp = _isPickedUp;

        // Ignore collision with player Strong
        GameObject playerStrong = GameObject.FindGameObjectWithTag("Player_Strong");
        Physics2D.IgnoreCollision(playerStrong.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), _isPickedUp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy_Beetle")
        {
            movementSpeed = 0;
            body.velocity = Vector2.zero;
        }
    }
}
