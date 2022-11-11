using UnityEngine;

public class AbilityPickupBehaviour : MonoBehaviour
{

    public Ability abilityToUnlock;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player_Strong") {

            // TODO: Play animation

            // Unlock ability
            abilityToUnlock.isUnlocked = true;

            // Deactivate object
            gameObject.SetActive(false);

            // Show tutorial screen
            GameObject.FindGameObjectWithTag("TutorialContentScreen").GetComponent<TutorialContentController>().ShowTutorialScreen(abilityToUnlock.name);
        }
    }
}
