using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public GameObject[] stageButtons; // ステージ選択ボタン

    // Start is called before the first frame update
    void Start()
    {
        int clearStageNo = PlayerPrefs.GetInt("CLEAR", 0);

        // ステージ選択ボタンを有効化
        for (int i = 0; i <= stageButtons.GetUpperBound(0); i++)
        {
            bool buttonEnabledFlag;

            if (clearStageNo < i)
            {
                buttonEnabledFlag = false;
            }
            else
            {
                buttonEnabledFlag = true;
            }

            // ボタンの有効化/無効化を設定
            stageButtons[i].GetComponent<Button>().interactable = buttonEnabledFlag;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ステージ選択ボタン押下時の処理
    public void PushStageSelectButton(int stageNo)
    {
        SceneManager.LoadScene("BaseGameMap");
    }
}
