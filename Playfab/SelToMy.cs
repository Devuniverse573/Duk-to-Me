using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class SelToMy : MonoBehaviour
{
    public TMPro.TextMeshProUGUI t_name;

    public void SceneChange()
    {
        SceneManager.LoadScene("MyPage");

        // Fetch and display PlayFab data when transitioning scenes
        FetchDataFromPlayFab();
    }

    private void FetchDataFromPlayFab()
    {
        // Request to get the player's account info
        GetAccountInfoRequest request = new GetAccountInfoRequest();

        // Send the request to PlayFab
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnGetAccountInfoFailure);
    }

    private void OnGetAccountInfoSuccess(GetAccountInfoResult result)
    {
        // Fetch and display user's display name
        string displayName = result.AccountInfo.TitleInfo.DisplayName;
        //Debug.Log("Fetched Display Name: " + displayName);
        t_name.text = "displayName";

        // Fetch and display user's score
        FetchScoreFromPlayFab();
    }

    private void OnGetAccountInfoFailure(PlayFabError error)
    {
        Debug.LogError("Failed to fetch PlayFab account info: " + error.ErrorMessage);
    }

    private void FetchScoreFromPlayFab()
    {
        // Assuming you have already authenticated the player with PlayFab

        // Create a request to get the player's data
        GetUserDataRequest request = new GetUserDataRequest();

        // Send the request to PlayFab
        PlayFabClientAPI.GetUserData(request, OnGetUserDataSuccess, OnGetUserDataFailure);
    }

    private void OnGetUserDataSuccess(GetUserDataResult result)
    {
        if (result.Data.TryGetValue("score", out var scoreValue))
        {
            if (int.TryParse(scoreValue.Value, out var parsedScore))
            {
                Debug.Log("Fetched Score: " + parsedScore);
            }
            else
            {
                Debug.LogError("Failed to parse fetched score.");
            }
        }
        else
        {
            Debug.Log("No 'score' data found in PlayFab.");
        }
    }

    private void OnGetUserDataFailure(PlayFabError error)
    {
        Debug.LogError("Failed to fetch PlayFab data: " + error.ErrorMessage);
    }
}
