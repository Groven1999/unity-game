using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelGuideController : MonoBehaviour
{
    private TextMeshProUGUI levelGuideContentText;
    private GameObject levelGuideImage;
    private Image levelGuideBackgroundImage;
    private GameObject levelGuideInfo;

    private void Awake() {
        levelGuideContentText = GameObject.FindGameObjectWithTag("LevelGuideContent").GetComponent<TextMeshProUGUI>();
        levelGuideBackgroundImage = GameObject.FindGameObjectWithTag("LevelGuideBackgroundImage").GetComponent<Image>();
        levelGuideContentText.text = "test";
        
    }

    private void Start() {
        levelGuideImage = GameObject.FindGameObjectWithTag("LevelGuideImage");
        levelGuideImage.SetActive(false);
        levelGuideInfo = GameObject.FindGameObjectWithTag("LevelGuideInfo");
        levelGuideInfo.SetActive(false);
    }

    /*Null,
        Pillar,
        Stinger,
        RangedEnemy,
        Strong,
        Wik*/

    public void ShowLevelGuide(string guideContent, LevelGuideIconController.ImageType guideImage, string backgroundColor = "#969696") {
        // Stop time
        Time.timeScale = 0;

        // Update content
        levelGuideContentText.text = guideContent;

        // Update the Image
        string guideImageNameInResources = "";

        switch (guideImage) {
            case LevelGuideIconController.ImageType.Pillar:
                guideImageNameInResources = "pillar";
                break;
            case LevelGuideIconController.ImageType.Stinger:
                guideImageNameInResources = "enemy1_full";
                break;
            case LevelGuideIconController.ImageType.RangedEnemy:
                guideImageNameInResources = "rangedEnemy1";
                break;
            case LevelGuideIconController.ImageType.FlyingEnemy:
                guideImageNameInResources = "flyingEnemy_1";
                break;
            case LevelGuideIconController.ImageType.Strong:
                guideImageNameInResources = "strong";
                break;
            case LevelGuideIconController.ImageType.Wik:
                guideImageNameInResources = "Wik2";
                break;
            case LevelGuideIconController.ImageType.Null:
                guideImageNameInResources = "";
                break;
        }

        if (guideImageNameInResources != "") {
            levelGuideImage.SetActive(true);
            levelGuideImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(guideImageNameInResources);
        }

        // Activate object
        levelGuideInfo.SetActive(true);

        //levelGuideBackgroundImage.color = backgroundColor;
    }

    

    public void ExitTutorialSreen() {

        // Resume game
        Time.timeScale = 1;

        levelGuideImage.SetActive(false);
        levelGuideInfo.SetActive(false);
    }

    public void Test() {
        print("hei");
    }
}
