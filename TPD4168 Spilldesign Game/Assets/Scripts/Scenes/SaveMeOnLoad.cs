using UnityEngine;

public class SaveMeOnLoad : MonoBehaviour
{
    private void Start() {
        DontDestroyOnLoad(gameObject);
    }
}
