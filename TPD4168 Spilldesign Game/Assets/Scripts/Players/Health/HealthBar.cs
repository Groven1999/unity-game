using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("Player_Strong").GetComponent<Health>();
        totalHealthBar = GameObject.FindGameObjectWithTag("UI_HealthBarTotal").GetComponent<Image>();
        currentHealthBar = GameObject.FindGameObjectWithTag("UI_HealthBarCurrent").GetComponent<Image>();
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update() {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

}
