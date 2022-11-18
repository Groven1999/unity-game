using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelGuideIconController : MonoBehaviour
{

    private GameObject levelGuideInfoHolder;

    // Declare what Image should be displayed
    public enum ImageType {
        Null,
        Pillar,
        Stinger,
        RangedEnemy,
        FlyingEnemy,
        Strong,
        Wik
    }

    public ImageType imageType;

    [Header("Text shown in the level guide box")]
    [SerializeField] public string levelGuideText;

    // Countdown, so that the player cannot activate the tutorial all the time
    private float countDown;

    private void Start() {
        levelGuideInfoHolder = GameObject.FindGameObjectWithTag("LevelGuideInfoHolder");
    }

    private void Update() {
        if (countDown >= 0) {
            countDown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player_Strong") {
            if (countDown <= 0) {

                // Change color of text inside box
                levelGuideText = levelGuideText.Replace("NEWLINE", "\n");
                levelGuideText = levelGuideText.Replace("ENEMY_START", "<color=#c40000ff>");
                levelGuideText = levelGuideText.Replace("ABILITY_START", "<color=#DB6B20>");
                levelGuideText = levelGuideText.Replace("PLAYER_STRONG", "<color=#0EC1FF>");
                levelGuideText = levelGuideText.Replace("PLAYER_WIK", "<color=#a110ff>");
                levelGuideText = levelGuideText.Replace("STRONG", "<color=#0EC1FF>STRONG</color>");
                levelGuideText = levelGuideText.Replace("WIK", "<color=#a110ff>WIK</color>");
                levelGuideText = levelGuideText.Replace("COLOR_END", "</color>");
                levelGuideText = levelGuideText.Replace("ACTIVATION_KEY", "<color=#0EC1FF>");

                levelGuideText = levelGuideText.Replace("PILLARS", "<color=#c40000ff>PILLARS</color>");
                levelGuideText = levelGuideText.Replace("PILLAR", "<color=#c40000ff>PILLAR</color>");
                levelGuideInfoHolder.GetComponent<LevelGuideController>().ShowLevelGuide(levelGuideText, imageType);
                countDown = 4;
            }
        }
    }
}
