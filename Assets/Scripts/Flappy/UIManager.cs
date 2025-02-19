using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI MainSceneText;
    public TextMeshProUGUI bestScoreText;
    public Image image; //게임오버 이미지
    public GameObject restartPanel; //판넬 
    public GameObject startPanel; // 시작 판넬
    public GameObject MainScenePanel; //돌아가기 판넬

    public GameManager_ gameManager;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        // TextMeshPro의 Material 가져오기
        Material textMaterial = restartText.fontMaterial;
        Material textMaterial2 = MainSceneText.fontMaterial;

        // 외곽선 두께 조절
        textMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);
        textMaterial2.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);

        // 외곽선 색상 변경 (검정)
        textMaterial.SetColor(ShaderUtilities.ID_OutlineColor, Color.black);
        textMaterial2.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);

        Time.timeScale = 0;
        startPanel.SetActive(true);
        restartPanel.gameObject.SetActive(false);
        MainScenePanel.SetActive(false);
        //restartText.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        
    }
    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(2f); // 3초 대기
        image.gameObject.SetActive(false);
        restartPanel.gameObject.SetActive(true);
        MainScenePanel.SetActive(true);
        //restartText.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        startPanel.SetActive(false); // 시작 화면 숨김
        Time.timeScale = 1;          // 게임 시작!
    }
    public void SetRestart()
    {
        StopAllCoroutines(); // 기존 코루틴 중지
        image.gameObject.SetActive(true);
        StartCoroutine(DelayedAction()); //코루틴 활용
        
    }
    public void OnClickRestartButton()
    {
        
        Time.timeScale = 1;
        //PlayerPrefs.DeleteKey("MiniGameScore");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickMainSceneButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int bestScore)
    {
        bestScoreText.text = bestScore.ToString();
    }
}
