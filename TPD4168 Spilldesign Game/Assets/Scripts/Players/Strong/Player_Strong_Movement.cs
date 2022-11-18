using UnityEngine;

public class Player_Strong_Movement : MonoBehaviour {
    private Camera cam;
    private Rigidbody2D body;
    public float movementSpeed;
    [SerializeField] public float normalMovementSpeed;

    // Used for playing sound of leapSmash land correctly
    [HideInInspector]
    public float activeTime;

    public Vector2 moveInput;

    // abilities
    public bool usingLeapSmash;
    public bool isUsingDash;

    // Cursor
    public Texture2D cursorArrow;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // Set cursor
        Cursor.SetCursor(cursorArrow, Vector3.zero, CursorMode.ForceSoftware);
    }

    private void Start() {
        body.gravityScale = 0;
        movementSpeed = 5;
        body.freezeRotation = true;
        movementSpeed = normalMovementSpeed;
    }

    private void Update() {
        // Ignore collision with Wik when in leapSmash ability
        GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");
        Physics2D.IgnoreCollision(playerWik.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), usingLeapSmash);
        gameObject.GetComponent<BoxCollider2D>().enabled = !usingLeapSmash;

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - body.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;

        if (usingLeapSmash) {
            print(activeTime);
            if (activeTime < 0.3f && activeTime > 0) {
                FindObjectOfType<AudioManager>().Play("LeapSmashAbilityLand");
                activeTime = 0;
            } else if (activeTime > 0) {
                activeTime -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate() {

        if (usingLeapSmash) {
            

            // Position of Wik
            GameObject playerWik = GameObject.FindGameObjectWithTag("Player_Wik");

            // Make Strong move towards Wik
            transform.position = Vector3.MoveTowards(transform.position, playerWik.transform.position, Time.deltaTime * movementSpeed);
        }
        else {
            moveInput.y = Input.GetAxis("Vertical");
            moveInput.x = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(moveInput.x * movementSpeed, moveInput.y * movementSpeed);
        }
    }
}
