using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public GameObject mainMenu;
    public Slider difficultySlider;
    public Text sliderValue;
    public EnemyPaddleController enemyPaddle;
    public GameObject infoBanner;

    void Start() {
        StartCoroutine(HideInfoBanner());
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            DisplayOrHideMenu();
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ResetPoints() {
        Scores.ResetTable();
    }

    public void DifficultyValueChanged(){
        enemyPaddle.DifficultyLevel = (int)difficultySlider.value;
        sliderValue.text = ((int)difficultySlider.value).ToString();
    }

    public void DisplayOrHideMenu() {
        if(IsGameStopped()) {
            ContinueGame();
            mainMenu.SetActive(false);
            Cursor.visible = false;
        }
        else {
            StopGame();
            difficultySlider.value = enemyPaddle.DifficultyLevel;
            mainMenu.SetActive(true);
            Cursor.visible = true;
        }
    }

    bool IsGameStopped() {
        return !(Time.timeScale > 0f);
    }

    void StopGame() {
        Time.timeScale = 0f;
    }

    void ContinueGame() {
        Time.timeScale = 1f;
    }

    IEnumerator HideInfoBanner() {
        yield return new WaitForSeconds(5f);
        infoBanner.SetActive(false);
    }
}
