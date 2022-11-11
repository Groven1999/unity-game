using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
}
