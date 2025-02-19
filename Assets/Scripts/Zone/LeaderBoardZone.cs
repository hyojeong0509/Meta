using TMPro;
using UnityEngine;

public class LeaderBoardZone : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText; //  최고 점수 UI 연결
    public GameObject bestScoreUI;
    void Start()
    {
        bestScoreUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어가 들어왔을 때만
        {
            //PlayerPrefs에서 최고 점수 불러오기
            int bestScore = PlayerPrefs.GetInt("BestScore", 0);

            //UI에 최고 점수 표시
            bestScoreText.text = "Flappy Bird : " + bestScore.ToString();
            bestScoreUI.SetActive(true); // 리더보드 UI 활성화
        }
    }

    // 플레이어가 리더보드 영역을 벗어나면 UI 숨기기
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어가 나갈 때
        {
            bestScoreUI.SetActive(false); // 리더보드 UI 숨기기
        }
    }
}
