using UnityEngine;

public class BackgroundPosition : MonoBehaviour
{

    private GameObject mainCamera;

    private float camerax;
    private float cameray;

    private void Awake() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCameraHolder");
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
    }*/

    void LateUpdate() {
        camerax = Camera.main.transform.position.x;
        cameray = Camera.main.transform.position.y;
        transform.position = new Vector3(camerax, cameray, transform.position.z);
    }
}
