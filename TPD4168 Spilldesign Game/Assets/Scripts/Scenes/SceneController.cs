using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public int currentLevel;
    private bool condition;

    [Header("Level 3")]
    [SerializeField] public Ability bombAbility;

    // Level 1: Strong should unlock Retract, and retract wik before proceeding to next level -> Condition: Wik = isPickedUp;

    private void Awake() {
        
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel(string levelName) {
        try {
            SceneManager.LoadScene(levelName);
        } catch {
            Debug.LogError("Could not load level: " + levelName);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        FeedbackMessageController feedbackMessageController = GameObject.FindGameObjectWithTag("FeedbackMessageHolder").GetComponent<FeedbackMessageController>();

        var isWikPickedUp = GameObject.FindGameObjectWithTag("Player_Wik").GetComponent<Player_Wik_Movement>().isPickedUp;

        if (collision.gameObject.tag == "Player_Strong") {

            // Sets condition based on the Current Level
            switch (currentLevel) {

                // ----- LEVEL 1 ----- \\
                case 1:
                    if (isWikPickedUp) {
                        LoadLevel("Level_2");
                    } 
                    else {
                        feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("Pick up <color=#a110ff>WIK</color> before proceeding"));
                    }
                    break;

                // ----- LEVEL 2 ----- \\
                case 2:

                    if (!GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>().objectiveComplete) {
                        feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("Kill all <color=#c40000ff>enemies</color>"));
                    } 
                    else if (!isWikPickedUp) {
                        feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("Pick up <color=#a110ff>WIK</color> before proceeding"));
                    } 
                    else {
                        LoadLevel("Level_3");
                    }
                    break;

                // ----- LEVEL 3 ----- \\
                case 3:
                    if (!bombAbility.isUnlocked) {
                        feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("Find and unlock \n<color=#DB6B20>BOMB</color>!"));
                    } else if (!isWikPickedUp) {
                        feedbackMessageController.StartCoroutine(feedbackMessageController.AlertFeedbackMessage("Pick up <color=#a110ff>WIK</color> before proceeding"));
                    }
                    else {
                        LoadLevel("Level_4");
                    }
                    break;
                // ----- LEVEL 4 ----- \\
                case 4:
                    LoadLevel("Level_5");
                    break;
            }
        }
    }

    public void PlayerDead() {
        // Load screen "Game over", want to restart?
    }
}
