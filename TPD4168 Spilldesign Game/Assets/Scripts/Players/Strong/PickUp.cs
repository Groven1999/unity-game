using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    public Vector3 Direction { get; private set; }
    [SerializeField] private GameObject itemHolding;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player_Wik")
        {
            itemHolding = collision.gameObject;
            itemHolding.GetComponent<Player_Wik_Movement>().pickedUp(true);
        }
    }
}
