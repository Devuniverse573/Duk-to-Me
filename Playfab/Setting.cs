using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

// 개인정보 수정페이지=SETTINGS 페이지에서 닉네임 데이터 수정처리하는 코드(미완)
// INPUTFIELD에 현재 닉네임 정보가 떠서 수정할 수 있도록
public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Fetch and display user's score
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
        Debug.Log("Fetched Display Name: " + displayName);

        // // Fetch and display user's score
        // FetchDataFromPlayFab();
    }

    private void OnGetAccountInfoFailure(PlayFabError error)
    {
        Debug.LogError("Failed to fetch PlayFab account info: " + error.ErrorMessage);
    }

    // This method is called when the update button is clicked
    // public void UpdateDisplayName()
    // {
    //     string newDisplayName = displayNameInput.text;

    //     // Update the display name in PlayFab
    //     UpdateUserTitleDisplayNameRequest request = new UpdateUserTitleDisplayNameRequest
    //     {
    //         DisplayName = newDisplayName
    //     };

    //     PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnUpdateDisplayNameSuccess, OnUpdateDisplayNameFailure);
    // }

    // private void OnUpdateDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
    // {
    //     Debug.Log("Display name updated successfully!");
    // }

    // private void OnUpdateDisplayNameFailure(PlayFabError error)
    // {
    //     Debug.LogError("Failed to update display name: " + error.ErrorMessage);
    // }
}
