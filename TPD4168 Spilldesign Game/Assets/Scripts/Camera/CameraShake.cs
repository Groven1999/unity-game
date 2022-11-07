using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    // These variables are used for shaking when using abilities
    public bool shake = false;
    public float shakeDuration;
    public float shakeMagnitude;

    void Update() {
        if (shake) {
            shake = false;
            StartCoroutine(Shake(shakeDuration, shakeMagnitude));
        }
    }

    public IEnumerator Shake(float duration, float magnitude) {
        
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

}
