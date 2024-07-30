using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public GameObject gameMenuUI;
    public int stageNo;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void GameClear()
    {
        // ステージクリア情報を保存
        if (PlayerPrefs.GetInt("CLEAR", 0) < stageNo)
        {
            PlayerPrefs.SetInt("CLEAR", stageNo);
        }

        gameClearUI.SetActive(true);
    }

    public void Retry()
    {
        Invoke(nameof(RetryLoadScene), 0.2f);
    }

    public void RetryLoadScene()
    {
        SceneManager.LoadScene(stageNo);
    }

    public void Next()
    {
        Invoke(nameof(NextLoadScene), 0.2f);
    }

    public void NextLoadScene()
    {
        SceneManager.LoadScene(stageNo + 1);
    }

    public void StageSelect()
    {
        Invoke(nameof(StageSelectLordScene), 0.2f);
    }

    public void StageSelectLordScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    // 一時停止ボタンを押下時の処理
    public void PushPauseButton()
    {
        TogglePause();
        gameMenuUI.SetActive(true);
    }

    // 一時停止処理
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    // 再開ボタンを押下時の処理
    public void PushRestartButton()
    {
        TogglePause();
        gameMenuUI.SetActive(false);
    }

    // リトライボタンを押下時の処理(導線: 一時停止ボタン)
    public void PushRetryButton()
    {
        TogglePause();
        SceneManager.LoadScene(stageNo);
    }

    // ステージ選択ボタンを押下時の処理(導線: 一時停止ボタン)
    public void PushStageSelectButton()
    {
        TogglePause();
        SceneManager.LoadScene("StageSelect");
    }
}