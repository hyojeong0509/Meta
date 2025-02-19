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
    public Image image; //���ӿ��� �̹���
    public GameObject restartPanel; //�ǳ� 
    public GameObject startPanel; // ���� �ǳ�
    public GameObject MainScenePanel; //���ư��� �ǳ�

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

        // TextMeshPro�� Material ��������
        Material textMaterial = restartText.fontMaterial;
        Material textMaterial2 = MainSceneText.fontMaterial;

        // �ܰ��� �β� ����
        textMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);
        textMaterial2.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);

        // �ܰ��� ���� ���� (����)
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
        yield return new WaitForSeconds(2f); // 3�� ���
        image.gameObject.SetActive(false);
        restartPanel.gameObject.SetActive(true);
        MainScenePanel.SetActive(true);
        //restartText.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        startPanel.SetActive(false); // ���� ȭ�� ����
        Time.timeScale = 1;          // ���� ����!
    }
    public void SetRestart()
    {
        StopAllCoroutines(); // ���� �ڷ�ƾ ����
        image.gameObject.SetActive(true);
        StartCoroutine(DelayedAction()); //�ڷ�ƾ Ȱ��
        
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
