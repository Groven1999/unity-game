using UnityEngine;

public class BeginGoalCollider : MonoBehaviour
{
    public bool isEndGoal;
    public bool isStartGoal;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == "Player_Strong") {
            if (isStartGoal) {
                transform.parent.GetComponent<LevelController>().BeginLevelGoal();
            } else if (isEndGoal) {
                transform.parent.GetComponent<LevelController>().EndLevelGoal();
            }
        }
    }
}
