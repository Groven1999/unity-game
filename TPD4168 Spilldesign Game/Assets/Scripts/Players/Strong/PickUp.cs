using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    public Vector3 Direction { get; private set; }
    [SerializeField] private GameObject itemHolding;
    private bool hasPickedUp;

    private void Awake()
    {
        hasPickedUp = false;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && hasPickedUp)
        {
            //StartCoroutine(Throw(itemHolding));

            Vector2 targetPos = GameObject.Find("ThrowPointDir").transform.position;
            itemHolding.GetComponent<Player_Wik_Movement>().Throw(targetPos);
            itemHolding = null;
            hasPickedUp = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player_Wik")
        {
            itemHolding = collision.gameObject;
            itemHolding.GetComponent<Player_Wik_Movement>().pickedUp(true);
            hasPickedUp = true;
        }
    }
}
