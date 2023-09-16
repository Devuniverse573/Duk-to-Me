using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//로그인부터 회원가입, 비밀번호찾기까지 데이터처리 코드
public class LoginPagePlayfab : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private TMP_InputField EmailLoginInput;
    [SerializeField] private TMP_InputField PasswordLoginput;
    [SerializeField] private GameObject LoginPage;

    [Header("Register")]
    [SerializeField] private TMP_InputField UsernameRegisterInput;
    [SerializeField] private TMP_InputField EmailRegisterInput;
    [SerializeField] private TMP_InputField PasswordRegisterInput;
    [SerializeField] private GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] private TMP_InputField EmailRecoveryInput;
    [SerializeField] private GameObject RecoveryPage;

    private void Start()
    {

    }

    private void Update()
    {

    }

    #region Button Functions
    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginInput.text,
            Password = PasswordLoginput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    // private void OnLoginSuccess(LoginResult result)
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }
    public TMPro.TextMeshProUGUI t_logname;
    private void OnLoginSuccess(LoginResult result)
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest(), 
            profileResult =>
            {
                string displayName = profileResult.PlayerProfile.DisplayName;
                //t_logname.text = "displayName";
                Debug.Log("Logged in as: " + displayName);
                // You can use the display name for further actions if needed.

                SceneManager.LoadScene("Selection"); // Change this line to load your "Selection" scene.
            }, OnError);
    }



    public void RecoverUser()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecoveryInput.text,
            TitleId = "BEF62",
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnErrorRecovery);
    }

    private void OnErrorRecovery(PlayFabError result)
    {

    }

    private void OnRecoverySuccess(SendAccountRecoveryEmailResult obj)
    {
        OpenLoginPage();
    }

    private void OnError(PlayFabError Error)
    {
        Debug.Log(Error.GenerateErrorReport());
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult Result)
    {
        OpenLoginPage();
    }

    public void OpenLoginPage()
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
    }

    public void OpenRegisterPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoveryPage.SetActive(false);
    }

    public void OpenRecoveryPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(true);
    }
    #endregion
}
