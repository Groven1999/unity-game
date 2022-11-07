using UnityEngine;
using UnityEngine.UI;

public class HealthBarImage : MonoBehaviour
{

    public Image healthBar;

    public void UpdateHealth(float fraction) {
        healthBar.fillAmount = fraction;
    }

}
