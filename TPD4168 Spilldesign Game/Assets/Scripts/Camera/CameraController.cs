using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float speed;
    public GameObject cameraholder;

    // Follow player camera
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Awake() {
        cameraholder = GameObject.FindGameObjectWithTag("MainCameraHolder");
        player = GameObject.FindGameObjectWithTag("Player_Strong").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraholder.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
