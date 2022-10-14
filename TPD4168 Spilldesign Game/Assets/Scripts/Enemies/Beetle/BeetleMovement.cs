using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

public class BeetleMovement : MonoBehaviour
{

    private float speed;

    private void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerStrong = GameObject.FindGameObjectWithTag("Player_Strong");

        // Make enemy move towards player
        transform.position = Vector3.MoveTowards(transform.position, playerStrong.transform.position, Time.deltaTime * speed);

        // Rotate enemy towards player
        RotateTowardsTarget(playerStrong);
    }

    public void isKilled()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        transform.position = screenPosition;
    }

    private void RotateTowardsTarget(GameObject target)
    {
        var offset = -90f;
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
