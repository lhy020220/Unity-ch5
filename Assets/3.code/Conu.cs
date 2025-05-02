using System.Collections;
using UnityEngine;
using TMPro;

public class Conu : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  // 카운트다운 텍스트
    public GameObject gameClearPanel;      // 게임 클리어 패널

    private int timeRemaining = 10;

    void Start()
    {
        if (countdownText != null)
        {
            if (gameClearPanel != null)
            {
                gameClearPanel.SetActive(false); // 시작할 때 꺼둠
            }

            StartCoroutine(StartCountdown());
        }
        else
        {
            Debug.LogError("countdownText.");
        }
    }

    IEnumerator StartCountdown()
    {
        while (timeRemaining >= 0)
        {
            countdownText.text = timeRemaining.ToString();
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }

        countdownText.text = "Ends!";

        // 게임 클리어 패널 표시
        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("gameClearPanel");
        }
    }
}