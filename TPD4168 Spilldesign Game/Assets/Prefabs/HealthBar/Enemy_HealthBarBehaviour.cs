using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_HealthBarBehaviour : MonoBehaviour
{
    
    public GameObject enemyObject;
    RectTransform rectTransform;

    // Healthbar style
    [Header("Healthbar Style")]
    public float offset;
    public float healthBarWidth;
    public float healthBarHeight;
    public GameObject background;
    public GameObject fill;
    public GameObject healthBar;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();

        // Style the healthbar
        RectTransform rectTransformBackground = background.GetComponent<RectTransform>();
        rectTransformBackground.sizeDelta = new Vector2(healthBarWidth, healthBarHeight);

        RectTransform rectTransformFill = fill.GetComponent<RectTransform>();
        rectTransformFill.sizeDelta = new Vector2(healthBarWidth - 0.6f, healthBarHeight - 0.4f);

        RectTransform rectTransformHealthbar = healthBar.GetComponent<RectTransform>();
        rectTransformHealthbar.sizeDelta = new Vector2(healthBarWidth - 0.6f, healthBarHeight - 0.4f);
    }

    private void Update() {
        
        // Position the healthbar above enemy at all times
        rectTransform.eulerAngles = new Vector3(0, 0, 0);
        rectTransform.position = new Vector3(enemyObject.transform.position.x, enemyObject.transform.position.y + offset, 0);
    }
}
