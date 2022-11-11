using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("Player_Strong").GetComponent<Health>();
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update() {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

}
