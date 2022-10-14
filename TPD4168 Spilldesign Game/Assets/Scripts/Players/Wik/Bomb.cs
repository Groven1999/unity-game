using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Ignore collision with Strong and Wik
        GameObject player_strong = GameObject.FindGameObjectWithTag("Player_Strong");
        GameObject player_wik = GameObject.FindGameObjectWithTag("Player_Wik");
        Physics2D.IgnoreCollision(player_strong.GetComponent<BoxCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
        Physics2D.IgnoreCollision(player_wik.GetComponent<BoxCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, 5);

        foreach(var hitCollider in hitColliders)
        {
            var enemy = hitCollider.gameObject;
            if (enemy.tag == "Enemy_Beetle")
            {
                enemy.GetComponent<BeetleMovement>().isKilled();
            }
        }
    }
}
