using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PillarsDestroyedController : MonoBehaviour
{
    private float pillarsDestroyed;
    public TextMeshProUGUI pillarsDestroyedText;
    public Health playerHealth;
    private bool victory;

    private void Start() {
        victory = false;
        pillarsDestroyed = 0;
        pillarsDestroyedText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        if (!victory) {
            if (pillarsDestroyed == 5) {
                victory = true;
                StartCoroutine(Victory());
            } else if (playerHealth.currentHealth <= 0) {
                StartCoroutine(GameOver());
            } else {
                pillarsDestroyedText.text = "PILLARS DESTROYED: " + pillarsDestroyed.ToString() + " / 5";
            }
        }
        
    }

    public void PillarDestroyed() {
        pillarsDestroyed += 1;
    }

    IEnumerator Victory() {
        pillarsDestroyedText.text = "PILLARS DESTROYED: " + pillarsDestroyed.ToString() + " / 5";

        yield return new WaitForSeconds(1.5f);

        pillarsDestroyedText.text = "VICTORY!";
        pillarsDestroyedText.color = Color.green;

        yield return null;
    }

    IEnumerator GameOver() {
        pillarsDestroyedText.text = "GAME OVER!";
        pillarsDestroyedText.color = Color.red;

        yield return null;
    }

}
