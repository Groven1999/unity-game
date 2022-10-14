using UnityEngine;

public class Attack : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Bomb").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Explode();
        }
    }

    public void Explode()
    {
        animator.SetTrigger("bomb");
    }
}
