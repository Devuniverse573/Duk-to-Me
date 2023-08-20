using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int totalScore = 0;

    public static void AddScore(int score)
    {
        totalScore += score;
    }

    public static int GetScore()
    {
        return totalScore / 6; // 씬의 갯수만큼 나눠서 평균 출력하기
    }

	public void HandleButtonClick() 
	{
		int scoreValue = 0;
		scoreValue = ScoreManager.GetScore();

		if (scoreValue <= 100 && scoreValue >= 80) { // 이 문장을 ui로 나오도록
			Debug.Log("Excellent!");
			Debug.Log($"Average Score: {scoreValue}%");
		}
		else if (scoreValue >= 70) {
			Debug.Log("Great job!");
			Debug.Log($"Average Score: {scoreValue}%");
		}
		else if (scoreValue >= 50) {
			Debug.Log("Well done!");
			Debug.Log($"Average Score: {scoreValue}%");
		}
		else if (scoreValue >= 0) {
			Debug.Log("Keep Practicing!");
			Debug.Log($"Average Scor: {scoreValue}%");
		}
	}
}