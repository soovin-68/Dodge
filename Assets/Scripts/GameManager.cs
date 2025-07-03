using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 씬 로드를 위해 필요

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임 오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime; // 생존 시간
    private bool isGameOver; // 게임 오버 상태

    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene"); // 오타 수정
                RestartGame(); // 게임을 다시 시작하는 메서드 호출
            }
        }
    }

    // 게임 오버 상태로 변경하는 메서드 (Update 밖으로 이동)
    public void EndGame()
    {
        isGameOver = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }

    public void RestartGame()
    {
        Debug.Log("게임을 다시 시작합니다.");
        SceneManager.LoadScene("SampleScene"); // 오타 수정
    }
}
