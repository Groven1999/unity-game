using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    [SerializeField] public int currentLevel;

    private GameObject uiLevelGoalText;

    // Level 2
    private int totalNumOfEnemyInsects;
    private int currentNumOfEnemyInsects;
    private int prevNumOfInsects;

    // Level 4
    private int currentNumOfEnemyPillars;
    private int totalNumOfEnemyPillars;
    private int prevNumOfPillars;

    // Level 5
    private int lvl5_currentNumOfEnemyPillars;
    private int lvl5_totalNumOfEnemyPillars;
    private int lvl5_prevNumOfPillars;
    

    public bool hasBoxAroundAbilityUnlock;

    private GameObject boxForAbilityUnlock;

    // This variables is used by the NextLevelPad aswell, to check if gameObjective is completed
    public bool objectiveComplete;

    // Goal of the level
    private bool isGoalActive;

    private void Start() {
        prevNumOfInsects = 0;
        prevNumOfPillars = 0;
        lvl5_prevNumOfPillars = 0;

        uiLevelGoalText = GameObject.FindGameObjectWithTag("UI_GoalText");
        uiLevelGoalText.SetActive(false);
    }

    private void Awake() {

        objectiveComplete = false;

        switch(currentLevel) {

            // ----- LEVEL 2 ----- \\
            case 2:
                GameObject[] enemyInsects = GameObject.FindGameObjectsWithTag("Enemy_Insect");
                totalNumOfEnemyInsects = enemyInsects.Length;
                break;

            // ----- LEVEL 4 ----- \\
            case 4:
                GameObject[] totalEnemyPillarsCount = GameObject.FindGameObjectsWithTag("Enemy_Pillar");
                totalNumOfEnemyPillars = totalEnemyPillarsCount.Length;
                if (hasBoxAroundAbilityUnlock) {
                    boxForAbilityUnlock = GameObject.FindGameObjectWithTag("BoxForAbilityUnlock");
                }
                break;

            // ----- LEVEL 5 ----- \\
            case 5:
                GameObject[] lvl5_totalEnemyPillarsCount = GameObject.FindGameObjectsWithTag("Enemy_Pillar");
                lvl5_totalNumOfEnemyPillars = lvl5_totalEnemyPillarsCount.Length;
                if (hasBoxAroundAbilityUnlock) {
                    boxForAbilityUnlock = GameObject.FindGameObjectWithTag("BoxForAbilityUnlock");
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoalActive) {
            if (!objectiveComplete) {
                switch (currentLevel) {
                    case 2:
                        GameObject[] enemyInsects = GameObject.FindGameObjectsWithTag("Enemy_Insect");

                        currentNumOfEnemyInsects = enemyInsects.Length;
                        int enemyInsectsKilled = totalNumOfEnemyInsects - currentNumOfEnemyInsects;
                        
                        // Animate the goal text whenever a insect is killed
                        if (enemyInsectsKilled > prevNumOfInsects) {
                            uiLevelGoalText.GetComponent<Animator>().SetTrigger("textUpdated");
                            prevNumOfInsects = enemyInsectsKilled;
                        }

                        // Update the UI Goal Text: "Enemy stingers killed: 0/3"
                        if (currentNumOfEnemyInsects <= 0) {
                            UpdateUiLevelGoalText("GOOD JOB!\nALL STINGERS KILLED");
                            objectiveComplete = true;
                        } else {
                            UpdateUiLevelGoalText("ENEMY STINGERS KILLED: \n" + enemyInsectsKilled.ToString() + " / " + totalNumOfEnemyInsects.ToString());
                        }

                        // Check if any of the stingers take damage. If yes, tell everyone to move towards Strong
                        for (int i = 0; i < enemyInsects.Length; i++) {
                            if (enemyInsects[i] != null) {
                                if (enemyInsects[i].GetComponent<InsectMovement>().shouldMoveTowardsPlayer == true) {
                                    for (int x = 0; x < enemyInsects.Length; x++) {
                                        if (enemyInsects[x] != null) {
                                            enemyInsects[x].GetComponent<InsectMovement>().shouldMoveTowardsPlayer = true;
                                        }
                                    }
                                    break;
                                }
                            }
                        }

                        break;

                    // ----- LEVEL 4 ----- \\
                    case 4:
                        // Update number of enemy Pillars left
                        GameObject[] enemyPillars = GameObject.FindGameObjectsWithTag("Enemy_Pillar");

                        currentNumOfEnemyPillars = enemyPillars.Length;
                        int enemyPillarsDestroyed = totalNumOfEnemyPillars - currentNumOfEnemyPillars;

                        // Animate the goal text whenever a insect is killed
                        if (enemyPillarsDestroyed > prevNumOfPillars) {
                            uiLevelGoalText.GetComponent<Animator>().SetTrigger("textUpdated");
                            prevNumOfPillars = enemyPillarsDestroyed;
                        }

                        if (currentNumOfEnemyPillars <= 0) {
                            UpdateUiLevelGoalText("WELL DONE!\nALL PILLARS DESTROYED!");

                            if (hasBoxAroundAbilityUnlock) {
                                boxForAbilityUnlock.GetComponent<DestroyBox>().StartCoroutine(boxForAbilityUnlock.GetComponent<DestroyBox>().DestroyBoxEffect());
                            }

                            objectiveComplete = true;
                        }
                        else {
                            UpdateUiLevelGoalText("PILLARS DESTROYED: \n" + enemyPillarsDestroyed.ToString() + " / " + totalNumOfEnemyPillars.ToString());
                        }
                        break;
                    case 5:
                        // Update number of enemy Pillars left
                        GameObject[] lvl5_enemyPillars = GameObject.FindGameObjectsWithTag("Enemy_Pillar");

                        lvl5_currentNumOfEnemyPillars = lvl5_enemyPillars.Length;
                        int lvl5_enemyPillarsDestroyed = lvl5_totalNumOfEnemyPillars - lvl5_currentNumOfEnemyPillars;

                        // Animate the goal text whenever a insect is killed
                        if (lvl5_enemyPillarsDestroyed > lvl5_prevNumOfPillars) {
                            uiLevelGoalText.GetComponent<Animator>().SetTrigger("textUpdated");
                            lvl5_prevNumOfPillars = lvl5_enemyPillarsDestroyed;
                        }

                        if (lvl5_currentNumOfEnemyPillars <= 0) {
                            UpdateUiLevelGoalText("WELL DONE!\nALL PILLARS DESTROYED!");

                            if (hasBoxAroundAbilityUnlock) {
                                boxForAbilityUnlock.GetComponent<DestroyBox>().StartCoroutine(boxForAbilityUnlock.GetComponent<DestroyBox>().DestroyBoxEffect());
                            }

                            objectiveComplete = true;
                        }
                        else {
                            UpdateUiLevelGoalText("PILLARS DESTROYED: \n" + lvl5_enemyPillarsDestroyed.ToString() + " / " + lvl5_totalNumOfEnemyPillars.ToString());
                        }

                        break;
                }
                
            }
        } else if (!isGoalActive) {
            // Reset text
            uiLevelGoalText.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    public void BeginLevelGoal() {
        uiLevelGoalText.SetActive(true);
        isGoalActive = true;

        switch (currentLevel) {
            // ----- LEVEL 2 ----- \\
            /*case 2:
                GameObject[] enemyInsects2 = GameObject.FindGameObjectsWithTag("Enemy_Insect");
                for (int i = 0; i < enemyInsects2.Length; i++) {
                    if (enemyInsects2[i] != null) {
                        enemyInsects2[i].GetComponent<InsectMovement>().shouldMoveTowardsPlayer = true;
                    }
                }
                break;*/

            // ----- LEVEL 4 ----- \\
            case 4:
                // Tell all Insects to move towards player
                GameObject[] enemyInsects = GameObject.FindGameObjectsWithTag("Enemy_Insect");
                for (int i = 0; i < enemyInsects.Length; i++) {
                    if (enemyInsects[i] != null) {
                        enemyInsects[i].GetComponent<InsectMovement>().shouldMoveTowardsPlayer = true;
                    }
                }
                break;

            // ----- LEVEL 5 ----- \\
            case 5:
                GameObject lvl5_flyingEnemySpawner = GameObject.FindGameObjectWithTag("FlyingEnemySpawner");
                lvl5_flyingEnemySpawner.GetComponent<FlyingEnemySpawner>().isActive = true;
                break;
        }

        
    }

    public void EndLevelGoal() {
        isGoalActive = false;

        switch (currentLevel) {
            // ----- LEVEL 2 ----- \\
            case 2:
                GameObject[] enemyInsects2 = GameObject.FindGameObjectsWithTag("Enemy_Insect");
                for (int i = 0; i < enemyInsects2.Length; i++) {
                    if (enemyInsects2[i] != null) {
                        enemyInsects2[i].GetComponent<InsectMovement>().shouldMoveTowardsPlayer = false;
                        enemyInsects2[i].GetComponent<EnemyBehaviour>().ResetHealth();
                    }
                }
                break;
            // ----- LEVEL 4 ----- \\
            case 4:
                // Tell all Insects to stop moving
                GameObject[] enemyInsects = GameObject.FindGameObjectsWithTag("Enemy_Insect");
                for (int i = 0; i < enemyInsects.Length; i++) {
                    if (enemyInsects[i] != null) {
                        enemyInsects[i].GetComponent<InsectMovement>().shouldMoveTowardsPlayer = false;
                        enemyInsects[i].GetComponent<EnemyBehaviour>().ResetHealth();
                    }
                }
                break;

            // ----- LEVEL 5 ----- \\
            case 5:
                GameObject lvl5_flyingEnemySpawner = GameObject.FindGameObjectWithTag("FlyingEnemySpawner");
                lvl5_flyingEnemySpawner.GetComponent<FlyingEnemySpawner>().isActive = false;
                break;
        }
    }

    private void UpdateUiLevelGoalText(string text) {
        uiLevelGoalText.GetComponent<TextMeshProUGUI>().color = Color.white;
        text = text.Replace("STINGERS", "<color=#c40000ff>STINGERS</color>");
        text = text.Replace("STINGER", "<color=#c40000ff>STINGER</color>");

        text = text.Replace("PILLARS", "<color=#c40000ff>PILLARS</color>");
        text = text.Replace("PILLAR", "<color=#c40000ff>PILLAR</color>");
        uiLevelGoalText.GetComponent<TextMeshProUGUI>().text = text;
    }
}
