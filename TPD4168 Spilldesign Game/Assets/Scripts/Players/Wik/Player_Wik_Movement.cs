using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Player_Wik_Movement : MonoBehaviour
{

    private Rigidbody2D body;
    [SerializeField] private GameObject player_Strong_firePoint;
    [SerializeField] private GameObject player_Strong;
    private bool isPickedUp;
    private bool isThrown;
    private Vector2 targetPosition;
    private float throwSpeed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        isPickedUp = false;
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

        if (isThrown)
            if (throwSpeed > 0)
            {
                throwSpeed -= Random.Range(.01f, .02f);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, throwSpeed * Time.deltaTime);
            }
            else
            {
                // Stop movement
                isThrown = false;
                body.velocity = Vector2.zero;
            }
    }

    public void SetDirection(float rotation)
    {

        body.rotation = rotation + 90;

        //boxCollider.enabled = true;
    }

    public void pickedUp(bool _isPickedUp)
    {
        isPickedUp = _isPickedUp;
        
        if (_isPickedUp)
        {
            throwSpeed = 10;
        }
    }

    public void Throw(Vector2 _targetPosition)
    {
        targetPosition = _targetPosition;
        isThrown = true;
        pickedUp(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            throwSpeed = 0;
        }
    }
}
