using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_ : MonoBehaviour
{
    static GameManager_ gameManager;
    UIManager uiManager;

    public static GameManager_ Instance
    {
        get { return gameManager; }
    }
    public UIManager UIManager
    {
        get { return uiManager; }
    }

    private int currentScore = 0;
    private int bestScore = 0; // �ְ� ����

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateBestScore(bestScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        
        // �ְ� ���� ����
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore); // �ְ� ���� ����
        }

        PlayerPrefs.SetInt("MiniGameScore", currentScore); // ���� ���� �� ���� ���� ����
        uiManager.SetRestart();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        uiManager.UpdateBestScore(bestScore);
    }

    
}
