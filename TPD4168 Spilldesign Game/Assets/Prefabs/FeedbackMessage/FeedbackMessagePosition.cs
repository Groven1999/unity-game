using UnityEngine;

public class FeedbackMessagePosition : MonoBehaviour
{
    private GameObject playerStrong;

    // How far above Strong should text popup
    public float yOffset;

    private void Start() {
        playerStrong = GameObject.FindGameObjectWithTag("Player_Strong");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerStrong.transform.position + new Vector3(0, yOffset, 0);
    }
}
