using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player_Strong_Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D body;
    [SerializeField] private Camera cam;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        body.gravityScale = 0;
        movementSpeed = 5;
        body.freezeRotation = true;
    }

    private void Update()
    {

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDirection = mousePosition - body.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed);
    }
}
