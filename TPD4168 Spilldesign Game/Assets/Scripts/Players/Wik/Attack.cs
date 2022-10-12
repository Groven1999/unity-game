using UnityEngine;

public class Attack : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Wik_explosion").GetComponent<Animator>();
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
        animator.SetTrigger("explode");
    }
}
