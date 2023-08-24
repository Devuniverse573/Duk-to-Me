using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text t_score, t_average; // 프론트
    public static int totalScore = 0;

    public static void AddScore(int score)
    {
        totalScore += score;
    }

    public static int GetScore()
    {
        return totalScore / 6; // 씬의 갯수만큼 나눠서 평균 출력하기
    }

	// GetScore() method를 call하면서 PlayFab DB로도 scoreValue를 account별로 보내기
	public void HandleButtonClick()
	{
		int scoreValue = ScoreManager.GetScore();

		if (scoreValue <= 100 && scoreValue >= 80)
		{
			t_score.text="Excellent!";
			t_average.text=$"Average Score: {scoreValue}%";
			//Debug.Log("Excellent!");
			//Debug.Log($"Average Score: {scoreValue}%");
		}
		else if (scoreValue >= 70)
		{
			t_score.text="Great job!";
			t_average.text=$"Average Score: {scoreValue}%";
			//Debug.Log("Great job!");
			//Debug.Log($"Average Score: {scoreValue}%");
		}
		else if (scoreValue >= 50)
		{
			t_score.text="Well done!";
			t_average.text=$"Average Score: {scoreValue}%";
			//Debug.Log("Well done!");
			//Debug.Log($"Average Score: {scoreValue}%");
		}
		else if (scoreValue >= 0)
		{
			t_score.text="Keep Practicing!";
			t_average.text=$"Average Scor: {scoreValue}%";
			//Debug.Log("Keep Practicing!");
			//Debug.Log($"Average Scor: {scoreValue}%");
		}

		// Call the method to send the score to PlayFab
		SendScoreToPlayFab(scoreValue);
	}

	private void SendScoreToPlayFab(int score)
	{
		// Assuming you have already authenticated the player with PlayFab

		// Create a request to update the player's data
		UpdateUserDataRequest request = new UpdateUserDataRequest
		{
			Data = new Dictionary<string, string>
			{
				{ "score", score.ToString() }
			}
		};

		// Send the request to PlayFab
		PlayFabClientAPI.UpdateUserData(request, OnUpdateUserDataSuccess, OnUpdateUserDataFailure);
	}

	private void OnUpdateUserDataSuccess(UpdateUserDataResult result)
	{
		Debug.Log("Score successfully sent to PlayFab!");
	}

	private void OnUpdateUserDataFailure(PlayFabError error)
	{
		Debug.LogError("Failed to send score to PlayFab: " + error.ErrorMessage);
	}

}
